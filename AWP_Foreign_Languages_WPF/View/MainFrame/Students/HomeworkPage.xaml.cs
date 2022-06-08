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

namespace AWP_Foreign_Languages_WPF.View.MainFrame.Students
{
    /// <summary>
    /// Логика взаимодействия для HomeworkPage.xaml
    /// </summary>
    public partial class HomeworkPage : Page
    {
        Attendance selectedAttendance = App.SelectedAttendance;
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
            App.MF.Content = new AttendancesPage();
        }
    }
}
