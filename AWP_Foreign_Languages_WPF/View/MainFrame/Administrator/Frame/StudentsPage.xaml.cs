using AWP_Foreign_Languages_WPF.Models;
using System.Collections.Generic;
using System.Windows.Controls;

namespace AWP_Foreign_Languages_WPF.View.MainFrame.Administrator.Frame
{
    /// <summary>
    /// Логика взаимодействия для StudentsPage.xaml
    /// </summary>
    public partial class StudentsPage : Page
    {
        // TODO: Сделать страницу для учащихся
        Core db = new Core();
        List<Client> students;
        Client lastSelected;
        public StudentsPage()
        {
            InitializeComponent();
        }

/*
        #region Контекстное меню

        /// <summary>
        /// Добавить ДЗ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonHomeWorkAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Посмотреть ДЗ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonHomeWorkView_Click(object sender, RoutedEventArgs e)
        {

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
            }
        }
        #endregion

        #region Поиск
        private void Search()
        {
            students = db.context.Lesson.ToList();

            if (ComboBoxLessonName.SelectedIndex != -1)
            {
                students = students.Where(x => x.LanguageIdLesson == (int)ComboBoxLessonName.SelectedValue).ToList();
            }
            if (ComboBoxServiceName.SelectedIndex != -1)
            {
                students = students.Where(x => x.ServiceIdLesson == (int)ComboBoxServiceName.SelectedValue).ToList();
            }
            if (DatePickerDateLesson.SelectedDate != null)
            {
                students = students.Where(x => x.DateLesson == DatePickerDateLesson.SelectedDate).ToList();
            }
            if (CheckClass.TimeCheck(TextBoxTimeLesson.Text))
            {
                students = students.Where(x => x.TimeLesson == TimeSpan.Parse(TextBoxTimeLesson.Text)).ToList();
            }
            if (ComboBoxTeacherLesson.SelectedIndex != -1)
            {
                students = students.Where(x => x.Teacher.IdTeacher == (int)ComboBoxTeacherLesson.SelectedValue).ToList();
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
            ComboBoxLessonName.SelectedIndex = -1;
            DatePickerDateLesson.SelectedDate = null;
            TextBoxTimeLesson.Text = "";
            ComboBoxTeacherLesson.SelectedIndex = -1;
        }
        #endregion

        #region Добавление
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            int lesson = (int)ComboBoxLessonNameAdd.SelectedValue;
            DateTime date = (DateTime)DatePickerDateLessonAdd.SelectedDate;
            TimeSpan time = TimeSpan.Parse(TextBoxTimeLessonAdd.Text);
            int teacher = (int)ComboBoxTeacherLessonAdd.SelectedValue;

            Lesson newLesson = new Lesson
            {
                LanguageIdLesson = lesson,
                ServiceIdLesson = lesson,
            };

            db.context.Lesson.Add(newLesson);
            ClearEdit();
        }
        private void ButtonClearAdd_Click(object sender, RoutedEventArgs e)
        {
            ClearEdit();
        }
        private void ClearEdit()
        {
            ComboBoxLessonNameAdd.SelectedIndex = -1;
            DatePickerDateLessonAdd.SelectedDate = null;
            TextBoxTimeLessonAdd.Text = "";
            ComboBoxTeacherLessonAdd.SelectedIndex = -1;
        }
        #endregion

        #region Редактирование

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
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

            db.context.SaveChanges();
        }

        private void ButtonClearEdit_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxLessonNameEdit.SelectedIndex = -1;
            DatePickerDateLessonEdit.SelectedDate = null;
            TextBoxTimeLessonEdit.Text = "";
            ComboBoxTeacherLessonEdit.SelectedIndex = -1;
        }

        #endregion*/
    }
}
