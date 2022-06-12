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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AWP_Foreign_Languages_WPF.View.MainFrame.Teachers
{
    /// <summary>
    /// Логика взаимодействия для HomeworkPage.xaml
    /// </summary>
    public partial class HomeworkPage : Page
    {
        Core db = new Core();
        Attendance selectedAttendance = App.SelectedAttendance;
        Lesson selectedLesson = App.SelectedLesson;
        public HomeworkPage()
        {
            InitializeComponent();
            if (selectedAttendance != null)
            {
                TextBlockLessonName.Text = selectedAttendance.LessonName;
                TextBlockServiceName.Text = selectedAttendance.Lesson.ServiceName;
                TextBlockTeacherName.Text = selectedAttendance.Lesson.TeacherFullName;

                if (!String.IsNullOrEmpty(selectedAttendance.Lesson.HomeworkLesson))
                {
                    try
                    {
                        RichTextBoxHomeWork.Document = (FlowDocument)XamlReader.Parse(selectedAttendance.Lesson.HomeworkLesson);
                    }
                    catch
                    {
                        RichTextBoxHomeWork.Document = null;
                    }
                }
            }
        }
        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            App.MF.NavigationService.GoBack();
        }

        private void ButtonEditConfirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string doc2str = ConvertClass.RichTextToString(RichTextBoxHomeWork.Document);
                db.context.Lesson.Where(x => x.IdLesson == selectedLesson.IdLesson).FirstOrDefault().HomeworkLesson = doc2str;
                db.context.SaveChanges();
                MessageBox.Show("Домашнее задание сохранено успешно!");

                if (!String.IsNullOrEmpty(selectedAttendance.Lesson.HomeworkLesson))
                {
                    try
                    {
                        RichTextBoxHomeWork.Document = (FlowDocument)XamlReader.Parse(selectedAttendance.Lesson.HomeworkLesson);
                    }
                    catch
                    {
                        RichTextBoxHomeWork.Document = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
