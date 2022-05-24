using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AWP_Foreign_Languages_Library.Classes;
using AWP_Foreign_Languages_WPF.Models;

namespace AWP_Foreign_Languages_WPF.Models
{
    partial class Lesson
    {
        Core db = new Core();
        public string TeacherFullName
        {
            get
            {
                return Teacher.User.FullName;
            }
        }
        public string LessonName
        {
            get
            {
                return Teacher.Language.NameLanguage;
            }
        }
        public string ServiceName
        {
            get
            {
                return db.context.Service.Where(x => x.IdService == ServiceIdLesson).FirstOrDefault().NameService;
            }
        }
        public string FormatedLessonDate
        {
            get
            {
                return ConvertClass.FormatedDate(DateLesson);
            }
        }
        public string FormatedLessonTime
        {
            get
            {
                return ConvertClass.FormatedTime(TimeLesson);
            }
        }

    }
}
