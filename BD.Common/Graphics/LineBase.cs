using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD.Common
{
    public class LineBase
    {
        public float Scale { get; set; }

        public PointF StartPoint { get; protected set; }
        public PointF EndPoint { get; protected set; } 
        public bool IsDottedLine { get; protected set; }

        public LineF[] Lines { get; protected set; }
        public PointF[] Nodes { get; protected set; }


        public double Distance(PointF p1, PointF p2)
        {
            return Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        }


        public void SetScale(float value)
        {
            this.Scale = value;
            this.StartPoint = new PointF(this.StartPoint.X * this.Scale, this.StartPoint.Y * this.Scale);
            this.EndPoint = new PointF(this.EndPoint.X * this.Scale, this.EndPoint.Y * this.Scale);
        }

        public void ReflushLinePoints(float lineStep)
        {
            lineStep = lineStep;

            List<LineF> lineFs = new List<LineF>();
            List<PointF> pointFs = new List<PointF>();

            if (IsDottedLine)
            {
                lineFs.Add(new LineF(this.StartPoint, this.EndPoint, IsDottedLine));
                pointFs.Add(this.StartPoint);
                pointFs.Add(this.EndPoint);
            }
            else
            {
                float distance = (float)Distance(this.StartPoint, this.EndPoint);
                float count = (int)(distance / lineStep);
                float yushu = (int)(distance % lineStep);
                if (yushu * count > Utils.minStep) // 如果总数大于0.1
                {
                    count++;
                }
                float step = distance / count;
                float yushu2 = step % Utils.minStep;
                float step2 = step - yushu2;

                PointF fromPoint = new PointF(StartPoint.X, StartPoint.Y);
                pointFs.Add(fromPoint);
                SizeF size = new SizeF(EndPoint.X - StartPoint.X, EndPoint.Y - StartPoint.Y);
                float yushu3 = 0;
                for (int i = 0; i < count - 1; i++) // 循环次数 n-1
                {
                    float stepTemp = step2;
                    yushu3 += yushu2;
                    if (yushu3 > Utils.minStep)
                    {
                        stepTemp += Utils.minStep;
                        yushu3 -= Utils.minStep;
                    }

                    float stepX = (stepTemp / distance) * size.Width;
                    float stepY = (stepTemp / distance) * size.Height;

                    PointF nextPoint = new PointF(fromPoint.X + stepX, fromPoint.Y + stepY);
                    lineFs.Add(new LineF(fromPoint.X, fromPoint.Y, nextPoint.X, nextPoint.Y, IsDottedLine));

                    fromPoint = nextPoint;
                    pointFs.Add(nextPoint);
                }
                // 最后一个点
                lineFs.Add(new LineF(fromPoint.X, fromPoint.Y, this.EndPoint.X, this.EndPoint.Y, IsDottedLine));
                pointFs.Add(this.EndPoint);
            }

            Lines = lineFs.ToArray();
            Nodes = pointFs.ToArray();
        }
    }
}
