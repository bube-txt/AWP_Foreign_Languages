using AWP_Foreign_Languages_WPF.View.MainFrame.Student;
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
    /// Логика взаимодействия для StudentPage.xaml
    /// </summary>
    public partial class StudentPage : Page
    {
        public StudentPage()
        {
            InitializeComponent();
            App.PF = PersonalFrame;
        }

        private void ListBoxItemAllLessons_Selected(object sender, RoutedEventArgs e)
        {
            PersonalFrame.Content = new AttendancesPage();
        }

        private void ListBoxItemMonthLessons_Selected(object sender, RoutedEventArgs e)
        {
            PersonalFrame.Content = new MonthLessons();
        }

        private void ListBoxItemCallback_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void ListBoxItemMessage_Selected(object sender, RoutedEventArgs e)
        {
            PersonalFrame.Content = new MessangerPage();
        }
    }
}
