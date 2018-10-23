using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DateCalculator
{
    public class Date : IComparable<Date>
    {
        public int Days { get; set; }
        public int Months { get; set; }
        public int Years { get; set; }

        public Date(int year, int month, int day)
        {
            this.Years = year;
            this.Months = month;
            this.Days = day;
        }

        public int CompareTo(Date other)
        {
            if (this.Years < other.Years)
            {
                return -1;
            }
            else if (this.Years > other.Years)
            {
                return 1;
            }
            else if (this.Months < other.Months)
            {
                return -1;
            }
            else if (this.Months > other.Months)
            {
                return 1;
            }
            else if (this.Days < other.Days)
            {
                return -1;
            }
            else if (this.Days > other.Days)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }


        public static bool operator <(Date one, Date two)
        {
            return one.CompareTo(two) < 0;
        }
        public static bool operator >(Date one, Date two)
        {
            return two.CompareTo(one) < 0;
        }
        public static bool operator ==(Date one, Date two)
        {
            return one.CompareTo(two) == 0;
        }
        public static bool operator !=(Date one, Date two)
        {
            return one.CompareTo(two) != 0;
        }
    }
}
