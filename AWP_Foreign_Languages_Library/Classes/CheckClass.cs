using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AWP_Foreign_Languages_Library.Classes
{
    public class CheckClass
    {
        public static bool TimeCheck(string time)
        {
            bool result = TimeSpan.TryParse(time, out TimeSpan timeSpan);
            if (timeSpan < new TimeSpan(24, 0, 0) & timeSpan > new TimeSpan(0, 0, 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
