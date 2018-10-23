using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DateCalculator
{
    public class DateCalculator
    {
        public int GetDaysBetweenTwoDates(string dateOne, string dateTwo)
        {
            int directionalDaysBetweenDates = Calendar.GetHowManyDaysAfter(CreateDateFromDateString(dateOne), CreateDateFromDateString(dateTwo));
            int absoluteDaysBetweenDates = Math.Abs(directionalDaysBetweenDates);
            return absoluteDaysBetweenDates;
        }

        public Date CreateDateFromDateString(string dateString)
        {
            ValidateDateStringFormat(dateString);

            int[] dateComponents = dateString.Split('/').Select(dateComponent => int.Parse(dateComponent)).ToArray();
            int year = dateComponents[2],
                month = dateComponents[1],
                day = dateComponents[0];

            return Calendar.GetDateFromYearMonthDay(year, month, day);
        }

        private bool ValidateDateStringFormat(string date)
        {
            //Could improve on this pattern to catch more cases, but coding leap years etc into the regex is gonna be nearly impossible so further validation required later anyway...
            //And we can provide clearer error messages too
            Regex dateRegex = new Regex(@"^\d\d\/\d\d\/\d\d\d\d$"); 
            if (!dateRegex.IsMatch(date))
            {
                throw new System.ArgumentException(String.Format("Date string: {0} does not match regex pattern", date));
            }
            return true;
        }

    }
}
