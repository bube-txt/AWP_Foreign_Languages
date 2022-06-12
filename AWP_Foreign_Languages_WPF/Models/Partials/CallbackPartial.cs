using AWP_Foreign_Languages_Library.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWP_Foreign_Languages_WPF.Models
{
    partial class Callback
    {
        public string GetClientName
        {
            get
            {
                if (Client.GetGroupName != null)
                {
                    return "[" + Client.GetGroupName + "] " + Client.FullName;
                }
                else
                {
                    return Client.FullName;
                }
            }
        }
        public string GetFormatedDate
        {
            get
            {
                return ConvertClass.FormatedDate(DateCallback);
            }
        }
        public string GetFormatedTime
        {
            get
            {
                return ConvertClass.FormatedTime(TimeCallback);
            }
        }
    }
}
