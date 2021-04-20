using System;
using System.Collections.Generic;
using System.Drawing;

namespace BD.Common
{
    public abstract class CircleBase
    {
        public LineF[] Lines { get; protected set; }

        public PointF[] Nodes { get; protected set; }

        public float Scale { get; set; }

        public PointF _Center { get; set; }
        public float _Radius { get; set; }
        public RectangleF _Rectangle { get; set; }

        public PointF Center { get; private set; }
        public float Radius { get; private set; }
        public RectangleF Rectangle { get; private set; }

        public bool IsDottedLine { get; protected set; }

        public abstract void ReflushLinePoints(float lineStep);

        public void SetScale(float value)
        {
            this.Scale = value;
            this.Radius = this._Radius * this.Scale;
            this.Center = new PointF(this._Center.X * this.Scale, this._Center.Y * this.Scale);
            Rectangle = new RectangleF() { X = _Rectangle.X * this.Scale, Y = _Rectangle.Y * this.Scale, Width = _Rectangle.Width * this.Scale, Height = _Rectangle.Height * this.Scale };
        }

        /// <summary>
        /// 绕圆心旋转一定角度后的点坐标
        /// </summary>
        /// <param name="pointForm"></param>
        /// <param name="center"></param>
        /// <param name="angle"></param>
        /// <param name="isClockwise"></param>
        /// <returns></returns>
        protected PointF RotatePoint(PointF pointForm, PointF center, double angle, bool isClockwise = true)
        {
            //点Temp1
            PointF Temp1 = new PointF(pointForm.X - center.X, pointForm.Y - center.Y);
            //点Temp1到原点的长度
            double lenO2Temp1 = Distance(new PointF(0, 0), Temp1);
            //∠T1OX弧度
            double angT1OX = radPOX(Temp1.X, Temp1.Y);
            //∠T2OX弧度（T2为T1以O为圆心旋转弧度rad）
            double angT2OX = angT1OX + (isClockwise ? 1 : -1) * angle;
            //点Temp2
            PointF Temp2 = new PointF(
             (float)(lenO2Temp1 * Math.Cos(angT2OX)),
             (float)(lenO2Temp1 * Math.Sin(angT2OX)));
            //点Q
            return new PointF(Temp2.X + center.X, Temp2.Y + center.Y);
        }
        public double Distance(PointF p1, PointF p2)
        {
            return Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        }
        protected double radPOX(double x, double y)
        {
            //P在(0,0)的情况
            if (x == 0 && y == 0) return 0;
            //P在四个坐标轴上的情况：x正、x负、y正、y负
            if (y == 0 && x > 0) return 0;
            if (y == 0 && x < 0) return Math.PI;
            if (x == 0 && y > 0) return Math.PI / 2;
            if (x == 0 && y < 0) return Math.PI / 2 * 3;
            //点在第一、二、三、四象限时的情况
            if (x > 0 && y > 0) return Math.Atan(y / x);
            if (x < 0 && y > 0) return Math.PI - Math.Atan(y / -x);
            if (x < 0 && y < 0) return Math.PI + Math.Atan(-y / -x);
            if (x > 0 && y < 0) return Math.PI * 2 - Math.Atan(-y / x);
            return 0;
        }

        protected double radPOX(double angle)
        {
            return angle / 180 * Math.PI;
        }
        public void Translate(float x, float y)
        {
            this.Center = this.Center + new SizeF(x, y);
            this.Rectangle = new RectangleF(this.Rectangle.X + x, this.Rectangle.Y + y, this.Rectangle.Width, this.Rectangle.Height);// (new PointF(x, y));
        }

        public void GenLinePoints(PointF startPoint, PointF endPoint, float angle, float lineStep)
        {
            List<LineF> lineFs = new List<LineF>();
            List<PointF> pointFs = new List<PointF>();

            double perimeter = 2 * Math.PI * this.Radius * (Math.Abs(angle) / 360); // 周长
            int count = (int)Math.Ceiling(perimeter / lineStep);
            double angleStep = radPOX(angle / count);
            PointF nextStepPoint = RotatePoint(startPoint, this.Center, angleStep);
            while (Distance(startPoint, nextStepPoint) > lineStep)
            {
                count++;
                angleStep = radPOX(angle / count);
                nextStepPoint = RotatePoint(startPoint, this.Center, angleStep);
            }

            PointF fromPoint = new PointF(startPoint.X, startPoint.Y);
            for (int i = 0; i < count; i++) // 循环次数 n-1
            {
                PointF nextPoint = RotatePoint(fromPoint, this.Center, angleStep, true);
                lineFs.Add(new LineF(fromPoint.X, fromPoint.Y, nextPoint.X, nextPoint.Y, IsDottedLine));

                pointFs.Add(nextPoint);
                fromPoint = nextPoint;
            }
            lineFs.Add(new LineF(fromPoint.X, fromPoint.Y, endPoint.X, endPoint.Y, IsDottedLine));
            pointFs.Add(endPoint);

            Lines = lineFs.ToArray();
            Nodes = pointFs.ToArray();
        }

    }
}
