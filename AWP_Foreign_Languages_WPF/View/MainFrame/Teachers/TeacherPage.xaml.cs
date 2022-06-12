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
    /// Логика взаимодействия для TeacherPage.xaml
    /// </summary>
    public partial class TeacherPage : Page
    {
        public TeacherPage()
        {
            InitializeComponent();
        }

        private void ListBoxItemAttendance_Selected(object sender, RoutedEventArgs e)
        {
            PersonalFrame.Content = new WIP();
        }

        private void ListBoxItemHomeworks_Selected(object sender, RoutedEventArgs e)
        {
            PersonalFrame.Content = new WIP();
        }

        private void ListBoxItemMessages_Selected(object sender, RoutedEventArgs e)
        {
            PersonalFrame.Content = new MessagesPage();
        }
    }
}
