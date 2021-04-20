using BD.Common;
using netDxf;
using netDxf.Entities;
using netDxf.Tables;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace BDSew
{
    public partial class EditCtrl : UserControl
    {

        string fileExtendFilter = "DXF Files(*.dxf)|*.dxf|All Files(*.*)|*.*";

        #region private feild

        LinesTypeEnum DrawLineType = LinesTypeEnum.DottedLine;
        private MoveTypeEnum MoveType;

        float scaleSize = 1;
        private float StepDistance = 3.0f;
        private float LineStep { get { return StepDistance * scaleSize; } }
        private int MoveSpeed = 10; 
        private int stepIndex = 0;

        private int vertexsPointWidth = 1;
        private int vertexsPointHeight = 1;
        private int cursorWidth = 10;

        DxfDocument dxf;

        Pen penAxis = Pens.Silver;
        Pen penCursor = new Pen(Color.White, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Solid };
        Pen penLines = Pens.White;
        Pen penDottedLines = new Pen(Color.White, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Custom, DashPattern = new float[] { 5, 5 } };
        Pen penPoints = new Pen(Color.White, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Solid };
        Pen penCollectionPoints = new Pen(Color.Red, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Solid };

        private const int StartPositionY = 20;
        private int fontDistanceY = 0;
        private int FontDistanceY
        {
            get
            {
                if (fontDistanceY == 0)
                {
                    return fontString.Height + 5;
                }
                return fontDistanceY;
            }
        }
        private const int DefaultFontSize = 8;
        Font fontString = new Font("黑体", DefaultFontSize, System.Drawing.FontStyle.Bold);
        Brush textBrush = Brushes.White;
        #endregion


        private int middleX { get { return this.pnlMiddle.Width / 2; } }
        private int middleY { get { return this.pnlMiddle.Height / 2; } }
        private PointF currentCusor { get; set; }

        private float MoveStepLength { get { return 0.1f; } }

        private float minX { get { return -this.middleX + LineStep; } }
        private float minY { get { return -this.middleY + LineStep; } }
        private float maxX { get { return this.middleX - LineStep; } }
        private float maxY { get { return this.middleY - LineStep; } }


        System.Drawing.Point pointMin { get { return new System.Drawing.Point(-this.middleX, -this.middleY); } }
        System.Drawing.Point pointMax { get { return new System.Drawing.Point(this.middleX, this.middleY); } }

        private Size middleSize;
        private Size MiddleSize { get { if (middleSize == null || middleSize.IsEmpty) { middleSize = new Size(middleX, middleY); } return middleSize; } }



        List<PointF> pointFs = new List<PointF>();
        List<LineF> lines = new List<LineF>();
        List<EllipseF> circleList = new List<EllipseF>();
        List<ArcF> arcList = new List<ArcF>();
        List<System.Drawing.Point> pointsVertex = new List<System.Drawing.Point>();

        private ConcurrentQueue<PointF> collectionPoints = new ConcurrentQueue<PointF>();

        public EditCtrl()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            EventMangaer.Instance.ControlViewChange(BD.Common.ControlViewName.Menu);
        }


        private void EditCtrl_Load(object sender, EventArgs e)
        {
            ShowSpeed();
            DrawLineType = LinesTypeEnum.DottedLine;
            SetSelectState();
            ResetToOrigin();

            Thread thread = new Thread(Reflush);
            thread.IsBackground = true;
            thread.Start();

            _eventMoveStep.Reset();
            Thread thread1 = new Thread(MoveStepThread);
            thread1.IsBackground = true;
            thread1.Start();
        }

        private void pnlMiddle_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            InitControl(e, g);

            DrawAxis(g);
            DrawStrings(g);
            DrawLines(g);
            DrawVertexs(g);
            DrawCursor(g);
            DrawCollectionPoint(g);
            DrawArc(g);
            DrawCircle(g);
        }

        #region Load

        private void ShowSpeed()
        {
            this.txtStepDistance.Text = StepDistance.ToString("f1");
        }

        private void ResetToOrigin()
        {
            MoveMouseToPoint(this.PointToScreen(new System.Drawing.Point(this.pnlMiddle.Location.X + this.middleX, this.pnlMiddle.Location.Y + this.middleY)));

            currentCusor = new PointF(0, 0);
            Repaint();
        }

        private void SetSelectState()
        {
            switch (DrawLineType)
            {
                case LinesTypeEnum.DottedLine:
                    btnDottedLine.BackColor = Color.Green;
                    btnLine.BackColor = Color.Transparent;
                    btnYuanHu.BackColor = Color.Transparent;
                    btnYuan.BackColor = Color.Transparent;

                    btnDottedLine.ForeColor = Color.White;
                    btnLine.ForeColor = Color.Black;
                    btnYuanHu.ForeColor = Color.Black;
                    btnYuan.ForeColor = Color.Black;
                    break;
                case LinesTypeEnum.Line:
                    btnDottedLine.BackColor = Color.Transparent;
                    btnLine.BackColor = Color.Green;
                    btnYuanHu.BackColor = Color.Transparent;
                    btnYuan.BackColor = Color.Transparent;

                    btnDottedLine.ForeColor = Color.Black;
                    btnLine.ForeColor = Color.White;
                    btnYuanHu.ForeColor = Color.Black;
                    btnYuan.ForeColor = Color.Black;
                    break;
                case LinesTypeEnum.YuanHu:
                    btnDottedLine.BackColor = Color.Transparent;
                    btnLine.BackColor = Color.Transparent;
                    btnYuanHu.BackColor = Color.Green;
                    btnYuan.BackColor = Color.Transparent;

                    btnDottedLine.ForeColor = Color.Black;
                    btnLine.ForeColor = Color.Black;
                    btnYuanHu.ForeColor = Color.White;
                    btnYuan.ForeColor = Color.Black;
                    break;
                case LinesTypeEnum.Yuan:
                    btnDottedLine.BackColor = Color.Transparent;
                    btnLine.BackColor = Color.Transparent;
                    btnYuanHu.BackColor = Color.Transparent;
                    btnYuan.BackColor = Color.Green;

                    btnDottedLine.ForeColor = Color.Black;
                    btnLine.ForeColor = Color.Black;
                    btnYuanHu.ForeColor = Color.Black;
                    btnYuan.ForeColor = Color.White;
                    break;
                default:
                    btnDottedLine.BackColor = Color.Green;
                    btnLine.BackColor = Color.Transparent;
                    btnYuanHu.BackColor = Color.Transparent;
                    btnYuan.BackColor = Color.Transparent;

                    btnDottedLine.ForeColor = Color.White;
                    btnLine.ForeColor = Color.Black;
                    btnYuanHu.ForeColor = Color.Black;
                    btnYuan.ForeColor = Color.Black;
                    break;
            }

            ClearAllCollectionPoints();

            collectionPoints.Enqueue(currentCusor);
            this.Repaint();
        }

        private void ClearAllCollectionPoints()
        {
            while (collectionPoints.Count > 0)
            {
                PointF pointF;
                collectionPoints.TryDequeue(out pointF);
            }
        }


        #endregion Load

        #region Paint

        private void InitControl(PaintEventArgs e, Graphics g)
        {
            Rectangle clientRectangle = e.ClipRectangle;

            g.Clear(System.Drawing.Color.Black);

            Region regClip = g.Clip;

            g.Clip = new Region(clientRectangle);
            g.TranslateTransform(this.middleX, this.middleY);
            //g.ScaleTransform(0, 0);
            // 设置插值模式
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;
            // 设置平滑模式
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
        }

        private void DrawAxis(Graphics g)
        {
            g.DrawLine(penAxis, -this.middleX, 0, this.middleX, 0);
            g.DrawLine(penAxis, 0, -this.middleY, 0, this.middleY);
        }

        #region 绘制文字

        private void DrawStrings(Graphics g)
        {
            g.DrawString(GetCusorX(), fontString, textBrush, this.middleX - 10 * fontString.Size, (StartPositionY - this.middleY));
            g.DrawString(GetCusorY(), fontString, textBrush, this.middleX - 10 * fontString.Size, (StartPositionY - this.middleY) + FontDistanceY);
            g.DrawString(GetAngle(), fontString, textBrush, this.middleX - 10 * fontString.Size, (StartPositionY - this.middleY) + FontDistanceY * 2);
            g.DrawString(GetSpeed(), fontString, textBrush, this.middleX - 10 * fontString.Size, (StartPositionY - this.middleY) + FontDistanceY * 3);
        }

        private float GetCusorPointX
        {
            get
            {
                if (currentCusor.X < pointMin.X)
                {
                    return pointMin.X;
                }
                else if (currentCusor.X > pointMax.X)
                {
                    return pointMax.X;
                }
                else
                {
                    return currentCusor.X;
                }
            }
        }
        private float GetCusorPointY
        {
            get
            {
                if (currentCusor.Y < pointMin.Y)
                {
                    return pointMin.Y;
                }
                else if (currentCusor.Y > pointMax.Y)
                {
                    return pointMax.Y;
                }
                else
                {
                    return currentCusor.Y;
                }
            }
        }

        private string GetCusorX()
        {
            return string.Format("   X:" + (GetCusorPointX / this.scaleSize).ToString("f1"));
        }

        private string GetCusorY()
        {
            return string.Format("   Y:" +  (GetCusorPointY / this.scaleSize).ToString("f1"));
        }

        private string GetAngle()
        {
            return "   C：" + string.Empty;
        }

        private string GetSpeed()
        {
            return "速度：" + MoveSpeed;
        }

        #endregion 绘制文字

        private void DrawLines(Graphics g)
        {
            foreach (LineF line in lines)
            {
                if (line.IsDottedLine)
                {
                    g.DrawLine(penDottedLines, line.StartPoint, line.EndPoint);
                }
                else
                {
                    g.DrawLine(penLines, line.StartPoint, line.EndPoint);
                }

                var points = line.Nodes;
                if (points != null)
                {
                    foreach (PointF point in points)
                    {
                        DrawNode(g, point);
                    }
                }
            }
        }
        private void DrawVertexs(Graphics g)
        {
            foreach (System.Drawing.Point point in pointsVertex)
            {
                DrawNode(g, point);
            }
        }

        private void DrawCursor(Graphics g)
        {
            g.DrawLine(penCursor, currentCusor + new Size(0, -cursorWidth), currentCusor + new Size(0, cursorWidth));
            g.DrawLine(penCursor, currentCusor + new Size(-cursorWidth, 0), currentCusor + new Size(cursorWidth, 0));
        }

        private void DrawCollectionPoint(Graphics g)
        {
            foreach (PointF point in collectionPoints)
            {
                g.DrawLines(penCollectionPoints, new PointF[] {
                    new PointF(point.X - vertexsPointWidth, point.Y - vertexsPointHeight),
                    new PointF(point.X + vertexsPointWidth, point.Y - vertexsPointHeight),
                    new PointF(point.X + vertexsPointWidth, point.Y + vertexsPointHeight),
                    new PointF(point.X - vertexsPointWidth, point.Y + vertexsPointHeight),
                });
            }
        }

        private void CalculatePoints()
        { 
            foreach (var ellipse in circleList)
            {
                ellipse.SetScale(scaleSize);
                ellipse.ReflushLinePoints(LineStep);
            }
            foreach (var arc in arcList)
            {
                arc.SetScale(scaleSize);
                arc.ReflushLinePoints(LineStep);
            }
            foreach (var line in lines)
            {
                line.SetScale(scaleSize);
                line.ReflushLinePoints(LineStep);
            }
        }
        private void DrawArc(Graphics g)
        {
            foreach (var arc in arcList)
            {
                var lines = arc.Lines;
                if (lines != null)
                {
                    foreach (LineF line in lines)
                    {
                        g.DrawLine(penLines, line.StartPoint, line.EndPoint);
                    }
                }
                var points = arc.Nodes;
                if (points != null)
                {
                    foreach (PointF point in points)
                    {
                        DrawNode(g, point);
                    }
                }
            }
        }

        private void DrawCircle(Graphics g)
        {
            foreach (var ellipse in circleList)
            {
                var lines = ellipse.Lines;
                if (lines != null)
                {
                    foreach (LineF line in lines)
                    {
                        g.DrawLine(penLines, line.StartPoint, line.EndPoint);
                    }
                }
                var points = ellipse.Nodes;
                if (points != null)
                {
                    foreach (PointF point in points)
                    {
                        DrawNode(g, point);
                    }
                }
            }
        }


        private void DrawNode(Graphics g, System.Drawing.Point point)
        {
            g.DrawLines(penPoints, new System.Drawing.Point[] {
                    new System.Drawing.Point(point.X - vertexsPointWidth, point.Y - vertexsPointHeight),
                    new System.Drawing.Point(point.X + vertexsPointWidth, point.Y - vertexsPointHeight),
                    new System.Drawing.Point(point.X + vertexsPointWidth, point.Y + vertexsPointHeight),
                    new System.Drawing.Point(point.X - vertexsPointWidth, point.Y + vertexsPointHeight),
                });
        }
        private void DrawNode(Graphics g, PointF point)
        {
            g.DrawLines(penPoints, new System.Drawing.PointF[] {
                    new System.Drawing.PointF(point.X - vertexsPointWidth, point.Y - vertexsPointHeight),
                    new System.Drawing.PointF(point.X + vertexsPointWidth, point.Y - vertexsPointHeight),
                    new System.Drawing.PointF(point.X + vertexsPointWidth, point.Y + vertexsPointHeight),
                    new System.Drawing.PointF(point.X - vertexsPointWidth, point.Y + vertexsPointHeight),
                });
        }

        #endregion

        #region 鼠标操作
        /// <summary>
        /// 引用user32.dll动态链接库（windows api），
        /// 使用库中定义 API：SetCursorPos 
        /// </summary>
        [DllImport("user32.dll")]
        private static extern int SetCursorPos(int x, int y);
        /// <summary>
        /// 移动鼠标到指定的坐标点
        /// </summary>
        public void MoveMouseToPoint(System.Drawing.Point p)
        {
            SetCursorPos(p.X, p.Y);
        }
        /// <summary>
        /// 设置鼠标的移动范围
        /// </summary>
        public void SetMouseRectangle(Rectangle rectangle)
        {
            Cursor.Clip = rectangle;
        }
        /// <summary>
        /// 设置鼠标位于屏幕中心
        /// </summary>
        public void SetMouseAtCenterScreen()
        {
            int winHeight = Screen.PrimaryScreen.WorkingArea.Height;
            int winWidth = Screen.PrimaryScreen.WorkingArea.Width;
            System.Drawing.Point centerP = new System.Drawing.Point(winWidth / 2, winHeight / 2);
            MoveMouseToPoint(centerP);
        }
        #endregion 鼠标操作

        #region MoveStep


        private System.Threading.ManualResetEvent _eventMoveStep = new System.Threading.ManualResetEvent(false);
        private void MoveStep()
        {
            _eventMoveStep.Set();
        }
        private void StopMoveStep()
        {
            _eventMoveStep.Reset();
        }

        private void MoveStepThread()
        {
            while (true)
            {
                _eventMoveStep.WaitOne();

                MoveToNextStep();

                Thread.Sleep(MoveSpeed);
            }
        }
        private void MoveToNextStep()
        {
            switch (MoveType)
            {
                case MoveTypeEnum.MoveLeftUp:
                    if (currentCusor.X < minX || currentCusor.Y < minY) return;

                    currentCusor += new SizeF(-MoveStepLength, -MoveStepLength);
                    break;
                case MoveTypeEnum.MoveUp:
                    if (currentCusor.Y < minY) return;

                    currentCusor += new SizeF(0, -MoveStepLength);
                    break;
                case MoveTypeEnum.MoveRightUp:
                    if (currentCusor.X > maxX || currentCusor.Y < minY) return;

                    currentCusor += new SizeF(MoveStepLength, -MoveStepLength);
                    break;
                case MoveTypeEnum.MoveRight:
                    if (currentCusor.X > maxX) return;

                    currentCusor += new SizeF(MoveStepLength, 0);
                    break;
                case MoveTypeEnum.MoveRightDown:
                    if (currentCusor.X > maxX || currentCusor.Y > maxY) return;

                    currentCusor += new SizeF(MoveStepLength, MoveStepLength);
                    break;
                case MoveTypeEnum.MoveDown:
                    if (currentCusor.Y > maxY) return;

                    currentCusor += new SizeF(0, MoveStepLength);
                    break;
                case MoveTypeEnum.MoveLeftDown:
                    if (currentCusor.X < minX || currentCusor.Y > maxY) return;

                    currentCusor += new SizeF(-MoveStepLength, MoveStepLength);
                    break;
                case MoveTypeEnum.MoveLeft:
                    if (currentCusor.X < minX) return;

                    currentCusor += new SizeF(-MoveStepLength, 0);
                    break;
            }
            Repaint();
        }
        #endregion

        #region Reflush
        private System.Threading.ManualResetEvent _event = new System.Threading.ManualResetEvent(false);
        private void Repaint()
        {
            _event.Set();
        }
        private void Reflush()
        {
            while (true)
            {
                _event.WaitOne();
                if (this.IsHandleCreated)
                {
                    try
                    {
                        this.EndInvoke(this.BeginInvoke(new Action(() =>
                        {
                            this.pnlMiddle.Refresh();
                        })));
                    }
                    catch (Exception)
                    {
                    }
                }
                _event.Reset();

                Thread.Sleep(100);
            }
        }
        #endregion

        private void txtStepDistance_MouseDown(object sender, MouseEventArgs e)
        {
            DigitalInputForm form = new DigitalInputForm(label7.Text);
            form.Distance = this.StepDistance;
            form.TopLevel = true;
            if (form.ShowDialog() == DialogResult.OK)
            {
                StepDistance = form.Distance;
            }
            ShowSpeed();
            CalculatePoints();
            Repaint();
        }

        #region 图像采集

        private void btnMoveLeftUp_MouseDown(object sender, MouseEventArgs e)
        {
            MoveType = MoveTypeEnum.MoveLeftUp;
            MoveStep();
        }

        private void btnMoveLeftUp_MouseUp(object sender, MouseEventArgs e)
        {
            StopMoveStep();
        }

        private void btnMoveUp_MouseDown(object sender, MouseEventArgs e)
        {
            MoveType = MoveTypeEnum.MoveUp;
            MoveStep();
        }

        private void btnMoveUp_MouseUp(object sender, MouseEventArgs e)
        {
            StopMoveStep();
        }

        private void btnMoveRightUp_MouseDown(object sender, MouseEventArgs e)
        {
            MoveType = MoveTypeEnum.MoveRightUp;
            MoveStep();
        }

        private void btnMoveRightUp_MouseUp(object sender, MouseEventArgs e)
        {
            StopMoveStep();
        }

        private void btnMoveRight_MouseDown(object sender, MouseEventArgs e)
        {
            MoveType = MoveTypeEnum.MoveRight;
            MoveStep();
        }

        private void btnMoveRight_MouseUp(object sender, MouseEventArgs e)
        {
            StopMoveStep();
        }

        private void btnMoveRightDown_MouseDown(object sender, MouseEventArgs e)
        {
            MoveType = MoveTypeEnum.MoveRightDown;
            MoveStep();
        }

        private void btnMoveRightDown_MouseUp(object sender, MouseEventArgs e)
        {
            StopMoveStep();
        }

        private void btnMoveDown_MouseDown(object sender, MouseEventArgs e)
        {
            MoveType = MoveTypeEnum.MoveDown;
            MoveStep();
        }

        private void btnMoveDown_MouseUp(object sender, MouseEventArgs e)
        {
            StopMoveStep();
        }

        private void btnMoveLeftDown_MouseDown(object sender, MouseEventArgs e)
        {
            MoveType = MoveTypeEnum.MoveLeftDown;
            MoveStep();
        }

        private void btnMoveLeftDown_MouseUp(object sender, MouseEventArgs e)
        {
            StopMoveStep();
        }

        private void btnMoveLeft_MouseDown(object sender, MouseEventArgs e)
        {
            MoveType = MoveTypeEnum.MoveLeft;
            MoveStep();
        }

        private void btnMoveLeft_MouseUp(object sender, MouseEventArgs e)
        {
            StopMoveStep();
        }

        private void btnMoveSpeed_Click(object sender, EventArgs e)
        {
            // 移速
        }


        private void btnDottedLine_Click(object sender, EventArgs e)
        {
            DrawLineType = LinesTypeEnum.DottedLine;
            SetSelectState();
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            DrawLineType = LinesTypeEnum.Line;
            SetSelectState();
        }

        private void btnYuanHu_Click(object sender, EventArgs e)
        {
            DrawLineType = LinesTypeEnum.YuanHu;
            SetSelectState();
        }

        private void btnYuan_Click(object sender, EventArgs e)
        {
            DrawLineType = LinesTypeEnum.Yuan;
            SetSelectState();
        }


        #endregion

        #region 文件操作

        private void btnSaveAs_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            FileInfo fi = null;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = "./";
                ofd.Filter = fileExtendFilter;
                if (ofd.ShowDialog() == DialogResult.OK)  //如果点击的是打开文件
                {
                    fi = new FileInfo(ofd.FileName);
                }
            }

            if (fi != null && fi.Exists && fi.Extension == ".dxf")
            {
                dxf = DxfDocument.Load(fi.FullName);
                AddGraphics();

                pnlMiddle.Invalidate();
            }
        }

        private float dxfMinX { get; set; }
        private float dxfMinY { get; set; }
        private float dxfMaxX { get; set; }
        private float dxfMaxY { get; set; }

        void AddGraphics()
        {
            dxfMinX = 10000;//模型应该不会有这么大的值
            dxfMinY = 10000;
            dxfMaxX = -10000;
            dxfMaxX = -10000;
            ClearGraphics();

            AddCircles();
            AddEllipses();
            AddArcs();
            AddLines();
            AddPolylines();

            if (VerifyPointNotInArea())
            {
                ClearGraphics();

                MessageBox.Show(string.Format(@"图形大小超出界限，
 当前限定大小 X [{0} * {1}], Y [{2} * {3}], 
 实际图像大小 X [{4} * {5}], Y [{6} * {7}]",
                   -SystemSettings.Instance.XLeft, SystemSettings.Instance.XRight, -SystemSettings.Instance.YUp, SystemSettings.Instance.YDown,
                   dxfMinX.ToString("f1"), dxfMaxX.ToString("f1"), dxfMinY.ToString("f1"), dxfMaxY.ToString("f1")));
            }
            ChangeScaleByInputFile();

            CalculatePoints();
        }

        private void ChangeScaleByInputFile()
        {
            float maxX = Math.Max(Math.Abs(dxfMinX), Math.Abs(dxfMaxX));
            float maxY = Math.Max(Math.Abs(dxfMinY), Math.Abs(dxfMaxY));
            if (maxX == 0) maxX = this.middleX;
            if (maxY == 0) maxY = this.middleY;

            scaleSize = Math.Max(this.middleX / maxX, this.middleY / maxY);
            scaleSize /= 1.5f;
        }

        private void ClearGraphics()
        {
            circleList.Clear();
            arcList.Clear();
            lines.Clear();
            pointFs.Clear();
        }

        private void AddCircles()
        {
            foreach (Circle obj in dxf.Circles)
            {
                EllipseF circleF = new EllipseF(ConvertToGdiX(obj.Center.X - obj.Radius), ConvertToGdiY(obj.Center.Y + obj.Radius), 2 * (float)obj.Radius, 2 * (float)obj.Radius, IsDotted(obj));
                circleList.Add(circleF);

                if (dxfMinX > circleF.Rectangle.X) dxfMinX = circleF.Rectangle.X;
                if (dxfMinY > circleF.Rectangle.Y) dxfMinY = circleF.Rectangle.Y;
                if (dxfMaxX < circleF.Rectangle.X + circleF.Rectangle.Width) dxfMaxX = circleF.Rectangle.X + circleF.Rectangle.Width;
                if (dxfMaxY < circleF.Rectangle.Y + circleF.Rectangle.Height) dxfMaxY = circleF.Rectangle.Y + circleF.Rectangle.Height;
            }
        }
        private void AddEllipses()
        {
            foreach (Ellipse obj in dxf.Ellipses)
            {
                EllipseF circleF = new EllipseF(ConvertToGdiX(obj.Center.X - obj.MajorAxis), ConvertToGdiY(obj.Center.Y + obj.MinorAxis), (float)obj.MajorAxis/*X轴*/, (float)obj.MinorAxis/*Y轴*/, IsDotted(obj));
                circleList.Add(circleF);

                if (dxfMinX > circleF.Rectangle.X) dxfMinX = circleF.Rectangle.X;
                if (dxfMinY > circleF.Rectangle.Y) dxfMinY = circleF.Rectangle.Y;
                if (dxfMaxX < circleF.Rectangle.X + circleF.Rectangle.Width) dxfMaxX = circleF.Rectangle.X + circleF.Rectangle.Width;
                if (dxfMaxY < circleF.Rectangle.Y + circleF.Rectangle.Height) dxfMaxY = circleF.Rectangle.Y + circleF.Rectangle.Height;

            }
        }
        private void AddArcs()
        {
            foreach (Arc obj in dxf.Arcs)
            {
                float startAngle = ConvertToGdiAngle(obj.StartAngle);
                float endAngle = ConvertToGdiAngle(obj.EndAngle);
                ArcF arcF;
                if (startAngle < endAngle)
                {
                    arcF = new ArcF(ConvertToGdiX(obj.Center.X - obj.Radius), ConvertToGdiY(obj.Center.Y + obj.Radius), 2 * (float)obj.Radius, 2 * (float)obj.Radius, startAngle, (startAngle - endAngle), IsDotted(obj));
                }
                else
                {
                    arcF = new ArcF(ConvertToGdiX(obj.Center.X - obj.Radius), ConvertToGdiY(obj.Center.Y + obj.Radius), 2 * (float)obj.Radius, 2 * (float)obj.Radius, startAngle, (-startAngle + endAngle), IsDotted(obj));
                }
                arcList.Add(arcF);

                List<PointF> pts = new List<PointF>();

                PointF startPoint = new PointF(ConvertToGdiX(Math.Cos(arcF.StartAngle) * arcF.Radius), (float)(Math.Sin(arcF.StartAngle) * arcF.Radius));
                PointF endPoint = new PointF(ConvertToGdiX(Math.Cos(arcF.StartAngle + arcF.SweepAngle) * arcF.Radius), (float)(Math.Sin(arcF.StartAngle + arcF.SweepAngle) * arcF.Radius));
                pts.Add(startPoint);
                pts.Add(endPoint);

                PointF point0 = new PointF(arcF.Rectangle.Right, arcF.Center.Y);
                PointF point90 = new PointF(arcF.Center.X, arcF.Rectangle.Bottom);
                PointF point180 = new PointF(arcF.Rectangle.Left, arcF.Center.Y);
                PointF point270 = new PointF(arcF.Center.X, arcF.Rectangle.Top);

                if ((arcF.StartAngle <= 0 && arcF.StartAngle + arcF.SweepAngle > 0) ||
                   (arcF.StartAngle >= 0 && arcF.StartAngle + arcF.SweepAngle < 0) ||
                   (arcF.StartAngle <= 360 && arcF.StartAngle + arcF.SweepAngle > 360) ||
                   (arcF.StartAngle >= 360 && arcF.StartAngle + arcF.SweepAngle < 360))
                {
                    pts.Add(point0);
                }
                if ((arcF.StartAngle <= 90 && arcF.StartAngle + arcF.SweepAngle > 90) ||
                    (arcF.StartAngle >= 90 && arcF.StartAngle + arcF.SweepAngle < 90))
                {
                    pts.Add(point90);
                }
                if ((arcF.StartAngle <= 180 && arcF.StartAngle + arcF.SweepAngle > 180) ||
                   (arcF.StartAngle >= 180 && arcF.StartAngle + arcF.SweepAngle < 180))
                {
                    pts.Add(point180);
                }
                if ((arcF.StartAngle <= 270 && arcF.StartAngle + arcF.SweepAngle > 270) ||
                  (arcF.StartAngle >= 270 && arcF.StartAngle + arcF.SweepAngle < 270))
                {
                    pts.Add(point270);
                }

                foreach (var point in pts)
                {
                    if (dxfMinX > point.X) dxfMinX = point.X;
                    if (dxfMinY > point.Y) dxfMinY = point.Y;
                    if (dxfMaxX < point.X) dxfMaxX = point.X;
                    if (dxfMaxY < point.Y) dxfMaxY = point.Y;
                }
            }
        }
        private void AddLines()
        {
            foreach (Line obj in dxf.Lines)
            {
                LineF lineF = new LineF(ConvertToGdiX(obj.StartPoint.X), ConvertToGdiY(obj.StartPoint.Y), ConvertToGdiX(obj.EndPoint.X), ConvertToGdiY(obj.EndPoint.Y), IsDotted(obj));
                this.lines.Add(lineF);

                if (dxfMinX > lineF.StartPoint.X) dxfMinX = lineF.StartPoint.X;
                if (dxfMinX > lineF.EndPoint.X) dxfMinX = lineF.EndPoint.X;
                if (dxfMinY > lineF.StartPoint.Y) dxfMinY = lineF.StartPoint.Y;
                if (dxfMinY > lineF.EndPoint.Y) dxfMinY = lineF.EndPoint.Y;

                if (dxfMaxX < lineF.StartPoint.X) dxfMaxX = lineF.StartPoint.X;
                if (dxfMaxX < lineF.EndPoint.X) dxfMaxX = lineF.EndPoint.X;
                if (dxfMaxY < lineF.StartPoint.Y) dxfMaxY = lineF.StartPoint.Y;
                if (dxfMaxY < lineF.EndPoint.Y) dxfMaxY = lineF.EndPoint.Y;
            }
        }

        private void AddPolylines()
        {
            foreach (Polyline obj in dxf.Polylines)
            {
                PolylineVertex vertexFirst = null;
                foreach (PolylineVertex vertex in obj.Vertexes)
                {
                    if (vertexFirst == null) vertexFirst = (PolylineVertex)vertex.Clone();

                    PointF pointF = new PointF(ConvertToGdiX(vertex.Position.X), ConvertToGdiY(vertex.Position.Y));
                    this.pointFs.Add(pointF);

                    if (dxfMinX > pointF.X) dxfMinX = pointF.X;
                    if (dxfMinY > pointF.Y) dxfMinY = pointF.Y;
                    if (dxfMaxX < pointF.X) dxfMaxX = pointF.X;
                    if (dxfMaxY < pointF.Y) dxfMaxY = pointF.Y;
                }
                if (obj.IsClosed && vertexFirst != null)
                {
                    PointF pointF = new PointF(ConvertToGdiX(vertexFirst.Position.X), ConvertToGdiY(vertexFirst.Position.Y));
                    this.pointFs.Add(pointF);

                    if (dxfMinX > pointF.X) dxfMinX = pointF.X;
                    if (dxfMinY > pointF.Y) dxfMinY = pointF.Y;
                    if (dxfMaxX < pointF.X) dxfMaxX = pointF.X;
                    if (dxfMaxY < pointF.Y) dxfMaxY = pointF.Y;
                }
            }
        }


        private bool VerifyPointNotInArea()
        {
            return dxfMinX < -SystemSettings.Instance.XLeft || dxfMaxX > SystemSettings.Instance.XRight ||
                dxfMinY < -SystemSettings.Instance.YUp || dxfMaxY > SystemSettings.Instance.YDown;
        }


        private float ConvertToGdiX(double cadX)
        {
            return (float)cadX;
        }
        private float ConvertToGdiY(double cadY)
        {
            return -(float)cadY;
        }
        private float ConvertToGdiAngle(double cadY)
        {
            return 360f - (float)cadY;
        }

        private bool IsDotted(EntityObject obj)
        {
            if (obj.Linetype.Name == Linetype.ByLayer.Name)
            {
                return SystemSettings.Instance.IsDashLine(obj.Layer.Linetype.Name);
            }
            if (obj.Linetype.Name == Linetype.ByBlock.Name)
            {
                return SystemSettings.Instance.IsDashLine(obj.Owner.Layer.Linetype.Name);
            }
            return DashOrDotLineType(obj.Linetype);
        }

        private bool DashOrDotLineType(Linetype lineType)
        {
            return lineType.Name == Linetype.Dot.Name || lineType.Name == Linetype.DashDot.Name || lineType.Name == Linetype.Dashed.Name ||
                SystemSettings.Instance.IsDashLine(lineType.Name);
        }


        #endregion

        private void btnPreStep_Click(object sender, EventArgs e)
        {
            GoToPreStep();
        }

        private void btnNextStep_Click(object sender, EventArgs e)
        {
            GoToNextStep();
        }

        private void GoToPreStep()
        {
            if (stepIndex > 0)
            {
                this.currentCusor = pointsVertex[--stepIndex];
            }

            Repaint();
        }

        private void GoToNextStep()
        {
            if (pointsVertex.Count > stepIndex + 1)
            {
                this.currentCusor = pointsVertex[++stepIndex];
            }
            Repaint();
        }

        #region 操作

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetToOrigin();
        }

        private void btnMoveLineStep_Click(object sender, EventArgs e)
        {

        }

        private void btnMoveLineSegment_Click(object sender, EventArgs e)
        {

        }

        private void btnInsertLineStep_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteLineStep_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {

        }

        private void btnPaste_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            this.scaleSize += 0.1f;
            this.CalculatePoints();
            this.Repaint();
        }

        private void btnCenter_Click(object sender, EventArgs e)
        {
            this.scaleSize = 1f;
            this.CalculatePoints();
            this.Repaint();
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            this.scaleSize -= 0.1f;
            this.CalculatePoints();
            this.Repaint();
        }

        private void btnCollection_Click(object sender, EventArgs e)
        {
            collectionPoints.Enqueue(currentCusor);
        }

        private void btnGenGraphics_Click(object sender, EventArgs e)
        {
            DrawGraphics();
            CalculatePoints();
            Repaint();
        }

        #region DrawGraphics

        private void DrawGraphics()
        {
            switch (DrawLineType)
            {
                case LinesTypeEnum.DottedLine:
                    GenDottedLinePoints();
                    break;
                case LinesTypeEnum.Line:
                    GenLinePoints();
                    break;
                case LinesTypeEnum.YuanHu:
                    GenYuanHuPoints();
                    break;
                case LinesTypeEnum.Yuan:
                    GenYuanPoints();
                    break;
                default:
                    break;
            }
        }

        private void GenDottedLinePoints()
        {
            PointF lastP = new PointF();
            while (collectionPoints.Count > 0)
            {
                PointF pFrom;
                if (lastP.IsEmpty)
                {
                    collectionPoints.TryDequeue(out pFrom);
                    if (pFrom.IsEmpty)
                    {
                        continue;
                    }
                    lastP = pFrom;
                }
                PointF pTo;
                collectionPoints.TryDequeue(out pTo);
                if (pTo.IsEmpty)
                {
                    continue;
                }

                lines.Add(new LineF(lastP, pTo, true));
                lastP = pTo; ;
            }
        }

        private void GenLinePoints()
        {
            PointF lastP = new PointF();
            while (collectionPoints.Count > 0)
            {
                PointF pFrom;
                if (lastP.IsEmpty)
                {
                    collectionPoints.TryDequeue(out pFrom);
                    if (pFrom.IsEmpty)
                    {
                        continue;
                    }
                    lastP = pFrom;
                }
                PointF pTo;
                collectionPoints.TryDequeue(out pTo);
                if (pTo.IsEmpty)
                {
                    continue;
                }

                lines.Add(new LineF(lastP, pTo, false));
                lastP = pTo; ;
            }
        }


        private void GenYuanHuPoints()
        {
            while (collectionPoints.Count >= 3)
            {
                PointF p1, p2, p3;
                collectionPoints.TryDequeue(out p1);
                collectionPoints.TryDequeue(out p2);
                collectionPoints.TryDequeue(out p3);

                GenArcFromThreePoint(p1.X, p1.Y, p2.X, p2.Y, p3.X, p3.Y);
            }
        }

        void GenArcFromThreePoint(float x1, float y1, float x2, float y2, float x3, float y3)
        {
            double a = x1 - x2;
            double b = y1 - y2;
            double c = x1 - x3;
            double d = y1 - y3;
            double e = ((x1 * x1 - x2 * x2) + (y1 * y1 - y2 * y2)) / 2.0;
            double f = ((x1 * x1 - x3 * x3) + (y1 * y1 - y3 * y3)) / 2.0;
            double det = b * c - a * d;

            if (Math.Abs(det) > 0.001)
            {
                //x0,y0为计算得到的原点
                double x0 = -(d * e - b * f) / det;
                double y0 = -(a * f - c * e) / det;

                double radius = Math.Sqrt((x1 - x0) * (x1 - x0) + (y1 - y0) * (y1 - y0));

                double angle1;
                double angle2;
                double angle3;

                double sinValue1;
                double cosValue1;
                double sinValue2;
                double cosValue2;
                double sinValue3;
                double cosValue3;

                sinValue1 = (y1 - y0) / radius;
                cosValue1 = (x1 - x0) / radius;
                if (cosValue1 >= 0.99999) cosValue1 = 0.99999;
                if (cosValue1 <= -0.99999) cosValue1 = -0.99999;
                angle1 = Math.Acos(cosValue1);
                angle1 = angle1 / 3.14 * 180;
                if (sinValue1 < -0.05) angle1 = 360 - angle1;

                sinValue2 = (y2 - y0) / radius;
                cosValue2 = (x2 - x0) / radius;
                if (cosValue2 >= 0.99999) cosValue2 = 0.99999;
                if (cosValue2 <= -0.99999) cosValue2 = -0.99999;
                angle2 = Math.Acos(cosValue2);
                angle2 = angle2 / 3.14 * 180;
                if (sinValue2 < -0.05) angle2 = 360 - angle2;

                sinValue3 = (y3 - y0) / radius;
                cosValue3 = (x3 - x0) / radius;
                if (cosValue3 >= 0.99999) cosValue3 = 0.99999;
                if (cosValue3 <= -0.99999) cosValue3 = -0.99999;
                angle3 = Math.Acos(cosValue3);
                angle3 = angle3 / 3.14 * 180;

                if (sinValue3 < -0.05) angle3 = 360 - angle3;

                bool PosDown = false;
                double Delta13;
                if (angle1 < angle3)
                {
                    Delta13 = angle3 - angle1;
                }
                else
                {
                    Delta13 = angle3 - angle1 + 360;
                }

                double Delta12;
                if (angle1 < angle2)
                {
                    Delta12 = angle2 - angle1;
                }
                else
                {
                    Delta12 = angle2 - angle1 + 360;
                }

                if (Delta13 > Delta12)
                {
                    PosDown = true;
                }
                else
                {
                    PosDown = false;
                }

                ArcF arcF;
                if (PosDown)
                {
                    if (angle3 > angle1)
                    {
                        arcF =  new ArcF(new PointF((float)(x0 - radius), (float)(y0 - radius)), new SizeF((float)(2 * radius), (float)(2 * radius)), (float)(angle3), -(float)(angle3 - angle1), false);
                        //arcF.SetScale(scaleSize);
                    }
                    else
                    {
                        arcF = new ArcF(new PointF((float)(x0 - radius), (float)(y0 - radius)), new SizeF((float)(2 * radius), (float)(2 * radius)), (float)(angle3), -(float)(angle3 - angle1 + 360), false);
                        //arcF.SetScale(scaleSize);
                    }
                }
                else
                {
                    if (angle1 > angle3)
                    {
                        arcF = new ArcF(new PointF((float)(x0 - radius), (float)(y0 - radius)), new SizeF((float)(2 * radius), (float)(2 * radius)), (float)(angle1), -(float)(angle1 - angle3), false);
                        //arcF.SetScale(scaleSize);
                    }
                    else
                    {
                        arcF = new ArcF(new PointF((float)(x0 - radius), (float)(y0 - radius)), new SizeF((float)(2 * radius), (float)(2 * radius)), (float)(angle1), -(float)(angle1 - angle3 + 360), false);
                        //arcF.SetScale(scaleSize);
                    }
                }
                if(arcF != null)
                {
                    arcList.Add(arcF);
                }
            }
        }

        private void GenYuanPoints()
        {
            while (collectionPoints.Count >= 3)
            {
                PointF p1, p2, p3;
                collectionPoints.TryDequeue(out p1);
                collectionPoints.TryDequeue(out p2);
                collectionPoints.TryDequeue(out p3);

                GenEllipseFromThreePoint(p1.X, p1.Y, p2.X, p2.Y, p3.X, p3.Y);
                //circleList.Add(new Arc(p1, p2, p3));
            }
        }
        void GenEllipseFromThreePoint(float x1, float y1, float x2, float y2, float x3, float y3)
        {
            double a = x1 - x2;
            double b = y1 - y2;
            double c = x1 - x3;
            double d = y1 - y3;
            double e = ((x1 * x1 - x2 * x2) + (y1 * y1 - y2 * y2)) / 2.0;
            double f = ((x1 * x1 - x3 * x3) + (y1 * y1 - y3 * y3)) / 2.0;
            double det = b * c - a * d;

            if (Math.Abs(det) > 0.001)
            {
                //x0,y0为计算得到的原点
                double x0 = -(d * e - b * f) / det;
                double y0 = -(a * f - c * e) / det;

                double radius = Math.Sqrt((x1 - x0) * (x1 - x0) + (y1 - y0) * (y1 - y0));

                circleList.Add(new EllipseF((float)(x0 - radius), (float)(y0 - radius), (float)(2 * radius), (float)(2 * radius), false));
            }
        }

        #endregion

        private void btnCancelCollection_Click(object sender, EventArgs e)
        {
            while (collectionPoints.Count > 0)
            {
                PointF pointF;
                collectionPoints.TryDequeue(out pointF);
            }
        }
    }
}
