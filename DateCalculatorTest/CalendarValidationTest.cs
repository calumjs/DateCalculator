using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DateCalculator;

namespace DateCalculatorTest
{
    [TestClass]
    public class CalendarValidationTest
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "EXPECTED - Year: 1900 is invalid - should be within range 1901-2999")]
        public void LowInvalidYearTest()
        {
            Date date = Calendar.GetDateFromYearMonthDay(1900, 1, 1);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "EXPECTED - Year: 3000 is invalid - should be within range 1901-2999")]
        public void HighInvalidYearTest()
        {
            Date date = Calendar.GetDateFromYearMonthDay(3000, 1, 1);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "EXPECTED - Month: 0 is invalid - should be within range 1-12")]
        public void LowInvalidMonthTest()
        {
            Date date = Calendar.GetDateFromYearMonthDay(2018, 0, 1);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "EXPECTED - Month: 13 is invalid - should be within range 1-12")]
        public void HighInvalidMonthTest()
        {
            Date date = Calendar.GetDateFromYearMonthDay(2018, 13, 1);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "EXPECTED - Day: 0 is invalid - should be within range 1-31")]
        public void LowInvalidDayTest()
        {
            Date date = Calendar.GetDateFromYearMonthDay(2018, 1, 0);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "EXPECTED - Day: 29 is invalid - should be within range 1-28")]
        public void HighInvalidDayTest()
        {
            Date date = Calendar.GetDateFromYearMonthDay(2018, 2, 29);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "EXPECTED - Day: 31 is invalid - should be within range 1-30")]
        public void HighInvalidDay2Test()
        {
            Date date = Calendar.GetDateFromYearMonthDay(2018, 4, 31);
        }
        [TestMethod]
        public void LeapYearTest()
        {
            Date date = Calendar.GetDateFromYearMonthDay(2016, 2, 29);
            Assert.AreEqual(date.Years, 2016);
            Assert.AreEqual(date.Months, 2);
            Assert.AreEqual(date.Days, 29);
            Date date2 = Calendar.GetDateFromYearMonthDay(2000, 2, 29);
            Assert.AreEqual(date2.Years, 2000);
            Assert.AreEqual(date2.Months, 2);
            Assert.AreEqual(date2.Days, 29);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "EXPECTED - Day: 29 is invalid - should be within range 1-28")]
        public void NoLeapYearOnMultiplesOf100Test()
        {
            Date date = Calendar.GetDateFromYearMonthDay(2100, 2, 29);
        }
    }
}
