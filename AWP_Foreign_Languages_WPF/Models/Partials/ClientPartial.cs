using AWP_Foreign_Languages_Library.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWP_Foreign_Languages_WPF.Models
{
    public partial class Client
    {
        public string FullName
        {
            get
            {
                return User.LastNameUser + " " + User.FirstNameUser + " " + User.PatronicNameUser;
            }
        }
        public string FormatedDOB
        {
            get
            {
                return ConvertClass.FormatedDate((DateTime)User.BirthdayUser);
            }
        }
        public string GenderUser
        {
            get
            {
                if (User.SexUser == "M")
                {
                    return "Мужской";
                }
                else if (User.SexUser == "W")
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
