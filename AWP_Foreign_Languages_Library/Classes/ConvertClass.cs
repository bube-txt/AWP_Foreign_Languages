using System;
using System.Globalization;
using System.IO;
using System.Windows.Documents;
using System.Windows.Markup;

namespace AWP_Foreign_Languages_Library.Classes
{
    public class ConvertClass
    {
        public static string FormatedDate(DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }
        public static string FormatedTime(TimeSpan time)
        {
            return time.Hours + ":" + ((time.Minutes < 10) ? "0" + time.Minutes.ToString() : time.Minutes.ToString());
        }
        public static string RichTextToString(FlowDocument richText)
        {
            StringWriter wr = new StringWriter();
            XamlWriter.Save(richText, wr);
            string xaml = wr.ToString();
            return xaml;
        }
    }
}
