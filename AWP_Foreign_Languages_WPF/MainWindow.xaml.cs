using AWP_Foreign_Languages_WPF.Assets.Enums;
using AWP_Foreign_Languages_WPF.Models;
using AWP_Foreign_Languages_WPF.View.MainFrame;
using AWP_Foreign_Languages_WPF.View.MainFrame.Administrator;
using AWP_Foreign_Languages_WPF.View.MainFrame.Students;
using AWP_Foreign_Languages_WPF.View.MainFrame.Teachers;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace AWP_Foreign_Languages_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Core db = new Core();
        public MainWindow()
        {
            InitializeComponent();

            string welcomeMessage = @"
Данное приложение находится на стадии разработки и тестирования, так что возможны баги, вылеты и иные проблемы.

Обо всех найденых ошибках сообщайте по электронному адресу: Kat89826420232@gmail.com.

Благодарим за пользование нашей программы!
";

            MessageBox.Show(welcomeMessage,"Добро пожаловать!", MessageBoxButton.OK, MessageBoxImage.Information);

            App.MF = MainFrame;
            App.PersonalPageButton = ButtonPersonalPage;
            App.LoginBorder = LogInBorder;
            App.LogoutBorder = LogoutBorder;

            // Тестовый режим
            App.ActiveUser = db.context.User.Where(x => x.IdUser == 6).FirstOrDefault();

            if (App.ActiveUser.Role.NameRole == RolesEnum.Client)
            {
                App.ActiveClient = db.context.Client.Where(x => x.User.IdUser == App.ActiveUser.IdUser).FirstOrDefault();
            }
            else if (App.ActiveUser.Role.NameRole == RolesEnum.Teacher)
            {
                App.ActiveTeacher = db.context.Teacher.Where(x => x.User.IdUser == App.ActiveUser.IdUser).FirstOrDefault();
            }
            LogInBorder.Visibility = Visibility.Collapsed;
            LogoutBorder.Visibility = Visibility.Visible;
            ButtonPersonalPage.Visibility = Visibility.Visible;
            //

            // Стартовая страница
            WelcomePage page = new WelcomePage();
            MainFrame.Content = page;

        }

        #region События

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (App.ActiveUser != null)
            {
                MessageBoxResult? messageBox = MessageBox.Show("Вы уверены что хотите выйти из аккаунта?", "Внимание", MessageBoxButton.YesNo);
                if (messageBox == MessageBoxResult.Yes)
                {
                    LoginPage page = new LoginPage();
                    MainFrame.Content = page;
                }
            }
            else
            {
                LoginPage page = new LoginPage();
                MainFrame.Content = page;
            }

            /*LogInBorder.Visibility = Visibility.Collapsed;
            LogoutBorder.Visibility = Visibility.Visible;*/
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginPage page = new LoginPage();
            MainFrame.Content = page;

            HidePersonalPageButton();
            App.ActiveUser = null;

            LogInBorder.Visibility = Visibility.Visible;
            LogoutBorder.Visibility = Visibility.Collapsed;

        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            if (App.ActiveUser != null)
            {
                MessageBoxResult? messageBox = MessageBox.Show("Вы уверены что хотите выйти из аккаунта?", "Внимание", MessageBoxButton.YesNo);
                if (messageBox == MessageBoxResult.Yes)
                {
                    RegistrationPage page = new RegistrationPage();
                    MainFrame.Content = page;
                }
            }
            else
            {
                RegistrationPage page = new RegistrationPage();
                MainFrame.Content = page;
            }
        }

        #endregion

        private void Button_WelcomePageClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new WelcomePage();
        }

        private void Button_PersonalPageClick(object sender, RoutedEventArgs e)
        {
            User user = App.ActiveUser;
            if (user.Banned == 1)
            {
                App.MF.Navigate(new BannedPage());
            }
            else if (user.Role.NameRole == RolesEnum.Client)
            {
                App.MF.Navigate(new StudentPage());
            }
            else if (user.Role.NameRole == RolesEnum.Teacher)
            {
                App.MF.Navigate(new TeacherPage());
            }
            else if (user.Role.NameRole == RolesEnum.Administrator)
            {
                App.MF.Navigate(new AdministratorPage());
            }
            else if (user.Role.NameRole == RolesEnum.TestMode)
            {
                // App.MF.Navigate(new StudentPage());
            }
            else
            {
                MessageBox.Show("Что-то не так с вашей ролью");
            }
        }
        private void HidePersonalPageButton()
        {
            ButtonPersonalPage.Visibility = Visibility.Collapsed;

            App.LogoutBorder.Visibility = Visibility.Collapsed;
            App.LoginBorder.Visibility = Visibility.Visible;
        }
    }
}
