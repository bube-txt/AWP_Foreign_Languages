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
    /// Логика взаимодействия для MessagesPage.xaml
    /// </summary>
    public partial class MessagesPage : Page
    {
        Core db = new Core();
        public MessagesPage()
        {
            InitializeComponent();

            ComboBoxTeachers.ItemsSource = db.context.Client.ToList();

            ComboBoxTeachers.DisplayMemberPath = "FullName";
            ComboBoxTeachers.SelectedValuePath = "IdClient";
            ComboBoxTeachers.SelectedIndex = 0;
        }

        private void ComboBoxTeachers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void Update()
        {
            if (ComboBoxTeachers.SelectedIndex != -1)
            {
                List<Message> messages = db.context.Message.Where(x => x.IdClientMessage == (int)ComboBoxTeachers.SelectedValue && x.IdTeacherMessage == App.ActiveTeacher.IdTeacher).AsEnumerable().Reverse().ToList();
                ListViewMessanger.ItemsSource = messages;
            }
        }
    }
}
