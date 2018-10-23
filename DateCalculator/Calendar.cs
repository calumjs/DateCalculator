using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateCalculator
{
    public static class Calendar 
    {
        public const int MINIMUM_YEAR = 1901,
                          MAXIMUM_YEAR = 2999;

        public static Date GetDateFromYearMonthDay(int year, int month, int day)
        {
            if (!Calendar.ValidateYear(year))
            {
                throw new ArgumentException(String.Format("Year: {0} is invalid - should be within range {1}-{2}", year, MINIMUM_YEAR, MAXIMUM_YEAR));
            }
            if (!Calendar.ValidateMonth(month))
            {
                throw new ArgumentException(String.Format("Month: {0} is invalid - should be within range 1-12", month));
            }
            if (!Calendar.ValidateDay(day, month, year))
            {
                throw new ArgumentException(String.Format("Day: {0} is invalid - should be within range 1-{1}", day, GetDaysInMonth(month, year)));
            }
            return new Date(year, month, day);
        }

        public static bool ValidateYear(int year)
        {
            return year >= MINIMUM_YEAR && year <= MAXIMUM_YEAR;  //Validation pushed into Calendar because minimum and maximum years are arbitrarily defined and not inherently part of a Date
        }

        public static bool ValidateMonth(int month)
        {
            return month >= 1 && month <= 12;
        }

        public static bool ValidateDay(int day, int month, int year)
        {
            return day >= 1 && day <= GetDaysInMonth(month, year);
        }

        public static bool IsLeapYear(int year)
        {
            return year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
        }

        public static int GetDaysInMonth(int month, int year)
        {
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                case 2:
                    return IsLeapYear(year) ? 29 : 28;
                default:
                    throw new ArgumentException("Month {0} should be between 1-12");
            }
        }

        public static int GetDaysInYear(int year)
        {
            return IsLeapYear(year) ? 366 : 365;
        }

        public static int GetDaysLeftInMonth(Date date)
        {
            return GetDaysInMonth(date.Months, date.Years) - date.Days;
        }

        public static int GetDaysLeftInYear(Date date)
        {
            int days = GetDaysInMonth(date.Months, date.Years) - date.Days;
            for (int m = date.Months + 1; m <= 12; m++)
            {
                days += GetDaysInMonth(m, date.Years);
            }
            return days;
        }

        public static int GetDaysElapsedInYear(Date date)
        {
            int days = date.Days - 1;
            for (int m = date.Months - 1; m >= 1; m--)
            {
                days += GetDaysInMonth(m, date.Years);
            }
            return days;
        }

        public static int GetHowManyDaysAfter(Date dateOne, Date dateTwo)
        {
            int daysInBetween = 0;
            if (dateTwo == dateOne)
            {
                return 0;
            }
            if (dateTwo > dateOne)
            {
                if (dateTwo.Years > dateOne.Years)
                {
                    for (int yearCounter = dateOne.Years + 1; yearCounter < dateTwo.Years; yearCounter++)
                    {
                        daysInBetween += GetDaysInYear(yearCounter);
                    }
                    daysInBetween += GetDaysElapsedInYear(dateTwo) + GetDaysLeftInYear(dateOne);
                    return daysInBetween;
                }
                else
                {
                    daysInBetween += GetDaysElapsedInYear(dateTwo) - GetDaysElapsedInYear(dateOne) - 1;
                    return daysInBetween;
                }
            }
            else
            {
                return -GetHowManyDaysAfter(dateTwo, dateOne);
            }
        }
    }
}
