using BezierCurveSample.Common;
using BezierCurveSample.Common.Geometry;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BezierCurveTests.Common.Geometry
{
    [TestClass]
    public class GeometryTest
    {
        [TestMethod("Euclidean should give results according to Sqrt(dx^2 + dy^2)")]
        [DataRow(0, 0, 3, 3)]
        [DataRow(1, 7, 1, 7)]
        [DataRow(1, 0.9, 20, 7)]
        [DataRow(0, 0, 10, 0)]
        [DataRow(-10, 5, 5, 8)]
        [DataRow(3, 0.54544, 1, 9)]
        public void EuclideanDistance(double x1, double y1, double x2, double y2)
        {
            var point1 = new Point(x1, y1);
            var point2 = new Point(x2, y2);

            var expected = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1)); ;
            Assert.IsTrue(Numeric.DoubleEquals(expected, BezierCurveSample.Common.Geometry.Geometry.EuclideanDistance(point1, point2)));
            Assert.IsTrue(Numeric.DoubleEquals(expected, BezierCurveSample.Common.Geometry.Geometry.EuclideanDistance(x1, y1, x2, y2)));
        }

        [TestMethod("Middle value, should return it")]
        [DataRow(0, 1)]
        [DataRow(3, 9)]
        [DataRow(2.5, 6.5)]
        public void Middle(double value1, double value2)
        {
            var expected = (value1 + value2) / 2.0;
            Assert.IsTrue(Numeric.DoubleEquals(expected, BezierCurveSample.Common.Geometry.Geometry.Middle(value1, value2)));
        }
    }
}
