using BezierCurveSample.Common.Geometry;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
