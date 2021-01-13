using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BezierCurveSample.Common.Geometry
{
    public class Point
    {
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public double EuclideanDistance(Point other)
        {
            var xDiff = other.X - X;
            var yDiff = other.Y - Y;
            return Math.Sqrt(xDiff * xDiff + yDiff * yDiff);
        }

        public override bool Equals(object obj)
        {
            var point = obj as Point;

            return Numerics.DoubleEquals(X, point.X) && Numerics.DoubleEquals(Y, point.Y);
        }
    }
}
