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
    /// Логика взаимодействия для AttendancePage.xaml
    /// </summary>
    public partial class AttendancePage : Page
    {
        Core db = new Core();
        Attendance lastSelected;
        public AttendancePage()
        {
            InitializeComponent();

            ComboBoxGroup.ItemsSource = db.context.Group.ToList();
            ComboBoxGroup.DisplayMemberPath = "NameGroup";
            ComboBoxGroup.SelectedValuePath = "IdGroup";

            ComboBoxClient.ItemsSource = db.context.ClientGroup.ToList();
            ComboBoxClient.DisplayMemberPath = "FullName";
            ComboBoxClient.SelectedValuePath = "IdClient";

            Update();
        }

        private void Update()
        {
            DataGridAttendance.ItemsSource = db.context.Attendance.Where(x => x.IdLesson == App.SelectedLesson.IdLesson).ToList();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            App.MF.Content = new LessonsPage();
        }

        private void ButtonAttendanceChecked_Click(object sender, RoutedEventArgs e)
        {
            ChangeAttendance();
        }

        private void ChangeAttendance()
        {
            Byte? byt = db.context.Attendance.Where(x => x.IdAttendance == lastSelected.IdAttendance).FirstOrDefault().BoolAttendance;

            if (byt == 1)
            {
                db.context.Attendance.Where(x => x.IdAttendance == lastSelected.IdAttendance).FirstOrDefault().BoolAttendance = 0;
                db.context.SaveChanges();
            }
            else
            {
                db.context.Attendance.Where(x => x.IdAttendance == lastSelected.IdAttendance).FirstOrDefault().BoolAttendance = 1;
                db.context.SaveChanges();
            }
            Update();
        }

        private void DataGridAttendance_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((Attendance)DataGridAttendance.SelectedItem != null)
            {
                lastSelected = (Attendance)DataGridAttendance.SelectedItem;
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Attendance attendance = new Attendance
            {
                IdLesson = App.SelectedLesson.IdLesson
            };
            int i = 1;

            if (ComboBoxAttendanceStatus.SelectedIndex == 1)
            {
                attendance.BoolAttendance = 1;
                i++;
            }
            else
            {
                attendance.BoolAttendance = 0;
                i++;
            }

            if (ComboBoxClient.SelectedIndex != -1)
            {
                attendance.IdClient = (int)ComboBoxClient.SelectedValue;
                i++;
            }

            if (i == 3)
            {
                db.context.Attendance.Add(attendance);
                db.context.SaveChanges();
                Update();
            }
            else
            {
                MessageBox.Show("Возникла ошибка ввода данных");
            }
        }

        private void ComboBoxGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxGroup.SelectedIndex != -1)
            {
                ComboBoxClient.ItemsSource = db.context.ClientGroup.Where(x => x.IdGroup == (int)ComboBoxGroup.SelectedValue).ToList();
            }
        }

        private void ButtonClearAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
