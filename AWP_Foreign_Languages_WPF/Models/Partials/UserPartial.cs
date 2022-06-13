using AWP_Foreign_Languages_Library.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWP_Foreign_Languages_WPF.Models
{
    partial class User
    {
        public string FullName
        {
            get
            {
                return LastNameUser + " " + FirstNameUser + " " + PatronicNameUser;
            }
        }
        public string FormatedDOB
        {
            get
            {
                return ConvertClass.FormatedDate((DateTime)BirthdayUser);
            }
        }
        public string GenderUser
        {
            get
            {
                if (SexUser == "M")
                {
                    return "Мужской";
                }
                else if (SexUser == "W")
                {
                    return "Женский";
                }
                else
                {
                    return "???";
                }
            }
        }
    }
}
