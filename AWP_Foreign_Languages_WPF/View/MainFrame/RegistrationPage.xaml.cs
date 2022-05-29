using AWP_Foreign_Languages_WPF.Models;
using Microsoft.Win32;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Drawing;
using System;
using System.Data.Entity.Validation;
using AWP_Foreign_Languages_WPF.Assets.Enums;

namespace AWP_Foreign_Languages_WPF.View.MainFrame
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        Core db = new Core();
        string filePath;
        string fileName;
        byte[] imageInBytes;
        bool avatar = false;

        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void ButtonSelectPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";

            bool? response = openFileDialog.ShowDialog();

            if (response == true)
            {
                filePath = openFileDialog.FileName;

                fileName = filePath.Split('\\')[filePath.Split('\\').Length-1];

                ButtonSelectPhoto.Content = "Фотография успешно выбрана!";

                imageInBytes = File.ReadAllBytes(filePath);

                avatar = true;
            }
        }

        private void ButtonRegistration_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxFullName.Text.Trim().Split(' ').Length != 3)
            {
                MessageBox.Show(ExceptionsEnum.FullNameException);
                return;
            }
            if (!Regex.IsMatch(TextBoxEmail.Text, @".{1,}@.{1,}\..{1,}"))
            {
                MessageBox.Show(ExceptionsEnum.EmailException);
                return;
            }
            if (!Regex.IsMatch(TextBoxPhone.Text, @"(\+[0-9]{11}|[0-9]{11})"))
            {
                MessageBox.Show(ExceptionsEnum.PhoneException);
                return;
            }

            if (DatePickerDateBirthday.SelectedDate == null && DatePickerDateBirthday.SelectedDate.ToString() == "" && DatePickerDateBirthday.SelectedDate.ToString() == "0001.01.01")
            {
                MessageBox.Show(ExceptionsEnum.DateBirthdayException);
                return;
            }
            if (TextBoxPassword.Text.Trim() == "")
            {
                MessageBox.Show(ExceptionsEnum.PasswordException);
                return;
            }
            if (ComboBoxGender.SelectedIndex == -1)
            {
                MessageBox.Show(ExceptionsEnum.GenderException);
                return;
            }


            string[] names = TextBoxFullName.Text.Trim().Split(' ');
            char sex = ' ';
            switch (ComboBoxGender.SelectedIndex)
            {
                case 0:
                    sex = 'M';
                    break;
                case 1:
                    sex = 'W';
                    break;
                default:
                    sex = 'N';
                    break;
            }

            User newUser = new User
            {
                PasswordUser = TextBoxPassword.Text.Trim(),
                IdRoleUser = 1,
                LastNameUser = names[0],
                FirstNameUser = names[1],
                PatronicNameUser = names[2],
                EmailUser = TextBoxEmail.Text.Trim(),
                PhoneUser = TextBoxPhone.Text.Trim(),
                BirthdayUser = DatePickerDateBirthday.SelectedDate,
                SexUser = sex.ToString(),
            };

            if (avatar)
            {
                newUser = new User 
                {
                    PasswordUser = TextBoxPassword.Text.Trim(),
                    IdRoleUser = 1,
                    LastNameUser = names[0],
                    FirstNameUser = names[1],
                    PatronicNameUser = names[2],
                    EmailUser = TextBoxEmail.Text.Trim(),
                    PhoneUser = TextBoxPhone.Text.Trim(),
                    BirthdayUser = DatePickerDateBirthday.SelectedDate,
                    AvatarUser = imageInBytes,
                };
            }

            try
            {
                db.context.User.Add(newUser);
                db.context.SaveChanges();
                MessageBox.Show("Регистрация успешно выполнена!");
                App.MF.Content = new LoginPage();
            }

            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());
                    MessageBox.Show("");

                        foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        MessageBox.Show(err.ErrorMessage + "");
                        }
                }
            }
        }
    }
}
