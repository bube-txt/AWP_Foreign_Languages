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
    /// Логика взаимодействия для MessangerPage.xaml
    /// </summary>
    public partial class MessangerPage : Page
    {
        Core db = new Core();
        public MessangerPage()
        {
            InitializeComponent();

            ComboBoxTeachers.ItemsSource = db.context.Teacher.ToList();
            ComboBoxTeachers.DisplayMemberPath = "FullName";
            ComboBoxTeachers.SelectedValuePath = "IdTeacher";
            ComboBoxTeachers.SelectedIndex = 0;
        }

        private void ComboBoxTeachers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxTeachers.SelectedIndex != -1)
            {
                ListViewMessanger.ItemsSource = db.context.Message.Where(x => x.IdTeacherMessage == (int)ComboBoxTeachers.SelectedValue).ToList();
            }
        }

        private void ButtonSendMessage_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(TextBoxMessage.Text))
            {
                Message message = new Message
                {
                    IdClientMessage = App.ActiveClient.IdClient,
                    IdTeacherMessage = (int)ComboBoxTeachers.SelectedValue,
                    DateMessage = DateTime.Now.Date,
                    TimeMessage = DateTime.Now.TimeOfDay,
                    TextMessage = TextBoxMessage.Text.Trim(),
                };

                db.context.Message.Add(message);
                db.context.SaveChanges();
            }
        }
    }
}
