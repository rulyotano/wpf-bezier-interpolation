using BezierCurveSample.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BezierCurveTests.Common
{
    [TestClass]
    public class NumericTests
    {

        [TestMethod("FloatEquals should return true when less than epsilon and false otherwise")]
        [DataRow(0.345f, 0.34500000001f, true)]
        [DataRow(0.345f, 0.347f, false)]
        [DataRow(1.345f, 1.3f, false)]
        [DataRow(0.3f, 0.3f, true)]
        [DataRow(float.PositiveInfinity, float.PositiveInfinity, true)]
        [DataRow(float.NegativeInfinity, float.NegativeInfinity, true)]
        [DataRow(float.NaN, float.NaN, true)]
        [DataTestMethod]
        public void FloatEqualsWhenEquals(float n1, float n2, bool expected)
        {
            Assert.AreEqual(expected, Numeric.FloatEquals(n1, n2));
            Assert.AreEqual(expected, Numeric.FloatEquals(n1, n2, Numeric.Epsilon));
        }

        [TestMethod("DoubleEquals should return true when less than epsilon and false otherwise")]
        [DataRow(0.345, 0.34500000001, true)]
        [DataRow(0.345, 0.347, false)]
        [DataRow(1.345, 1.3, false)]
        [DataRow(0.3, 0.3, true)]
        [DataRow(double.PositiveInfinity, double.PositiveInfinity, true)]
        [DataRow(double.NegativeInfinity, double.NegativeInfinity, true)]
        [DataRow(double.NaN, double.NaN, true)]
        [DataTestMethod]
        public void DoubleEqualsWhenEquals(double n1, double n2, bool expected)
        {
            Assert.AreEqual(expected, Numeric.DoubleEquals(n1, n2));
            Assert.AreEqual(expected, Numeric.DoubleEquals(n1, n2, Numeric.Epsilon));
        }

        [TestMethod("RadianToDegreeConvert should return according to (180*radian)/PI")]
        [DataRow(3)]
        [DataRow(1)]
        [DataRow(0.6f)]
        [DataRow(0.2f)]
        [DataTestMethod]
        public void RadianToDegreeConvertShouldReturnAccordingToFormula(float n)
        {
            var expected = (float)((n * 180) / Math.PI);
            Assert.IsTrue(Numeric.FloatEquals(expected, Numeric.RadianToDegreeConvert(n)));
        }

        [TestMethod("DegreeToRadianConvert should return according to (degree*PI)/180")]
        [DataRow(180)]
        [DataRow(90)]
        [DataRow(30)]
        [DataRow(0.5)]
        [DataRow(330)]
        [DataTestMethod]
        public void DegreeToRadianConvertShouldReturnAccordingToFormula(double n)
        {
            var expected = (n * Math.PI) / 180f;
            Assert.IsTrue(Numeric.DoubleEquals(expected, Numeric.DegreeToRadianConvert(n)));
        }
    }
}
