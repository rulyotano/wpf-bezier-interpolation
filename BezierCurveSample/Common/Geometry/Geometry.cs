using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BezierCurveSample.Common.Geometry
{
    public static class Geometry
    {
        public static double EuclideanDistance(Point point1, Point point2)
        {
            var xDiff = point2.X - point1.X;
            var yDiff = point2.Y - point1.Y;
            return Math.Sqrt(xDiff * xDiff + yDiff * yDiff);
        }

        public static double EuclideanDistance(double x1, double y1, double x2, double y2)
        {
            var xDiff = x2 - x1;
            var yDiff = y2 - y1;
            return Math.Sqrt(xDiff * xDiff + yDiff * yDiff);
        }

        public static double Middle(double value1, double value2)
        {
            return (value1 + value2) / 2.0;
        }
    }
}
