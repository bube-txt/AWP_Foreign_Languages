using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWP_Foreign_Languages_WPF.Assets.Enums
{
    public static class ExceptionsEnum
    {
        public const string AuthException = "Неверный логин или пароль!";
        public const string RoleException = "Что-то не так с вашей ролью!";
        public const string FullNameException = "Неверный формат ФИО, ожидается формат - Иванов Иван Иванович";
        public const string EmailException = "Неверный формат электронной почты, ожидается формат - name@mail.ru";
        public const string PhoneException = "Неверно введён номер телефона!";
        public const string DateBirthdayException = "Ошибка в строке дата рождения!";
        public const string PasswordException = "Ошибка в строке ввода пароля!";
        public const string GenderException = "Ошибка в строке выбора пола!";
    }
}
