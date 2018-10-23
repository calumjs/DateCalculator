using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                DateCalculator dateCalculator = new DateCalculator();
                Console.WriteLine("Enter two dates separated by a space (e.g. dd/mm/yyyy dd/mm/yyyy) or just hit enter to stop:");
                string dates = Console.ReadLine();
                string[] splitDates = dates.Split(' ');
                if (dates == String.Empty || splitDates.Length != 2)
                {
                    break;
                }
                string dateOne = splitDates[0],
                       dateTwo = splitDates[1];
                try
                {
                    int days = dateCalculator.GetDaysBetweenTwoDates(dateOne, dateTwo);
                    Console.WriteLine(String.Format("{0} day(s) between {1} and {2}.", days, dateOne, dateTwo));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
