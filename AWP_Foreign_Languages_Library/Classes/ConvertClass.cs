using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWP_Foreign_Languages_Library.Classes
{
    public class ConvertClass
    {
        public static string FormatedDate(DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }
        public static string FormatedTime(TimeSpan time)
        {
            return time.Hours + ":" + ((time.Minutes < 10) ? "0" + time.Minutes.ToString() : time.Minutes.ToString());
        }
    }
}
