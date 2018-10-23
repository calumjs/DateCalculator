using System;
using DateCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DateCalculatorTest
{
    [TestClass]
    public class DateOperatorTest
    {
        [TestMethod]
        public void GreaterThanLessThanTest()
        {
            Date d1 = new Date(2018, 1, 15);
            Date d2 = new Date(2018, 1, 16);
            Date d3 = new Date(2018, 2, 14);
            Date d4 = new Date(2019, 3, 13);
            Date d5 = new Date(2019, 4, 13);
            Date d6 = new Date(2020, 4, 13);
            Date d7 = new Date(2020, 4, 13);

            Assert.IsTrue(d2 > d1);
            Assert.IsTrue(d3 > d2);
            Assert.IsTrue(d4 > d3);
            Assert.IsTrue(d5 > d4);
            Assert.IsTrue(d6 > d5);
            Assert.IsFalse(d7 > d6);
            Assert.IsFalse(d2 < d1);
            Assert.IsFalse(d3 < d2);
            Assert.IsFalse(d4 < d3);
            Assert.IsFalse(d5 < d4);
            Assert.IsFalse(d6 < d5);
            Assert.IsFalse(d7 < d6);
        }
        [TestMethod]
        public void EqualsNotEqualsTest()
        {
            Date d1 = new Date(2018, 1, 15);
            Date d2 = new Date(2018, 1, 15);
            Date d3 = new Date(2018, 1, 16);
            Assert.IsTrue(d1 == d2);
            Assert.IsTrue(d1 != d3);
        }


    }
}
