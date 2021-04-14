using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD.Common
{
    public static class Utils
    {
        public static float minStep = 0.1f;

        public static float Min(float v1, float v2)
        {
            if (v1 < v2) return v1;
            else return v2;
        }
        public static float Max(float v1, float v2)
        {
            if (v1 > v2) return v1;
            else return v2;
        }
    }
}
