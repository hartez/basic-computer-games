using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weekday
{
    internal static class Input
    {
        public static DateTime GetDate(string prompt) 
        {
            DateTime result;
            string dateInput;

            do
            {
                Console.WriteLine(prompt);
                dateInput = Console.ReadLine() ?? "";
            }
            while (!DateTime.TryParseExact(dateInput, "M,d,yyyy", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out result));

            return result;
        }
    }
}
