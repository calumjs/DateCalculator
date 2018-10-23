using System;
using DateCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DateCalculatorTest
{
    [TestClass]
    public class CalendarDayCountingTest
    {
        [TestMethod]
        public void DaysLeftInMonthTest()
        {
            Date d1 = Calendar.GetDateFromYearMonthDay(2018, 1, 1);
            Assert.AreEqual(Calendar.GetDaysLeftInMonth(d1), 30);
            Date d2 = Calendar.GetDateFromYearMonthDay(2018, 1, 31);
            Assert.AreEqual(Calendar.GetDaysLeftInMonth(d2), 0);
            Date d3 = Calendar.GetDateFromYearMonthDay(2016, 2, 14);
            Assert.AreEqual(Calendar.GetDaysLeftInMonth(d3), 15);
            Date d4 = Calendar.GetDateFromYearMonthDay(2016, 11, 1);
            Assert.AreEqual(Calendar.GetDaysLeftInMonth(d4), 29);
        }
        [TestMethod]
        public void DaysLeftInYearTest()
        {
            Date d1 = Calendar.GetDateFromYearMonthDay(2018, 1, 1);
            Assert.AreEqual(Calendar.GetDaysLeftInYear(d1), 364);
            Date d2 = Calendar.GetDateFromYearMonthDay(2018, 12, 31);
            Assert.AreEqual(Calendar.GetDaysLeftInYear(d2), 0);
            Date d3 = Calendar.GetDateFromYearMonthDay(2018, 10, 1);
            Assert.AreEqual(Calendar.GetDaysLeftInYear(d3), 91);
        }
        [TestMethod]
        public void DaysPassedInYearTest()
        {
            Date d1 = Calendar.GetDateFromYearMonthDay(2018, 1, 1);
            Assert.AreEqual(Calendar.GetDaysElapsedInYear(d1), 0);
            Date d2 = Calendar.GetDateFromYearMonthDay(2018, 12, 31);
            Assert.AreEqual(Calendar.GetDaysElapsedInYear(d2), 364);
            Date d3 = Calendar.GetDateFromYearMonthDay(2018, 10, 1);
            Assert.AreEqual(Calendar.GetDaysElapsedInYear(d3), 273);
        }
    }
}
