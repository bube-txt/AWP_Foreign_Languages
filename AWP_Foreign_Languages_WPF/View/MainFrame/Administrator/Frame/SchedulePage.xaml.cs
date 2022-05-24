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
        Lesson lastSelected;
        public SchedulePage()
        {
            InitializeComponent();

            Update();

            InitContextMenu();


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

        private void InitContextMenu()
        {
            MenuItem menuItem = new MenuItem();
            menuItem.Header = "Смотреть ДЗ";
            menuItem.Click += ButtonHomeWorkView_Click;
            ContextMenuDataGrid.Items.Add(menuItem);

            menuItem = new MenuItem();
            menuItem.Header = "Добавить ДЗ";
            menuItem.Click += ButtonHomeWorkAdd_Click;
            ContextMenuDataGrid.Items.Add(menuItem);

            MenuItem menuItem1 = new MenuItem();
            menuItem1.Header = "Удалить";
            menuItem1.Name = "MenuItemDelete";
            menuItem1.Click += ButtonHomeWorkView_Click;
            ContextMenuDataGrid.Items.Add(menuItem1);

            menuItem = new MenuItem();
            menuItem.Header = "Подтвердить";
            menuItem.Click += ButtonHomeWorkView_Click;
            menuItem1.Items.Add(menuItem);
        }

        private void Update()
        {
            lessons = db.context.Lesson.ToList();
            DataGridSchedule.ItemsSource = lessons;
        }

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
            DatePickerDateLesson.SelectedDate = null;
            TextBoxTimeLesson.Text = "";
            ComboBoxTeacherLesson.SelectedIndex = -1;
        }
        #endregion

        #region Добавление
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int lesson = (int)ComboBoxLessonNameAdd.SelectedValue;
                int service = (int)ComboBoxServiceNameAdd.SelectedValue;
                DateTime date = (DateTime)DatePickerDateLessonAdd.SelectedDate;
                TimeSpan time = TimeSpan.Parse(TextBoxTimeLessonAdd.Text);
                int teacher = (int)ComboBoxTeacherLessonAdd.SelectedValue;

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

                Update();
                ClearEdit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ButtonClearAdd_Click(object sender, RoutedEventArgs e)
        {
            ClearEdit();
        }
        private void ClearEdit()
        {
            ComboBoxLessonNameAdd.SelectedIndex = -1;
            ComboBoxServiceNameAdd.SelectedIndex = -1;
            DatePickerDateLessonAdd.SelectedDate = null;
            TextBoxTimeLessonAdd.Text = "";
            ComboBoxTeacherLessonAdd.SelectedIndex = -1;
        }
        #endregion



        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonClearEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
