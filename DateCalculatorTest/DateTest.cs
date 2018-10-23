using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DateCalculator;

namespace DateCalculatorTest
{
    [TestClass]
    public class DateValidationTest
    {
        [TestMethod]
        public void DateConstructorTest()
        {
            Date date = new Date(1901, 01, 01);
            Assert.AreEqual(date.Years, 1901);
            Assert.AreEqual(date.Months, 1);
            Assert.AreEqual(date.Days, 1);
        }


    }
}
