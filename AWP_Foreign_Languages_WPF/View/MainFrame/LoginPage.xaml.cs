using AWP_Foreign_Languages_WPF.Models;
using AWP_Foreign_Languages_WPF.View.MainFrame.Students;
using AWP_Foreign_Languages_WPF.View.MainFrame.Teacher;
using AWP_Foreign_Languages_WPF.View.MainFrame.Administrator;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace AWP_Foreign_Languages_WPF.View.MainFrame
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        Core db = new Core();
        public LoginPage()
        {
            InitializeComponent();
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            string phone = TextBoxPhone.Text.Trim();
            string password = TextBoxPassword.Text;


            if (phone.Length != 11)
            {
                MessageBox.Show("Неверно введён номер телефона");
                return;
            }

            List<User> users = db.context.User.Where(x => x.PhoneUser == phone && x.PasswordUser == password).ToList();
            int count = users.Count;
            if (count > 0)
            {
                User user = users.FirstOrDefault();
                App.ActiveUser = user;

                if (user.Role.NameRole == "Клиент")
                {
                    NavigationService.Navigate(new StudentPage());
                    ShowPersonalPageButton();
                }
                else if (user.Role.NameRole == "Преподаватель")
                {
                    NavigationService.Navigate(new TeacherPage());
                    ShowPersonalPageButton();
                }
                else if (user.Role.NameRole == "Администратор")
                {
                    NavigationService.Navigate(new AdministratorPage());
                    ShowPersonalPageButton();
                }
                else if (user.Role.NameRole == "Тестовый режим")
                {
                    // NavigationService.Navigate(new StudentPage());
                }
                else
                {
                    MessageBox.Show("Что-то не так с вашей ролью");
                }
            }
        }
        private void ShowPersonalPageButton()
        {
            App.PersonalPageButton.Visibility = Visibility.Visible;
            App.LoginBorder.Visibility = Visibility.Collapsed;
            App.LogoutBorder.Visibility = Visibility.Visible;
        }
    }
}
