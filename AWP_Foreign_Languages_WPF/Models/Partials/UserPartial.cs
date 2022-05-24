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
    }
}
