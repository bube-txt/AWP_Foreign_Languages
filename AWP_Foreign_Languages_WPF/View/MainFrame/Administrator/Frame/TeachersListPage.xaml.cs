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
    /// Логика взаимодействия для TeachersListPage.xaml
    /// </summary>
    public partial class TeachersListPage : Page
    {
        Core db = new Core();
        List<Teacher> students;
        Teacher lastSelected = null;
        public TeachersListPage()
        {
            InitializeComponent();

            Update();
        }

        private void Update()
        {
            students = db.context.Teacher.Where(x => x.User.Banned == 0).ToList();
            DataGridAttendance.ItemsSource = students;
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            if ((Teacher)DataGridAttendance.SelectedItem != null)
            {
                User user = lastSelected.User;
                /*db.context.Teacher.Remove(lastSelected);
                db.context.User.Remove(user);*/
                db.context.User.Where(x => x.IdUser == user.IdUser).FirstOrDefault().Banned = 1;
                db.context.SaveChanges();

                Update();
            }
        }
        private void DataGridAttendance_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((Teacher)DataGridAttendance.SelectedItem != null)
            {
                lastSelected = (Teacher)DataGridAttendance.SelectedItem;
                App.SelectedTeacher = lastSelected;
            }
        }

        private void ButtonAddConfirm_Click(object sender, RoutedEventArgs e)
        {
            string[] fullName = TextBoxFullNameAdd.Text.Split(' ');

            if (fullName.Length != 3)
            {
                return;
            }

            string sex = " ";
            switch (ComboBoxAddGender.SelectedIndex)
            {
                case 0:
                    sex = "M";
                    break;
                case 1:
                    sex = "W";
                    break;
                default:
                    sex = "N";
                    break;
            }
            try
            {
                User user = new User
                {
                    LastNameUser = fullName[0],
                    FirstNameUser = fullName[1],
                    PatronicNameUser = fullName[2],
                    IdRoleUser = 2,
                    PasswordUser = TextBoxPasswordAdd.Text,
                    EmailUser = TextBoxEmailAdd.Text,
                    PhoneUser = TextBoxPhoneAdd.Text,
                    BirthdayUser = DatePickerDOBAdd.SelectedDate,
                    SexUser = sex,
                    Banned = 0,
                };
                db.context.User.Add(user);
                db.context.SaveChanges();

                Teacher teacher = new Teacher
                {
                    IdLanguageTeacher = 1,
                    IdUserTeacher = db.context.User.Where(x => x.PhoneUser == user.PhoneUser && x.PasswordUser == user.PasswordUser).FirstOrDefault().IdUser
                };

                db.context.Teacher.Add(teacher);
                db.context.SaveChanges();

                Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonEditConfirm_Click(object sender, RoutedEventArgs e)
        {
            string[] fullName = TextBoxFullNameEdit.Text.Split(' ');

            if (fullName.Length != 3)
            {
                return;
            }

            string sex = " ";
            switch (ComboBoxEditGender.SelectedIndex)
            {
                case 0:
                    sex = "M";
                    break;
                case 1:
                    sex = "W";
                    break;
                default:
                    sex = "N";
                    break;
            }
            try
            {

                User edited = db.context.User.Where(x => x.IdUser == lastSelected.IdUserTeacher && x.Banned == 0).FirstOrDefault();

                edited.LastNameUser = fullName[0];
                edited.FirstNameUser = fullName[1];
                edited.PatronicNameUser = fullName[2];
                edited.PasswordUser = TextBoxPasswordEdit.Text;
                edited.EmailUser = TextBoxEmailEdit.Text;
                edited.PhoneUser = TextBoxPhoneEdit.Text;
                edited.BirthdayUser = DatePickerDOBEdit.SelectedDate;
                edited.SexUser = sex;

                db.context.SaveChanges();
                Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lastSelected != null)
            {
                TextBoxFullNameEdit.Text = lastSelected.FullName;
                TextBoxEmailEdit.Text = lastSelected.User.EmailUser;
                TextBoxPhoneEdit.Text = lastSelected.User.PhoneUser;
                DatePickerDOBEdit.SelectedDate = lastSelected.User.BirthdayUser;
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
                TextBoxPasswordEdit.Text = lastSelected.User.PasswordUser;
            }
        }

        private void ButtonClearEdit_Click(object sender, RoutedEventArgs e)
        {
            TextBoxFullNameEdit.Text = null;
            TextBoxEmailEdit.Text = null;
            TextBoxPhoneEdit.Text = null;
            DatePickerDOBEdit.SelectedDate = null;
            ComboBoxEditGender.SelectedIndex = -1;
            TextBoxPasswordEdit.Text = null;
        }
    }
}
