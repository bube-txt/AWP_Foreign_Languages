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

            if (selectedLesson != null)
            {
                TextBlockLessonName.Text = selectedLesson.LessonName;

                if (selectedLesson.HomeworkLesson != "")
                {
                    RichTextBoxHomeWork.Document = (FlowDocument)XamlReader.Parse(selectedLesson.HomeworkLesson);
                }
            }
        }

        private void ButtonEditConfirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string doc2str = new TextRange(RichTextBoxHomeWork.Document.ContentStart, RichTextBoxHomeWork.Document.ContentEnd).Text;
                db.context.Lesson.Where(x => x.IdLesson == selectedLesson.IdLesson).FirstOrDefault().HomeworkLesson = doc2str;
                db.context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
