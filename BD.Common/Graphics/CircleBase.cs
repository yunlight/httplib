using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD.Common
{
    public abstract class CircleBase
    {
        public float Scale { get; set; }

        public RectangleF Rectangle { get; protected set; }

        public float Radius { get; protected set; }

        public PointF Center { get; protected set; } 
        public bool IsDottedLine { get; protected set; }

        public abstract void ReflushLinePoints(float lineStep);

        /// <summary>
        /// 绕圆心旋转一定角度后的点坐标
        /// </summary>
        /// <param name="pointForm"></param>
        /// <param name="center"></param>
        /// <param name="rad"></param>
        /// <param name="isClockwise"></param>
        /// <returns></returns>
        protected PointF RotatePoint(PointF pointForm, PointF center, double rad, bool isClockwise = true)
        {
            //点Temp1
            PointF Temp1 = new PointF(pointForm.X - center.X, pointForm.Y - center.Y);
            //点Temp1到原点的长度
            double lenO2Temp1 = Distance(new PointF(0, 0), Temp1);
            //∠T1OX弧度
            double angT1OX = radPOX(Temp1.X, Temp1.Y);
            //∠T2OX弧度（T2为T1以O为圆心旋转弧度rad）
            double angT2OX = angT1OX + (isClockwise ? 1 : -1) * rad;
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
            this.Center = this.Center + new SizeF(x,y);
            this.Rectangle = new RectangleF(this.Rectangle.X +x, this.Rectangle.Y + y, this.Rectangle.Width, this.Rectangle.Height);// (new PointF(x, y));
        }

    }
}
