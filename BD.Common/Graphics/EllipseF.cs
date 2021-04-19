using System;
using System.Collections.Generic;
using System.Drawing;

namespace BD.Common
{
    public class EllipseF : CircleBase
    {
        public EllipseF(PointF point, SizeF size, bool isDottedLine)
        {
            this._Rectangle = new RectangleF() { Location = point, Size = size };
            this.IsDottedLine = isDottedLine;
            this._Radius = size.Width / 2;
            this._Center = new PointF(point.X + this._Radius, point.Y + this._Radius);
            this.SetScale(1f);
        }

        public EllipseF(float x, float y, float width, float height, bool isDottedLine)
            : this(new PointF(x, y), new SizeF(width, height), isDottedLine)
        {
        }

        /// <summary>
        /// 将圆拆分成多条线段
        /// </summary>
        /// <param name="lineStep">线条的长度</param>
        /// <returns></returns>
        public override void ReflushLinePoints(float lineStep)
        {
            GenLinePoints(new PointF(this.Rectangle.X, this.Center.Y), new PointF(this.Rectangle.X, this.Center.Y), 360, lineStep);


            //List<LineF> lineFs = new List<LineF>();
            //List<PointF>  pointFs = new List<PointF>();

            //PointF startPoint = new PointF(this.Rectangle.X, this.Center.Y);
            //PointF fromPoint = new PointF(this.Rectangle.X, this.Center.Y);
            
            //pointFs.Add(startPoint);
            //float angle = 2 * (float)(Math.Asin(((double)lineStep / 2) / Radius));
            //int count = (int)(2 * Math.PI / angle);
            //int yushu = (int)Math.Round((2 * Math.PI % angle));
            //for (int i = 0; i < count; i++) // 循环次数 n-1
            //{
            //    PointF nextPoint = RotatePoint(fromPoint,this.Center, angle, true);
            //    lineFs.Add(new LineF(fromPoint.X, fromPoint.Y, nextPoint.X, nextPoint.Y, IsDottedLine));

            //    pointFs.Add(nextPoint);
            //    fromPoint = nextPoint;
            //}
            //if(yushu > 0)
            //{
            //    lineFs.Add(new LineF(fromPoint.X, fromPoint.Y, startPoint.X, startPoint.Y, IsDottedLine));

            //    pointFs.Add(startPoint);
            //}

            //Lines= lineFs.ToArray();
            //Nodes = pointFs.ToArray();
        }

        
    }
}
