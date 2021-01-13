using BezierCurveSample.Common;
using BezierCurveSample.Common.Geometry;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BezierCurveTests.Common.Geometry
{

    [TestClass]
    public class PointTests
    {
        const double FakeX = 3.4;
        const double FakeY = 9.3;

        [TestMethod("Constructor should initialize x and y")]
        public void Constructor()
        {
            var newPoint = new Point(FakeX, FakeY);

            Assert.AreEqual(FakeX, newPoint.X);
            Assert.AreEqual(FakeY, newPoint.Y);
        }

        [TestMethod("Euclidean should give results according to Sqrt(dx^2 + dy^2)")]
        [DataRow(0, 0, 3, 3)]
        [DataRow(1, 7, 1, 7)]
        [DataRow(1, 0.9, 20, 7)]
        [DataRow(0, 0, 10, 0)]
        [DataRow(-10, 5, 5, 8)]
        [DataRow(3, 0.54544, 1, 9)]
        [DataTestMethod]
        public void EuclideanDistance(double x1, double y1, double x2, double y2)
        {
            var point1 = new Point(x1, y1);
            var point2 = new Point(x2, y2);

            var expected = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1)); ;
            Assert.IsTrue(Numerics.DoubleEquals(expected, point1.EuclideanDistance(point2)));
        }

        [TestMethod]
        [DataRow(0, 1, 0, 1, true)]
        [DataRow(2, 1, 0, 1, false)]
        [DataRow(0, 1, 2, 1, false)]
        [DataRow(0, 2, 0, 1, false)]
        [DataRow(0, 1, 0, 2, false)]
        [DataRow(0.000000001, 1.000000001, 0, 1, true)]
        public void ShouldEqualsWhenSameValues(double x1, double y1, double x2, double y2, bool expected)
        {
            Assert.AreEqual(expected, new Point(x1, y1).Equals(new Point(x2, y2)));
        }
    }
}
