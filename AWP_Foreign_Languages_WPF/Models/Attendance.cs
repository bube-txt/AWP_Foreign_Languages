//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AWP_Foreign_Languages_WPF.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Attendance
    {
        public int IdAttendance { get; set; }
        public int IdClient { get; set; }
        public int IdLesson { get; set; }
        public Nullable<byte> BoolAttendance { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Lesson Lesson { get; set; }
    }
}
