using System.Collections.Generic;
using System.Drawing;

namespace BD.Common
{
    public class LineF : LineBase
    {
        public LineF(PointF pointFrom, PointF pointTo, bool isDottedLine)
        {
            this.StartPoint = new PointF(pointFrom.X, pointFrom.Y);
            this.EndPoint = new PointF(pointTo.X, pointTo.Y);
            this.IsDottedLine = isDottedLine;
            this.Scale = 1f;
        }
        public LineF(float x1, float y1, float x2, float y2, bool isDottedLine)
            : this(new PointF(x1, y1), new PointF(x2, y2), isDottedLine)
        {
        }

        public PointF StartPoint { get; private set; }
        public PointF EndPoint { get; private set; }

        public float Angle { get; private set; }

        public bool IsDottedLine { get; private set; }

        public void ReflushLinePoints(float lineStep)
        {
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
                    if(yushu3 > Utils.minStep)
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

        public LineF[] Lines { get; private set; }
        public PointF[] Nodes { get; private set; }

        public void Translate(float x, float y)
        {
            this.StartPoint = this.StartPoint + new SizeF(x, y);
            this.EndPoint = this.EndPoint + new SizeF(x, y);
        }
    }
}
