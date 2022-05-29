using AWP_Foreign_Languages_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWP_Foreign_Languages_WPF.ViewModel
{
    public class UserViewModel
    {
        static Core db = new Core();

        // Проверка введёных данных пользователя и получение пользователя
        public static bool UserLogin(string phone, string password)
        {
            int matches = db.context.User.Where(x => x.PhoneUser == phone & x.PasswordUser == password).Count();

            if (matches > 0)
            {
                App.ActiveUser = db.context.User.Where(x => x.PhoneUser == phone & x.PasswordUser == password).FirstOrDefault();
                User user = App.ActiveUser;

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
