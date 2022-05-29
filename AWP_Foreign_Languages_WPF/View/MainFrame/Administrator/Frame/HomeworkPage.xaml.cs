using AWP_Foreign_Languages_Library.Classes;
using AWP_Foreign_Languages_WPF.Assets.Enums;
using AWP_Foreign_Languages_WPF.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;

namespace AWP_Foreign_Languages_WPF.View.MainFrame.Administrator.Frame
{
    /// <summary>
    /// Логика взаимодействия для HomeworkPage.xaml
    /// </summary>
    public partial class HomeworkPage : Page
    {
        Core db = new Core();
        Lesson selectedLesson = App.SelectedLesson;
        public HomeworkPage()
        {
            InitializeComponent();

            if (App.ActiveUser.Role.NameRole == RolesEnum.Client)
            {
                ButtonEditConfirm.Visibility = Visibility.Collapsed;
                RichTextBoxHomeWork.IsReadOnly = true;
            }

            if (selectedLesson != null)
            {
                TextBlockLessonName.Text = selectedLesson.LessonName;
                TextBlockServiceName.Text = selectedLesson.ServiceName;
                TextBlockTeacherName.Text = selectedLesson.TeacherFullName;

                if (!String.IsNullOrEmpty(selectedLesson.HomeworkLesson))
                {
                    RichTextBoxHomeWork.Document = (FlowDocument)XamlReader.Parse(selectedLesson.HomeworkLesson);
                }
            }
        }

        private void ButtonEditConfirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string doc2str = ConvertClass.RichTextToString(RichTextBoxHomeWork.Document);
                db.context.Lesson.Where(x => x.IdLesson == selectedLesson.IdLesson).FirstOrDefault().HomeworkLesson = doc2str;
                db.context.SaveChanges();
                MessageBox.Show("Домашнее задание сохранено успешно!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            if (App.ActiveUser.Role.NameRole == RolesEnum.Client)
            {
                App.MF.Content = new SchedulePage(); // UNDONE: Когда будет пользователь доработан - переделать!
            }
            else
            {
                App.MF.Content = new SchedulePage();
            }
        }
    }
}
