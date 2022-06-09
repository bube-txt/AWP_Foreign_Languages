using AWP_Foreign_Languages_Library.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWP_Foreign_Languages_WPF.Models
{
    partial class Message
    {
        public string GetClientName
        {
            get
            {
                return "["+Client.GetGroupName+"] " + Client.FullName;
            }
        }
        public string GetTeacherName
        {
            get
            {
                return Teacher.FullName;
            }
        }
        public string GetFormatedDate
        {
            get
            {
                return ConvertClass.FormatedDate(DateMessage);
            }
        }
        public string GetFormatedTime
        {
            get
            {
                return ConvertClass.FormatedTime(TimeMessage);
            }
        }
    }
}
