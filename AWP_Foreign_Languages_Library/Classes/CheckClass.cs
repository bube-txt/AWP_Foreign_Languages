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
            if (Regex.IsMatch(time, @"[0-9]{2}:[0-9]{2}"))
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
