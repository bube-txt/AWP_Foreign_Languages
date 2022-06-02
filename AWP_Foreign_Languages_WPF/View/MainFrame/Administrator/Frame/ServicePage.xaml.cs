using AWP_Foreign_Languages_Library.Classes;
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
    /// Логика взаимодействия для ServicePage.xaml
    /// </summary>
    public partial class ServicePage : Page
    {
        Core db = new Core();
        List<Service> services;
        Service lastSelected = null;
        public ServicePage()
        {
            InitializeComponent();

            services = db.context.Service.ToList();
            DataGridSchedule.ItemsSource = services;
        }
        #region Контекстное меню

        /// <summary>
        /// Посмотреть ДЗ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonHomeWorkView_Click(object sender, RoutedEventArgs e)
        {
            App.MF.NavigationService.Navigate(new HomeworkPage());
        }

        /// <summary>
        /// Удалить выбранную строку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            if ((Service)DataGridSchedule.SelectedItem != null)
            {
                db.context.Service.Remove(lastSelected);
                db.context.SaveChanges();

                DataGridSchedule.ItemsSource = db.context.Service.ToList();
            }
        }

        /// <summary>
        /// Выбранное поле в датагриде
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridSchedule_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((Service)DataGridSchedule.SelectedItem != null)
            {
                lastSelected = (Service)DataGridSchedule.SelectedItem;
                App.SelectedService = lastSelected;
            }
        }
        #endregion

        #region Поиск
        private void Search()
        {
            services = db.context.Service.ToList();

            if (!String.IsNullOrWhiteSpace(TextBoxServiceName.Text))
            {
                services = services.Where(x => x.NameService.ToLower().Trim().Contains(TextBoxServiceName.Text.ToLower().Trim())).ToList();
            }
            if (!String.IsNullOrWhiteSpace(TextBoxServicePrice.Text))
            {
                services = services.Where(x => x.PriceService == Convert.ToInt32(TextBoxServicePrice.Text.Trim())).ToList();
            }

            DataGridSchedule.ItemsSource = services;
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            TextBoxServiceName.Text = "";
            TextBoxServicePrice.Text = "";
        }
        #endregion

        #region Добавление
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckAdd())
            {
                return;
            }
            string name = TextBoxServiceNameAdd.Text;
            int price = Convert.ToInt32(TextBoxServicePriceAdd.Text);

            try
            {
                Service newService = new Service
                {
                    NameService = name,
                    PriceService = price,
                };

                db.context.Service.Add(newService);
                db.context.SaveChanges();

                services = db.context.Service.ToList();
                DataGridSchedule.ItemsSource = services;
                ClearAdd();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ButtonClearAdd_Click(object sender, RoutedEventArgs e)
        {
            ClearAdd();
        }
        private void ClearAdd()
        {
            TextBoxServiceNameAdd.Text = "";
            TextBoxServicePriceAdd.Text = "";
        }
        #endregion

        #region Редактирование

        private void ClearEdit()
        {
            TextBoxServiceNameEdit.Text = "";
            TextBoxServicePriceEdit.Text = "";
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lastSelected == null)
            {
                return;
            }
            TextBoxServiceNameEdit.Text = lastSelected.NameService;
            TextBoxServicePriceEdit.Text = lastSelected.PriceService+"";
        }

        private void ButtonClearEdit_Click(object sender, RoutedEventArgs e)
        {
            ClearEdit();
        }

        #endregion

        private void ButtonEditConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckEdit())
            {
                return;
            }
            string name = TextBoxServiceNameEdit.Text;
            int price = Convert.ToInt32(TextBoxServicePriceEdit.Text);

            Service selectedLesson = db.context.Service.Where(x => x.IdService == lastSelected.IdService).FirstOrDefault();

            selectedLesson.NameService = name;
            selectedLesson.PriceService = price;

            services = db.context.Service.ToList();
            DataGridSchedule.ItemsSource = services;

            ClearEdit();
            db.context.SaveChanges();
        }

        private bool CheckEdit()
        {
            var name = TextBoxServiceNameEdit.Text;
            var price = TextBoxServicePriceEdit.Text;

            if (
                String.IsNullOrWhiteSpace(name) ||
                String.IsNullOrWhiteSpace(price)
                )
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CheckAdd()
        {
            var name = TextBoxServiceNameAdd.Text;
            var price = TextBoxServicePriceAdd.Text;

            if (
                String.IsNullOrWhiteSpace(name) ||
                String.IsNullOrWhiteSpace(price)
                )
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void TextBoxServiceName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search();
        }

        private void TextBoxServicePrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search();
        }
    }
}
