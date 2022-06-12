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
    /// Логика взаимодействия для StudentsPage.xaml
    /// </summary>
    public partial class StudentsPage : Page
    {
        Core db = new Core();
        List<Client> students;
        Client lastSelected = null;
        public StudentsPage()
        {
            InitializeComponent();

            students = db.context.Client.Where(x => x.User.Banned == 0).ToList();
            DataGridSchedule.ItemsSource = students;
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
            if ((Client)DataGridSchedule.SelectedItem != null)
            {
                User user = lastSelected.User;
                /*db.context.Client.Remove(lastSelected);
                db.context.User.Remove(user);*/
                db.context.User.Where(x => x.IdUser == user.IdUser).FirstOrDefault().Banned = 1;
                db.context.SaveChanges();

                DataGridSchedule.ItemsSource = db.context.Client.Where(x => x.User.Banned == 0).ToList();
            }
        }

        /// <summary>
        /// Выбранное поле в датагриде
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridSchedule_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((Client)DataGridSchedule.SelectedItem != null)
            {
                lastSelected = (Client)DataGridSchedule.SelectedItem;
                App.SelectedClient = lastSelected;
            }
        }
        #endregion

        #region Поиск
        private void Search()
        {
            students = db.context.Client.ToList();

            if (!String.IsNullOrWhiteSpace(TextBoxFullNameSearch.Text))
            {
                students = students.Where(x => x.FullName.ToLower().Trim().Contains(TextBoxFullNameSearch.Text.ToLower().Trim())).ToList();
            }
            if (!String.IsNullOrWhiteSpace(TextBoxEmailSearch.Text))
            {
                students = students.Where(x => x.User.EmailUser.ToLower().Trim().Contains(TextBoxEmailSearch.Text.ToLower().Trim())).ToList();
            }
            if (!String.IsNullOrWhiteSpace(TextBoxPhoneSearch.Text))
            {
                students = students.Where(x => x.User.PhoneUser.ToLower().Trim().Contains(TextBoxPhoneSearch.Text.ToLower().Trim())).ToList();
            }
            if (DatePickerDOBSearch.SelectedDate != null)
            {
                students = students.Where(x => x.User.BirthdayUser == DatePickerDOBSearch.SelectedDate).ToList();
            }
            if (ComboBoxGender.SelectedIndex != -1)
            {
                students = students.ToList();
            }

            DataGridSchedule.ItemsSource = students;
        }
        private void ComboBoxLessonName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Search();
        }
        private void ComboBoxServiceName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Search();
        }
        private void DatePickerDateLesson_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Search();
        }

        private void TextBoxTimeLesson_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search();
        }

        private void ComboBoxTeacherLesson_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Search();
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            TextBoxFullNameSearch.Text = "";
            TextBoxEmailSearch.Text = "";
            TextBoxPhoneSearch.Text = "";
            DatePickerDOBSearch.SelectedDate = null;
            ComboBoxGender.SelectedIndex = -1;
        }
        #endregion

        #region Редактирование

        private void ClearEdit()
        {
            TextBoxFullNameEdit.Text = null;
            TextBoxEmailEdit.Text = null;
            TextBoxPhoneEdit.Text = null;
            DatePickerDOBEdit.SelectedDate = null;
            ComboBoxEditGender.SelectedIndex = -1;
            TextBoxPasswordEdit.Text = null;
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lastSelected == null)
            {
                return;
            }
            TextBoxFullNameEdit.Text = lastSelected.FullName;
            TextBoxEmailEdit.Text = lastSelected.User.EmailUser;
            TextBoxPhoneEdit.Text = lastSelected.User.PhoneUser;
            DatePickerDOBEdit.SelectedDate = lastSelected.User.BirthdayUser;
            TextBoxPasswordEdit.Text = lastSelected.User.PasswordUser;
            int gender = -1;
            if (lastSelected.User.SexUser == "M")
            {
                gender = 0;
            }
            else if (lastSelected.User.SexUser == "W")
            {
                gender = 1;
            }
            ComboBoxEditGender.SelectedIndex = gender;
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
            string[] fullName = TextBoxFullNameEdit.Text.Trim().Split(' ');
            string email = TextBoxEmailEdit.Text.Trim();
            string phone = TextBoxPhoneEdit.Text.Trim();
            DateTime date = (DateTime)DatePickerDOBEdit.SelectedDate;
            int sex = ComboBoxEditGender.SelectedIndex;

            Client selectedLesson = db.context.Client.Where(x => x.IdClient == lastSelected.IdClient).FirstOrDefault();
            User user = db.context.Client.Where(x => x.IdClient == lastSelected.IdClient).FirstOrDefault().User;

            selectedLesson.User.LastNameUser = fullName[0];
            selectedLesson.User.FirstNameUser = fullName[1];
            selectedLesson.User.PatronicNameUser = fullName[2];
            selectedLesson.User.EmailUser = email;
            selectedLesson.User.PhoneUser = phone;
            selectedLesson.User.BirthdayUser = date;
            string gender = "";
            if (ComboBoxEditGender.SelectedIndex == 0)
            {
                gender = "M";
            }
            else if (ComboBoxEditGender.SelectedIndex == 1)
            {
                gender = "W";
            }
            selectedLesson.User.SexUser = gender;

            user.PasswordUser = TextBoxPasswordEdit.Text;

            students = db.context.Client.Where(x => x.User.Banned == 0).ToList();
            DataGridSchedule.ItemsSource = students;

            ClearEdit();
            db.context.SaveChanges();
        }

        private bool CheckEdit()
        {
            var fullname = TextBoxFullNameEdit.Text;
            var email = TextBoxEmailEdit.Text;
            var phone = TextBoxPhoneEdit.Text;
            var date = DatePickerDOBEdit.SelectedDate;
            var gender = ComboBoxEditGender.SelectedValue;
            var password = TextBoxPasswordEdit.Text;

            if (
                fullname == null ||
                email == null ||
                phone == null ||
                date == null||
                gender == null ||
                password == null
                )
            {
                return false;
            }
            else
            {
                if (fullname.Trim().Split(' ').Length != 3)
                {
                    return false;
                }
                return true;
            }
        }

        private void TextBoxTextBoxFullNameSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search();
        }

        private void TextBoxTextBoxEmailSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search();
        }

        private void TextBoxTextBoxPhoneSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search();
        }

        private void DatePickerDOBSearch_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Search();
        }

        private void ComboBoxGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Search();
        }
    }
}
