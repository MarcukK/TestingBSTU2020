using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnit
{
    public static class Triangle
    {
        public static bool CreateTriangle(double x, double y, double z)
        {
            return ((((x + y) > z) && ((x + z) > y) && ((z + y) > x)));
        }
        public static bool IsTwoSidesEqual(double x, double y, double z)
        {
            return (x == y || x == z || y == z) && CreateTriangle(x, y, z);
        }
        public static bool IsAllSidesEqual(double x, double y, double z)
        {
            return (x == y && y == z) && (x > 0);
        }
    }
}
