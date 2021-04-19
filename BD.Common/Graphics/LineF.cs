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
         
        public void Translate(float x, float y)
        {
            this.StartPoint = this.StartPoint + new SizeF(x, y);
            this.EndPoint = this.EndPoint + new SizeF(x, y);
        }
    }
}
