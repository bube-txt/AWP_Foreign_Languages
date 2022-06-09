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
    /// Логика взаимодействия для CallbackPage.xaml
    /// </summary>
    public partial class CallbackPage : Page
    {
        Core db = new Core();
        public CallbackPage()
        {
            Update();

            InitializeComponent();
        }
        private void ButtonSendMessage_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(TextBoxMessage.Text))
            {
                Callback message = new Callback
                {
                    IdClientCallback = App.ActiveClient.IdClient,
                    DateCallback = DateTime.Now.Date,
                    TimeCallback = DateTime.Now.TimeOfDay,
                    TextCallback = TextBoxMessage.Text.Trim(),
                };

                db.context.Callback.Add(message);
                db.context.SaveChanges();
                Update();
            }
        }

        private void Update()
        {
            List<Callback> messages = db.context.Callback.AsEnumerable().Reverse().ToList();
            ListViewMessanger.ItemsSource = messages;
        }
    }
}
