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

namespace AWP_Foreign_Languages_WPF.View.MainFrame.Administrator.Frame
{
    /// <summary>
    /// Логика взаимодействия для CallbacksPage.xaml
    /// </summary>
    public partial class CallbacksPage : Page
    {
        Core db = new Core();
        public CallbacksPage()
        {
            InitializeComponent();

            Update();
        }

        private void Update()
        {
            List<Callback> messages = db.context.Callback.AsEnumerable().Reverse().ToList();
            if (messages.Count > 0)
            {
                ListViewCallback.ItemsSource = messages;
            }
        }
    }
}
