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
        Core db = new Core();
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
        public string GetGroupName
        {
            get
            {
                int count = db.context.ClientGroup.Where(x => x.IdClient == IdClient).ToList().Count;
                if (count > 1)
                {
                    List<ClientGroup> list = db.context.ClientGroup.Where(x => x.IdClient == IdClient).ToList();
                    string str = "";
                    foreach (var item in list)
                    {
                        str += item.Group.NameGroup + ", ";
                    }
                    return str.Trim();
                }
                else if (count == 1)
                {
                    return db.context.ClientGroup.Where(x => x.IdClient == IdClient).FirstOrDefault().Group.NameGroup;
                }
                else
                {
                    return "";
                }
            }
        }
    }
}
