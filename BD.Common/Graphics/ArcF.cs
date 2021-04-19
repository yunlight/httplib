using System;
using System.Collections.Generic;
using System.Drawing;

namespace BD.Common
{
    public class ArcF : CircleBase
    {
        public ArcF(PointF point, SizeF size, float startAngle, float sweepAngle, bool isDottedLine)
        {
            this.StartAngle = startAngle;
            this.SweepAngle = sweepAngle;

            this.IsDottedLine = isDottedLine;
            this._Radius = size.Width / 2;
            this._Center = new PointF(point.X + this._Radius, point.Y + this._Radius);
            this._Rectangle = new RectangleF() { Location = point, Size = size };
            this.SetScale(1f);
        }
        public ArcF(float x, float y, float width, float height, float startAngle, float sweepAngle, bool isDottedLine)
            : this(new PointF(x, y), new SizeF(width, height), startAngle, sweepAngle, isDottedLine)
        {
        }

        public float StartAngle { get; private set; }
        /// <summary>
        /// 旋转过的角度
        /// </summary>
        public float SweepAngle { get; private set; }

        public override void ReflushLinePoints(float lineStep)
        {
            // 起始弧度
            float startRadian = (float)radPOX(this.StartAngle);
            float endRadian = startRadian;
            if (this.SweepAngle > 0)
            {
                endRadian -= (float)radPOX(this.SweepAngle);
            }
            else
            {
                endRadian += (float)radPOX(this.SweepAngle);
            }

            GenLinePoints(this.RotatePoint(new PointF(this.Center.X + this.Radius, this.Center.Y), this.Center, startRadian, true),
                this.RotatePoint(new PointF(this.Center.X + this.Radius, this.Center.Y), this.Center, endRadian, true), this.SweepAngle, lineStep);



            //List<LineF> lineFs = new List<LineF>();
            //List<PointF> pointFs = new List<PointF>();

            //// 绕行弧度值
            //float angle = 2 * (float)(Math.Asin(((double)lineStep / 2) / Radius));
            //int count = (int)((Math.Abs(SweepAngle) / 180 * Math.PI) / angle);
            //double yushu = (Math.Abs(SweepAngle) / 180 * Math.PI) % angle;

            //// 起始弧度
            //float startRadian = (float)radPOX(this.StartAngle);
            //float endRadian = startRadian;
            //if (this.SweepAngle > 0)
            //{
            //    endRadian -= (float)radPOX(this.SweepAngle);
            //}
            //else
            //{
            //    endRadian += (float)radPOX(this.SweepAngle);
            //}

            //PointF startPoint = this.RotatePoint(new PointF(this.Center.X + this.Radius, this.Center.Y), this.Center, startRadian, true);
            //PointF endPoint = this.RotatePoint(new PointF(this.Center.X + this.Radius, this.Center.Y), this.Center, endRadian, true);
            //pointFs.Add(startPoint);
            //for (int i = 0; i < count; i++) // 循环次数 n-1
            //{
            //    PointF nextPoint = RotatePoint(startPoint, this.Center, angle, false);
            //    lineFs.Add(new LineF(startPoint.X, startPoint.Y, nextPoint.X, nextPoint.Y, IsDottedLine));

            //    startPoint = nextPoint;
            //    pointFs.Add(nextPoint);
            //}
            //if (yushu > 0.01 && !IsSamePoint(startPoint, endPoint))
            //{
            //    lineFs.Add(new LineF(startPoint.X, startPoint.Y, endPoint.X, endPoint.Y, IsDottedLine));

            //    pointFs.Add(endPoint);
            //}

            //Lines = lineFs.ToArray();
            //Nodes = pointFs.ToArray();
        }

        public bool IsSamePoint(PointF pint1, PointF pint2)
        {
            return Similar(pint1.X, pint2.X) && Similar(pint1.Y, pint2.Y);
        }

        public bool Similar(float f1, float f2)
        {
            if (f1 > f2)
            {
                return f1 - f2 < 0.1f;
            }
            else
            {
                return f2 - f1 < 0.1f;
            }
        }
         
    }
}
