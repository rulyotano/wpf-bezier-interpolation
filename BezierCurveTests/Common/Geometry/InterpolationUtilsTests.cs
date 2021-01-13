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
    public class InterpolationUtilsTests
    {
        private Point[] samplePoints1 = new[] { new Point(0, 0), new Point(300, -100), new Point(15, 66) };

        [TestMethod("InterpolatePointWithBeizerCurves shuold begins and ends in initial and ending points")]
        public void InterpolatePointWithBeizerCurvesShouldStartAndEndsSamePoints()
        {
            var result = InterpolationUtils.InterpolatePointWithBeizerCurves(samplePoints1.ToList(), false);

            Assert.AreEqual(samplePoints1.First(), result.First().StartPoint);
            Assert.AreEqual(samplePoints1.Last(), result.Last().EndPoint);
        }

        [TestMethod("InterpolatePointWithBeizerCurves when closed curve shuold ends with start point")]
        public void InterpolatePointWithBeizerCurvesWhenClosedShouldEndWithStartPoint()
        {
            var result = InterpolationUtils.InterpolatePointWithBeizerCurves(samplePoints1.ToList(), true);

            Assert.AreEqual(samplePoints1.First(), result.First().StartPoint);
            Assert.AreEqual(samplePoints1.First(), result.Last().EndPoint);
        }

        [TestMethod("InterpolatePointWithBeizerCurves when less than 3 points shuold return null")]
        public void InterpolatePointWithBeizerCurvesWhenLLessThan3PointsShouldReturnNull()
        {
            var result = InterpolationUtils.InterpolatePointWithBeizerCurves(samplePoints1.Take(2).ToList(), false);

            Assert.IsNull(result);
        }

        [TestMethod("Test case 1")]
        public void TestCase1ShouldReturnSameResult()
        {
            var testCase = TestData.TestCas1;
            var result = InterpolationUtils.InterpolatePointWithBeizerCurves(testCase.InputPoints, testCase.IsClosed);

            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(testCase.ExpectedOutput[i], result[i]);
            }
        }

    }
}
