using AWP_Foreign_Languages_WPF.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AWP_Foreign_Languages_WPF
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// MainFrame
        /// </summary>
        public static Frame MF = null;
        public static Frame PF = null;
        public static Button PersonalPageButton = null;
        public static Border LoginBorder = null;
        public static Border LogoutBorder = null;
        /// <summary>
        /// Активный пользователь
        /// </summary>
        public static Client ActiveClient = null;
        public static Teacher ActiveTeacher = null;
        public static User ActiveUser = null;
        /// <summary>
        /// Выбранное занятие
        /// </summary>
        public static Lesson SelectedLesson = null;
        public static Client SelectedClient = null;
        public static Service SelectedService = null;
        public static Attendance SelectedAttendance = null;
    }
}
