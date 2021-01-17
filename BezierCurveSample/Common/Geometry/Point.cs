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

        public override bool Equals(object obj)
        {
            var point = obj as Point;

            return Numeric.DoubleEquals(X, point.X) && Numeric.DoubleEquals(Y, point.Y);
        }
    }
}
