using AWP_Foreign_Languages_WPF.View.MainFrame.Administrator.Frame;
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

namespace AWP_Foreign_Languages_WPF.View.MainFrame.Administrator
{
    /// <summary>
    /// Логика взаимодействия для AdministratorPage.xaml
    /// </summary>
    public partial class AdministratorPage : Page
    {
        public AdministratorPage()
        {
            InitializeComponent();
        }

        private void ListBoxItemStudents_Selected(object sender, RoutedEventArgs e)
        {
            PersonalFrame.Content = new StudentsPage();
        }

        private void ListBoxItemSchedule_Selected(object sender, RoutedEventArgs e)
        {
            PersonalFrame.Content = new SchedulePage();
        }

        private void ListBoxItemTeachersAndServices_Selected(object sender, RoutedEventArgs e)
        {
            PersonalFrame.Content = new TeachersPage();
        }

        private void ListBoxItemServices_Selected(object sender, RoutedEventArgs e)
        {
            PersonalFrame.Content = new ServicePage();
        }

        private void ListBoxItemTeacher_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void ListBoxItemFormGroups_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void ListBoxItemCallbacks_Selected(object sender, RoutedEventArgs e)
        {
            PersonalFrame.Content = new CallbacksPage();
        }
    }
}
