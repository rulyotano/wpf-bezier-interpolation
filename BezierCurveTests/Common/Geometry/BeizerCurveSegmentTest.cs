using BezierCurveSample.Common.Geometry;
using BezierCurveSample.View.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BezierCurveTests.Common.Geometry
{
    [TestClass]
    public class BeizerCurveSegmentTest
    {
        Point[] _testPoints = new[] {
            new Point(12, 33),
            new Point(1.43111111, 2),
            new Point(4, 2),
            new Point(5, 30)
        };

        [TestMethod("Should initialize the points in order Start, FirstControl, SecondControl and EndPoint")]
        public void Constructor()
        {
            var result = new BeizerCurveSegment(_testPoints[0], _testPoints[1], _testPoints[2], _testPoints[3]);
            Assert.AreEqual(_testPoints[0], result.StartPoint);
            Assert.AreEqual(_testPoints[1], result.FirstControlPoint);
            Assert.AreEqual(_testPoints[2], result.SecondControlPoint);
            Assert.AreEqual(_testPoints[3], result.EndPoint);
        }

        #region Equals
        [TestMethod("Equals shuold be true when all points")]
        public void EqualsShouldReturnTrue()
        {
            var curve1 = new BeizerCurveSegment(_testPoints[0], _testPoints[1], _testPoints[2], _testPoints[3]);
            var curve2 = new BeizerCurveSegment(_testPoints[0], _testPoints[1], _testPoints[2], _testPoints[3]);

            Assert.AreEqual(curve1, curve2);
        }

        [TestMethod("Equals shuold be false when start point is different")]
        public void EqualsShouldReturnFalseStartPoint()
        {
            var curve1 = new BeizerCurveSegment(_testPoints[0], _testPoints[1], _testPoints[2], _testPoints[3]);
            var curve2 = new BeizerCurveSegment(new Point(0, 0), _testPoints[1], _testPoints[2], _testPoints[3]);

            Assert.AreNotEqual(curve1, curve2);
        }

        [TestMethod("Equals shuold be false when first control point is different")]
        public void EqualsShouldReturnFalseControl1()
        {
            var curve1 = new BeizerCurveSegment(_testPoints[0], _testPoints[1], _testPoints[2], _testPoints[3]);
            var curve2 = new BeizerCurveSegment(_testPoints[0], new Point(0, 0), _testPoints[2], _testPoints[3]);

            Assert.AreNotEqual(curve1, curve2);
        }

        [TestMethod("Equals shuold be false when second control point is different")]
        public void EqualsShouldReturnFalseControl2()
        {
            var curve1 = new BeizerCurveSegment(_testPoints[0], _testPoints[1], _testPoints[2], _testPoints[3]);
            var curve2 = new BeizerCurveSegment(_testPoints[0], _testPoints[1], new Point(0, 0), _testPoints[3]);

            Assert.AreNotEqual(curve1, curve2);
        }

        [TestMethod("Equals shuold be false when last point is different")]
        public void EqualsShouldReturnFalseLastPoint()
        {
            var curve1 = new BeizerCurveSegment(_testPoints[0], _testPoints[1], _testPoints[2], _testPoints[3]);
            var curve2 = new BeizerCurveSegment(_testPoints[0], _testPoints[1], _testPoints[2], new Point(0, 0));

            Assert.AreNotEqual(curve1, curve2);
        }

        [TestMethod("Equals shuold be false when any other type")]
        public void EqualsShouldReturnFalseOtherType()
        {
            var curve1 = new BeizerCurveSegment(_testPoints[0], _testPoints[1], _testPoints[2], _testPoints[3]);

            Assert.AreNotEqual(curve1, "");
        }
        #endregion
    }
}
