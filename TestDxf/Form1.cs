using BD.Common;
using netDxf;
using netDxf.Entities;
using netDxf.Tables;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TestDxf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            EnableDoubleBuffering();

            this.panel1.MouseWheel += Panel1_MouseWheel;
            this.panel1.MouseDown += Panel1_MouseDown; ;
        }

        public void EnableDoubleBuffering()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            this.panel1.Focus();
        }

        private void Panel1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0) scale += 0.1f;
            else scale -= 0.1f;

            if (scale < 0.2) scale = 0.2f;
            if (scale > 5) scale = 5;

            Redraw();
        }

        private void Redraw()
        {
            try
            {
                if (this.IsHandleCreated)
                {
                    this.EndInvoke(this.BeginInvoke(new Action(() =>
                    {
                        panel1.Invalidate();
                    })));
                }
            }
            catch (Exception)
            {

            }
        }

        string fileExtendFilter = "DXF Files(*.dxf)|*.dxf|All Files(*.*)|*.*";

        Pen penNormal = new Pen(Color.White);
        Pen penDottedLine = new Pen(Color.White) { Color = Color.Red, DashStyle = System.Drawing.Drawing2D.DashStyle.Dot, Width = 10, DashPattern = new float[] { 5, 5 } };

        List<EllipseF> circleFs = new List<EllipseF>();
        List<ArcF> arcFs = new List<ArcF>();
        List<PointF> pointFs = new List<PointF>();
        List<LineF> lineFs = new List<LineF>();
        float scale = 0.4f;
        float step = 31f;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            InitControl(e, g);

            foreach (EllipseF ellipse in circleFs)
            {
                ellipse.ReflushLinePoints(step);
                var lines = ellipse.Lines;
                if(lines != null)
                {
                    foreach(LineF line in lines)
                    {
                        g.DrawLine(penNormal, line.StartPoint, line.EndPoint); 
                    }
                }
            }
            foreach (ArcF arc in arcFs)
            {
                 arc.ReflushLinePoints(step);
                var lines = arc.Lines;
                if (lines != null)
                {
                    foreach (LineF line in lines)
                    {
                        g.DrawLine(penNormal, line.StartPoint, line.EndPoint);
                    }
                }
                g.DrawArc(penDottedLine, arc.Rectangle, arc.StartAngle, arc.SweepAngle);
            }
            foreach (LineF line in lineFs)
            {
                if (line.IsDottedLine)
                {
                    g.DrawLine(penDottedLine, line.StartPoint, line.EndPoint);
                }
                else
                {
                    g.DrawLine(penNormal, line.StartPoint, line.EndPoint);
                }
            }
            if (this.pointFs.Count > 0)
            {
                g.DrawLines(penNormal, this.pointFs.ToArray());
            }
        }
        private void InitControl(PaintEventArgs e, Graphics g)
        {
            Rectangle clientRectangle = e.ClipRectangle;

            g.Clear(System.Drawing.Color.Black);

            Region regClip = g.Clip;

            g.Clip = new Region(clientRectangle);
            g.TranslateTransform(0, 0);
            g.PageScale = scale;
            // 设置插值模式
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;
            // 设置平滑模式
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
        }

        DxfDocument dxf;
        private void button1_Click(object sender, EventArgs e)
        {
            FileInfo fi = null;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = "./";
                ofd.Filter = fileExtendFilter;
                if (ofd.ShowDialog() == DialogResult.OK)  //如果点击的是打开文件
                {
                    this.textBox1.Text = ofd.SafeFileName;  //获取全路径文件名
                    fi = new FileInfo(ofd.FileName);
                }
            }

            if (fi != null && fi.Exists && fi.Extension == ".dxf")
            {
                dxf = DxfDocument.Load(fi.FullName);
                AddLayers();
                AddGraph();

                panel1.Invalidate();
            }
        }

        private void AddLayers()
        {
            foreach (Layer lay in dxf.Layers)
            {
            }
        }

        void AddGraph()
        {
            circleFs.Clear();
            arcFs.Clear();
            lineFs.Clear();
            pointFs.Clear();

            AddCircles();
            AddEllipses();
            AddArcs();
            AddLines();
            AddPolylines();
        }
        private float ConvertToGdiX(double cadX)
        {
            return (float)cadX;
        }
        private float ConvertToGdiY(double cadY)
        {
            return this.panel1.Height * 3 - (float)cadY;
        }
        private float ConvertToGdiAngle(double cadY)
        {
            return 360f - (float)cadY;
        }

        float minX = 0;
        float minY = 0;
        float maxX = 0;
        float maxY = 0;

        private void AddCircles()
        {
            foreach (Circle obj in dxf.Circles)
            {
                EllipseF circleF = new EllipseF(ConvertToGdiX(obj.Center.X - obj.Radius), ConvertToGdiY(obj.Center.Y + obj.Radius), 2 * (float)obj.Radius, 2 * (float)obj.Radius, IsDotted(obj));
                circleFs.Add(circleF); 
            }
        }
        private void AddEllipses()
        {
            foreach (Ellipse obj in dxf.Ellipses)
            {
                EllipseF circleF = new EllipseF((float)(obj.Center.X - obj.MajorAxis), ConvertToGdiY(obj.Center.Y + obj.MinorAxis), (float)obj.MajorAxis/*X轴*/, (float)obj.MinorAxis/*Y轴*/, IsDotted(obj));
                circleFs.Add(circleF); 
            }
        }
        private void AddArcs()
        {
            foreach (Arc obj in dxf.Arcs)
            {
                float startAngle = ConvertToGdiAngle(obj.StartAngle);
                float endAngle = ConvertToGdiAngle(obj.EndAngle);
                if (startAngle < endAngle)
                {
                    arcFs.Add(new ArcF((float)(obj.Center.X - obj.Radius), ConvertToGdiY(obj.Center.Y + obj.Radius), 2 * (float)obj.Radius, 2 * (float)obj.Radius, startAngle,  (startAngle - endAngle), IsDotted(obj)));
                }
                else
                {
                    arcFs.Add(new ArcF((float)(obj.Center.X - obj.Radius), ConvertToGdiY(obj.Center.Y + obj.Radius), 2 * (float)obj.Radius, 2 * (float)obj.Radius, startAngle,  (-startAngle + endAngle), IsDotted(obj)));
                }
            }
        }
        private void AddLines()
        {
            foreach (Line obj in dxf.Lines)
            {
                this.lineFs.Add(new LineF((float)obj.StartPoint.X, ConvertToGdiY(obj.StartPoint.Y), (float)obj.EndPoint.X, ConvertToGdiY(obj.EndPoint.Y), IsDotted(obj)));
            }
        }

        private bool IsDotted(EntityObject obj)
        {
            if (obj.Linetype.Name == Linetype.ByLayer.Name)
            {
                return obj.Layer.Name == "虚线";
            }
            if (obj.Linetype.Name == Linetype.ByBlock.Name)
            {
                return obj.Owner.Layer.Name == "虚线";
            }
            return DashOrDotLineType(obj.Linetype);
        }

        private bool DashOrDotLineType(Linetype lineType)
        {
            return lineType.Name == Linetype.Dot.Name || lineType.Name == Linetype.DashDot.Name || lineType.Name == Linetype.Dashed.Name;
        }

        private void AddPolylines()
        {
            foreach (Polyline obj in dxf.Polylines)
            {
                PolylineVertex vertexFirst = null;
                foreach (PolylineVertex vertex in obj.Vertexes)
                {
                    if (vertexFirst == null) vertexFirst = (PolylineVertex)vertex.Clone();
                    this.pointFs.Add(new PointF((float)vertex.Position.X, ConvertToGdiY(vertex.Position.Y)));
                }
                if (obj.IsClosed && vertexFirst != null)
                {
                    this.pointFs.Add(new PointF((float)vertexFirst.Position.X, ConvertToGdiY(vertexFirst.Position.Y)));
                }

                //if (obj.Flags == PolylineTypeFlags.OpenPolyline || obj.Flags == PolylineTypeFlags.ClosedPolylineOrClosedPolygonMeshInM)
                //{
                //    LightWeightPolyline polygon = (LightWeightPolyline)obj;
                //    PathFigure path = new PathFigure();
                //    float bulge = 0;
                //    System.Windows.Point prePoint = new System.Windows.Point();
                //    System.Windows.Point point = new System.Windows.Point();

                //    path.IsClosed = polygon.IsClosed;

                //    for (int i = 0; i < polygon.Vertexes.Count(); i)
                //    {
                //        var seg = polygon.Vertexes[i];
                //        point = new System.Windows.Point(seg.Location.X, -seg.Location.Y);

                //        if (i == 0)
                //        {
                //            path.StartPoint = point;
                //            prePoint = point;
                //            bulge = seg.Bulge;
                //            //angle = 4 * System.Math.Atan(seg.Bulge) / Math.PI * 180;
                //        }
                //        else
                //        {
                //            ArcSegment arc = new ArcSegment();
                //            arc.Point = point;

                //            //if (angle != 0)
                //            if (bulge != 0)
                //            {
                //                double angle = 4 * Math.Atan(Math.Abs(bulge)) / Math.PI * 180;
                //                double length = Math.Sqrt((point.X - prePoint.X) * (point.X - prePoint.X)(point.Y - prePoint.Y) * (point.Y - prePoint.Y));
                //                //double radius = length / (Math.Sqrt(2 * (1 - Math.Cos(angle / 180 * Math.PI))));

                //                double radius = Math.Abs(length / (2 * Math.Sin(angle / 360 * Math.PI)));

                //                arc.Size = new System.Windows.Size(radius, radius);
                //                arc.RotationAngle = angle;

                //                arc.SweepDirection = bulge < 0 ? SweepDirection.Clockwise : SweepDirection.Counterclockwise;
                //                arc.IsLargeArc = Math.Abs(bulge) > 1 ? true : false;
                //            }

                //            prePoint = point;
                //            bulge = seg.Bulge;
                //            //angle = 4 * System.Math.Atan(seg.Bulge) / Math.PI * 180;
                //            path.Segments.Add(arc);

                //        }
                //    } 
                //}
            }
        }

    }
}
