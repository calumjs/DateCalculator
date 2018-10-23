using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DateCalculator;

namespace DateCalculatorTest
{
    

    [TestClass]
    public class DateCalculatorTest
    {
        public DateCalculator.DateCalculator dateCalculator;
        [TestInitialize]
        public void InitialiseTests()
        {
            dateCalculator = new DateCalculator.DateCalculator();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "EXPECTED - Date string: 2018-10-23 does not match regex pattern")]
        public void InvalidFormatTest()
        {
            dateCalculator.CreateDateFromDateString("2018-10-23");
        }
        [TestMethod]
        public void TestsFromProgrammingExerciseDefinition()
        {
            Assert.AreEqual(dateCalculator.GetDaysBetweenTwoDates("02/06/1983", "22/06/1983"), 19);
            Assert.AreEqual(dateCalculator.GetDaysBetweenTwoDates("04/07/1984", "25/12/1984"), 173); //Specification said 179, but that seems to be an typo...
            Assert.AreEqual(dateCalculator.GetDaysBetweenTwoDates("03/01/1989", "03/08/1983"), 1979);
            Assert.AreEqual(dateCalculator.GetDaysBetweenTwoDates("03/08/1983", "03/01/1989"), 1979);
        }
        [TestMethod]
        public void MoreTests()
        {
            Assert.AreEqual(dateCalculator.GetDaysBetweenTwoDates("01/01/1901", "31/12/2999"), 401400);
            Assert.AreEqual(dateCalculator.GetDaysBetweenTwoDates("31/12/2999", "01/01/1901"), 401400);
        }
    }
}
