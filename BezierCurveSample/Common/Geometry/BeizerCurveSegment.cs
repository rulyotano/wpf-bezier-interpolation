using BezierCurveSample.Common.Geometry;

namespace BezierCurveSample.View.Utils
{
    public class BeizerCurveSegment
    {
        public const double ERROR = 0.1;

        public BeizerCurveSegment()
        {

        }

        public BeizerCurveSegment(Point startPoint, Point firstControlPoint, Point secondControlPoint, Point endPoint)
        {
            StartPoint = startPoint;
            FirstControlPoint = firstControlPoint;
            SecondControlPoint = secondControlPoint;
            EndPoint = endPoint;
        }

        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public Point FirstControlPoint { get; set; }
        public Point SecondControlPoint { get; set; }

        public override bool Equals(object obj)
        {
            var otherCurve = obj as BeizerCurveSegment;
            if (otherCurve == null)
                return false;

            return otherCurve.StartPoint.Equals(StartPoint) 
                && otherCurve.FirstControlPoint.Equals(FirstControlPoint) 
                && otherCurve.SecondControlPoint.Equals(SecondControlPoint) 
                && otherCurve.EndPoint.Equals(EndPoint);
        }
    }
}
