using AWP_Foreign_Languages_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AWP_Foreign_Languages_WPF.View.MainFrame.Teachers
{
    /// <summary>
    /// Логика взаимодействия для LessonsPage.xaml
    /// </summary>
    public partial class LessonsPage : Page
    {
        Core db = new Core();
        List<Lesson> lessons;
        Lesson lastSelected = null;
        public LessonsPage()
        {
            InitializeComponent();

            DateTime dateTime = DateTime.Now.AddDays(-1.0);
            lessons = db.context.Lesson.Where(x => x.IdTeacherLesson == App.ActiveTeacher.IdTeacher && x.DateLesson > dateTime).ToList();
            DataGridSchedule.ItemsSource = lessons;
        }


        #region Контекстное меню

        /// <summary>
        /// Посмотреть ДЗ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonHomeWorkView_Click(object sender, RoutedEventArgs e)
        {
            App.MF.NavigationService.Navigate(new HomeworkPage());
        }

        /// <summary>
        /// Выбранное поле в датагриде
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridSchedule_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((Lesson)DataGridSchedule.SelectedItem != null)
            {
                lastSelected = (Lesson)DataGridSchedule.SelectedItem;
                App.SelectedLesson = lastSelected;
                App.SelectedAttendance = db.context.Attendance.Where(x => x.IdLesson == lastSelected.IdLesson).FirstOrDefault();
            }
        }
        #endregion

        private void ButtonAttendanceView_Click(object sender, RoutedEventArgs e)
        {
            App.PF.Content = new AttendancePage();
        }
    }
}
