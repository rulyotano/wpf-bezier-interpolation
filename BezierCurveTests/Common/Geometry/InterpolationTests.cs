using BezierCurveSample.Common.Geometry;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace BezierCurveTests.Common.Geometry
{
    [TestClass]
    public class InterpolationTests
    {
        #region PoinsToBeizerCurves
        private Point[] samplePoints1 = new[] { new Point(0, 0), new Point(300, -100), new Point(15, 66) };

        [TestMethod("InterpolatePointWithBeizerCurves should begins and ends in initial and ending points")]
        public void InterpolatePointWithBeizerCurvesShouldStartAndEndsSamePoints()
        {
            var result = Interpolation.PoinsToBeizerCurves(samplePoints1.ToList(), false);

            Assert.AreEqual(samplePoints1.First(), result.First().StartPoint);
            Assert.AreEqual(samplePoints1.Last(), result.Last().EndPoint);
        }

        [TestMethod("InterpolatePointWithBeizerCurves when closed curve should ends with start point")]
        public void InterpolatePointWithBeizerCurvesWhenClosedShouldEndWithStartPoint()
        {
            var result = Interpolation.PoinsToBeizerCurves(samplePoints1.ToList(), true);

            Assert.AreEqual(samplePoints1.First(), result.First().StartPoint);
            Assert.AreEqual(samplePoints1.First(), result.Last().EndPoint);
        }

        [TestMethod("InterpolatePointWithBeizerCurves when less than 3 points should return null")]
        public void InterpolatePointWithBeizerCurvesWhenLLessThan3PointsShouldReturnNull()
        {
            var result = Interpolation.PoinsToBeizerCurves(samplePoints1.Take(2).ToList(), false);

            Assert.IsNull(result);
        }

        private void RunTestCase(TestCase testCase)
        {
            var result = testCase.Smooth.HasValue
                ? Interpolation.PoinsToBeizerCurves(testCase.InputPoints, testCase.IsClosed, testCase.Smooth.Value)
                : Interpolation.PoinsToBeizerCurves(testCase.InputPoints, testCase.IsClosed);

            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(testCase.ExpectedOutput[i], result[i]);
            }
        }

        [TestMethod("Test case 1. Open")]
        public void TestCase1ShouldReturnSameResult()
        {
            var testCase = TestData.TestCas1;
            RunTestCase(testCase);
        }

        [TestMethod("Test case 2. Closed")]
        public void TestCase2ShouldReturnSameResult()
        {
            var testCase = TestData.TestCas2;
            RunTestCase(testCase);
        }

        [TestMethod("Test case 3. Smooth value.")]
        public void TestCase3ShouldReturnSameResult()
        {
            var testCase = TestData.TestCas3;
            RunTestCase(testCase);
        }
        #endregion

        #region BestPlaceToInsert

        [TestMethod("BestPlaceToInsert - Should insert at start when array is empty")]
        public void BestPlaceToInsertInsertAtStart()
        {
            var newPoint = new Point(3, 4);
            var list = new List<Point>();

            var result = Interpolation.BestPlaceToInsert(newPoint, list);
            Assert.AreEqual(0, result);
        }

        [TestMethod("BestPlaceToInsert - Should insert at the end when array has one item")]
        public void BestPlaceToInsertInsertAtTheEndWhenOnlyOne()
        {
            var newPoint = new Point(3, 4);
            var list = new List<Point> { new Point(10, 5) };

            var result = Interpolation.BestPlaceToInsert(newPoint, list);
            Assert.AreEqual(1, result);
        }

        [TestMethod("BestPlaceToInsert - when two items and nearest to first, insert at start")]
        public void BestPlaceToInsertInsertAtStartWhenTwoItems()
        {
            var newPoint = new Point(3, 0);
            var list = new List<Point> { new Point(10, 0), new Point(50, 0) };

            var result = Interpolation.BestPlaceToInsert(newPoint, list);
            Assert.AreEqual(0, result);
        }

        [TestMethod("BestPlaceToInsert - when two items and nearest to the latest, insert at end")]
        public void BestPlaceToInsertInsertAtMiddleWhenTwoItems()
        {
            var newPoint = new Point(70, 0);
            var list = new List<Point> { new Point(40, 0), new Point(50, 0) };

            var result = Interpolation.BestPlaceToInsert(newPoint, list);
            Assert.AreEqual(list.Count, result);
        }


        [TestMethod("BestPlaceToInsert - when four items and nearest, insert at correct index")]
        public void BestPlaceToInsertInsertAtMiddleWhenFourItems()
        {
            var newPoint = new Point(45, 0);
            var list = new List<Point> { new Point(38, 0), new Point(39, 0), new Point(40, 0), new Point(50, 0) };

            var result = Interpolation.BestPlaceToInsert(newPoint, list);
            Assert.AreEqual(3, result);
        }

        #endregion
    }
}
