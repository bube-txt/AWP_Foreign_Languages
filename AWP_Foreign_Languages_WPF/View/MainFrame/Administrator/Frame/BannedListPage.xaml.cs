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
    /// Логика взаимодействия для BannedListPage.xaml
    /// </summary>
    public partial class BannedListPage : Page
    {
        Core db = new Core();
        User lastSelected = null;
        public BannedListPage()
        {
            InitializeComponent();

            Update();
        }

        private void Update()
        {
            DataGridSchedule.ItemsSource = db.context.User.Where(x => x.Banned == 1).ToList();
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            if ((User)DataGridSchedule.SelectedItem != null)
            {
                User user = lastSelected;
                /*db.context.Client.Remove(lastSelected);
                db.context.User.Remove(user);*/
                db.context.User.Where(x => x.IdUser == user.IdUser).FirstOrDefault().Banned = 0;
                db.context.SaveChanges();

                Update();
            }
        }

        private void DataGridSchedule_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((User)DataGridSchedule.SelectedItem != null)
            {
                lastSelected = (User)DataGridSchedule.SelectedItem;
            }
        }
    }
}
