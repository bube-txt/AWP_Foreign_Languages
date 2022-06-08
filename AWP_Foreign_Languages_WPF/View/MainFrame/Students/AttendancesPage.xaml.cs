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
    /// Логика взаимодействия для AttendancesPage.xaml
    /// </summary>
    public partial class AttendancesPage : Page
    {
        Core db = new Core();
        public AttendancesPage()
        {
            InitializeComponent();

            DataGridAttendance.ItemsSource = db.context.Attendance.Where(x => x.IdClient == App.ActiveClient.IdClient && x.Lesson.DateLesson < DateTime.Now).ToList();
        }

        private void ButtonHomeWorkView_Click(object sender, RoutedEventArgs e)
        {
            App.MF.Content = new HomeworkPage();
        }

        private void DataGridAttendance_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((Attendance)DataGridAttendance.SelectedItem != null)
            {
                App.SelectedAttendance = (Attendance)DataGridAttendance.SelectedItem;
            }
        }
    }
}
