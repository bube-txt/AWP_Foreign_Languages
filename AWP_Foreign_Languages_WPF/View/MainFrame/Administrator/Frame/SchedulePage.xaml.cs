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
    /// Логика взаимодействия для SchedulePage.xaml
    /// </summary>
    public partial class SchedulePage : Page
    {
        Core db = new Core();
        List<Lesson> lessons;
        Lesson lastSelected = null;
        public SchedulePage()
        {
            InitializeComponent();

            lessons = db.context.Lesson.ToList();
            DataGridSchedule.ItemsSource = lessons;

            #region Поиск

            ComboBoxLessonName.ItemsSource = db.context.Language.ToList();
            ComboBoxLessonName.DisplayMemberPath = "NameLanguage";
            ComboBoxLessonName.SelectedValuePath = "IdLanguage";

            ComboBoxServiceName.ItemsSource = db.context.Service.ToList();
            ComboBoxServiceName.DisplayMemberPath = "NameService";
            ComboBoxServiceName.SelectedValuePath = "IdService";

            ComboBoxTeacherLesson.ItemsSource = db.context.Teacher.ToList();
            ComboBoxTeacherLesson.DisplayMemberPath = "User.FullName";
            ComboBoxTeacherLesson.SelectedValuePath = "IdTeacher";

            #endregion


            #region Добавление

            ComboBoxLessonNameAdd.ItemsSource = db.context.Language.ToList();
            ComboBoxLessonNameAdd.DisplayMemberPath = "NameLanguage";
            ComboBoxLessonNameAdd.SelectedValuePath = "IdLanguage";

            ComboBoxServiceNameAdd.ItemsSource = db.context.Service.ToList();
            ComboBoxServiceNameAdd.DisplayMemberPath = "NameService";
            ComboBoxServiceNameAdd.SelectedValuePath = "IdService";

            ComboBoxTeacherLessonAdd.ItemsSource = db.context.Teacher.ToList();
            ComboBoxTeacherLessonAdd.DisplayMemberPath = "User.FullName";
            ComboBoxTeacherLessonAdd.SelectedValuePath = "IdTeacher";

            #endregion


            #region Редактирование

            ComboBoxLessonNameEdit.ItemsSource = db.context.Language.ToList();
            ComboBoxLessonNameEdit.DisplayMemberPath = "NameLanguage";
            ComboBoxLessonNameEdit.SelectedValuePath = "IdLanguage";

            ComboBoxServiceNameEdit.ItemsSource = db.context.Service.ToList();
            ComboBoxServiceNameEdit.DisplayMemberPath = "NameService";
            ComboBoxServiceNameEdit.SelectedValuePath = "IdService";

            ComboBoxTeacherLessonEdit.ItemsSource = db.context.Teacher.ToList();
            ComboBoxTeacherLessonEdit.DisplayMemberPath = "User.FullName";
            ComboBoxTeacherLessonEdit.SelectedValuePath = "IdTeacher";

            #endregion
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
            if ((Lesson)DataGridSchedule.SelectedItem != null)
            {
                db.context.Lesson.Remove(lastSelected);
                db.context.SaveChanges();

                DataGridSchedule.ItemsSource = db.context.Lesson.ToList();
            }
        }

        /// <summary>
        /// Выбранное поле в датагриде
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridSchedule_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((Lesson)DataGridSchedule.SelectedItem != null)
            {
                lastSelected = (Lesson)DataGridSchedule.SelectedItem;
                App.SelectedLesson = lastSelected;
            }
        }
        #endregion

        #region Поиск
        private void Search()
        {
            lessons = db.context.Lesson.ToList();

            if (ComboBoxLessonName.SelectedIndex != -1)
            {
                lessons = lessons.Where(x => x.LanguageIdLesson == (int)ComboBoxLessonName.SelectedValue).ToList();
            }
            if (ComboBoxServiceName.SelectedIndex != -1)
            {
                lessons = lessons.Where(x => x.ServiceIdLesson == (int)ComboBoxServiceName.SelectedValue).ToList();
            }
            if (DatePickerDateLesson.SelectedDate != null)
            {
                lessons = lessons.Where(x => x.DateLesson == DatePickerDateLesson.SelectedDate).ToList();
            }
            if (CheckClass.TimeCheck(TextBoxTimeLesson.Text))
            {
                lessons = lessons.Where(x => x.TimeLesson == TimeSpan.Parse(TextBoxTimeLesson.Text)).ToList();
            }
            if (ComboBoxTeacherLesson.SelectedIndex != -1)
            {
                lessons = lessons.Where(x => x.Teacher.IdTeacher == (int)ComboBoxTeacherLesson.SelectedValue).ToList();
            }

            DataGridSchedule.ItemsSource = lessons;
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
            ComboBoxLessonName.SelectedIndex = -1;
            ComboBoxServiceName.SelectedIndex = -1;
            DatePickerDateLesson.SelectedDate = null;
            TextBoxTimeLesson.Text = "";
            ComboBoxTeacherLesson.SelectedIndex = -1;
        }
        #endregion

        #region Добавление
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckAdd())
            {
                return;
            }
            int lesson = (int)ComboBoxLessonNameAdd.SelectedValue;
            int service = (int)ComboBoxServiceNameAdd.SelectedValue;
            DateTime date = (DateTime)DatePickerDateLessonAdd.SelectedDate;
            TimeSpan time = TimeSpan.Parse(TextBoxTimeLessonAdd.Text);
            int teacher = (int)ComboBoxTeacherLessonAdd.SelectedValue;

            try
            {
                Lesson newLesson = new Lesson
            {
                LanguageIdLesson = lesson,
                ServiceIdLesson = service,
                DateLesson = date,
                TimeLesson = time,
                IdTeacherLesson = teacher,
            };

                db.context.Lesson.Add(newLesson);
                db.context.SaveChanges();

                lessons = db.context.Lesson.ToList();
                DataGridSchedule.ItemsSource = lessons;
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
            ComboBoxLessonNameAdd.SelectedIndex = -1;
            ComboBoxServiceNameAdd.SelectedIndex = -1;
            DatePickerDateLessonAdd.SelectedDate = null;
            TextBoxTimeLessonAdd.Text = "";
            ComboBoxTeacherLessonAdd.SelectedIndex = -1;
        }
        #endregion

        #region Редактирование

        private void ClearEdit()
        {
            ComboBoxLessonNameEdit.SelectedIndex = -1;
            ComboBoxServiceNameEdit.SelectedIndex = -1;
            DatePickerDateLessonEdit.SelectedDate = null;
            TextBoxTimeLessonEdit.Text = "";
            ComboBoxTeacherLessonEdit.SelectedIndex = -1;
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lastSelected == null)
            {
                return;
            }
            ComboBoxLessonNameEdit.SelectedValue = lastSelected.LanguageIdLesson;
            ComboBoxServiceNameEdit.SelectedValue = lastSelected.ServiceIdLesson;
            DatePickerDateLessonEdit.SelectedDate = lastSelected.DateLesson;
            TextBoxTimeLessonEdit.Text = lastSelected.FormatedLessonTime;
            ComboBoxTeacherLessonEdit.SelectedValue = lastSelected.IdTeacherLesson;
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
            int lesson = (int)ComboBoxLessonNameEdit.SelectedValue;
            int service = (int)ComboBoxServiceNameEdit.SelectedValue;
            DateTime date = (DateTime)DatePickerDateLessonEdit.SelectedDate;
            TimeSpan time = TimeSpan.Parse(TextBoxTimeLessonEdit.Text);
            int teacher = (int)ComboBoxTeacherLessonEdit.SelectedValue;

            Lesson selectedLesson = db.context.Lesson.Where(x => x.IdLesson == lastSelected.IdLesson).FirstOrDefault();

            selectedLesson.LanguageIdLesson = lesson;
            selectedLesson.ServiceIdLesson = service;
            selectedLesson.DateLesson = date;
            selectedLesson.TimeLesson = time;
            selectedLesson.IdTeacherLesson = teacher;

            lessons = db.context.Lesson.ToList();
            DataGridSchedule.ItemsSource = lessons;

            ClearEdit();
            db.context.SaveChanges();
        }

        private bool CheckEdit()
        {
            var lesson = ComboBoxLessonNameEdit.SelectedValue;
            var service = ComboBoxServiceNameEdit.SelectedValue;
            var date = DatePickerDateLessonEdit.SelectedDate;
            var time = TextBoxTimeLessonEdit.Text;
            var teacher = ComboBoxTeacherLessonEdit.SelectedValue;

            if (
                lesson == null ||
                service == null ||
                date == null ||
                String.IsNullOrWhiteSpace(time) ||
                teacher == null
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
            var lesson = ComboBoxLessonNameAdd.SelectedValue;
            var service = ComboBoxServiceNameAdd.SelectedValue;
            var date = DatePickerDateLessonAdd.SelectedDate;
            var time = TextBoxTimeLessonAdd.Text;
            var teacher = ComboBoxTeacherLessonAdd.SelectedValue;

            if (
                lesson == null ||
                service == null ||
                date == null ||
                String.IsNullOrWhiteSpace(time) ||
                teacher == null
                )
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void ButtonAttendanceView_Click(object sender, RoutedEventArgs e)
        {
            App.MF.Content = new AttendancePage();
        }
    }
}
