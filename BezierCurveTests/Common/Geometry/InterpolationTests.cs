using BezierCurveSample.Common.Geometry;
using BezierCurveSample.View.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BezierCurveTests.Common.Geometry
{
    [TestClass]
    public class InterpolationTests
    {
        private Point[] samplePoints1 = new[] { new Point(0, 0), new Point(300, -100), new Point(15, 66) };

        [TestMethod("InterpolatePointWithBeizerCurves shuold begins and ends in initial and ending points")]
        public void InterpolatePointWithBeizerCurvesShouldStartAndEndsSamePoints()
        {
            var result = Interpolation.InterpolatePointWithBeizerCurves(samplePoints1.ToList(), false);

            Assert.AreEqual(samplePoints1.First(), result.First().StartPoint);
            Assert.AreEqual(samplePoints1.Last(), result.Last().EndPoint);
        }

        [TestMethod("InterpolatePointWithBeizerCurves when closed curve shuold ends with start point")]
        public void InterpolatePointWithBeizerCurvesWhenClosedShouldEndWithStartPoint()
        {
            var result = Interpolation.InterpolatePointWithBeizerCurves(samplePoints1.ToList(), true);

            Assert.AreEqual(samplePoints1.First(), result.First().StartPoint);
            Assert.AreEqual(samplePoints1.First(), result.Last().EndPoint);
        }

        [TestMethod("InterpolatePointWithBeizerCurves when less than 3 points shuold return null")]
        public void InterpolatePointWithBeizerCurvesWhenLLessThan3PointsShouldReturnNull()
        {
            var result = Interpolation.InterpolatePointWithBeizerCurves(samplePoints1.Take(2).ToList(), false);

            Assert.IsNull(result);
        }

        private void RunTestCase(TestCase testCase)
        {
            var result = testCase.Smooth.HasValue
                ? Interpolation.InterpolatePointWithBeizerCurves(testCase.InputPoints, testCase.IsClosed, testCase.Smooth.Value)
                : Interpolation.InterpolatePointWithBeizerCurves(testCase.InputPoints, testCase.IsClosed);

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

    }
}
