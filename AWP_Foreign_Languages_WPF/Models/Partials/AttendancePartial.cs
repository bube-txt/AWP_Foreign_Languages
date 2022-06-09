using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWP_Foreign_Languages_WPF.Models
{
    partial class Attendance
    {
        Core db = new Core();
        public string GetStatus
        {
            get
            {
                if (BoolAttendance == 1)
                {
                    return "Присутствует";
                }
                else
                {
                    return "Отсутствует";
                }
            }
        }
        public string GetGroup
        {
            get
            {
                ClientGroup clientGroup = db.context.ClientGroup.Where(x => x.IdClient == IdClient).FirstOrDefault();
                if (clientGroup == null)
                {
                    return "Ошибка";
                }
                else
                {
                    return clientGroup.Group.NameGroup;
                }
            }
        }
        public string FullName
        {
            get
            {
                return Client.FullName;
            }
        }
        public string LessonName
        {
            get
            {
                return Lesson.LessonName;
            }
        }
        public string LessonDate
        {
            get
            {
                return Lesson.FormatedLessonDate;
            }
        }
        public string LessonTime
        {
            get
            {
                return Lesson.FormatedLessonTime;
            }
        }
        public string LessonTeacher
        {
            get
            {
                return Lesson.TeacherFullName;
            }
        }
    }
}
