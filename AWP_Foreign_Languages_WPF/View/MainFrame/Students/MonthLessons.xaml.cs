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

namespace AWP_Foreign_Languages_WPF.View.MainFrame.Students
{
    /// <summary>
    /// Логика взаимодействия для MonthLessons.xaml
    /// </summary>
    public partial class MonthLessons : Page
    {
        Core db = new Core();
        public MonthLessons()
        {
            InitializeComponent();

            DateTime now30Days = DateTime.Now.AddDays(30.0);
            DataGridLesson.ItemsSource = db.context.Attendance.Where(x => x.IdClient == App.ActiveClient.IdClient && x.Lesson.DateLesson > DateTime.Now && x.Lesson.DateLesson <= now30Days).ToList();
        }
        private void ButtonHomeWorkView_Click(object sender, RoutedEventArgs e)
        {
            App.MF.Content = new HomeworkPage();
        }

        private void DataGridLesson_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((Attendance)DataGridLesson.SelectedItem != null)
            {
                App.SelectedAttendance = (Attendance)DataGridLesson.SelectedItem;
            }
        }
    }
}
