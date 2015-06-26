using LanguageSchool.Enum.Course;
using LanguageSchool.Interfaces.Courses;
using LanguageSchool.Interfaces.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchool
{
    public class ConsoleRenderer
    {
        public static string RenderCourseToConsole(string courseType, ulong id, string courseName, ECourseActivityStatus activityStatus, 
            EGroupType groupType, ECoursePlace coursePlace,
            decimal price, IList<IPerson> studentsInCourse, IList<IPerson> teachersInCourse, 
            EAge age, ECoursePlace place, ELanguage language,
            ELanguageLevelForAdults languageLevelForAdults)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(new string('*', 30));
            sb.AppendLine(new string('*', 30));
            sb.AppendFormat("{0}", courseType).AppendLine();
            sb.AppendFormat("{0}", id).AppendLine();
            sb.AppendFormat("{0}", courseName).AppendLine();
            sb.AppendFormat("{0}", activityStatus).AppendLine();
            sb.AppendFormat("{0}", groupType).AppendLine();
            sb.AppendFormat("{0}", coursePlace).AppendLine();
            sb.AppendFormat("{0}", age).AppendLine();
            sb.AppendFormat("{0}", language).AppendLine();
            sb.AppendFormat("{0}", languageLevelForAdults).AppendLine();
            sb.AppendFormat("{0} lev(s)", price).AppendLine().AppendLine();

            sb.AppendLine(new string('-', 30));

            sb.AppendLine("Teachers leading the course: ").AppendLine();
            foreach (var teacher in teachersInCourse)
            {
                sb.AppendFormat("{0}", teacher.ToString()).AppendLine().AppendLine();
            }
            sb.AppendLine(new string('-', 30));
            sb.AppendLine().AppendLine();

            sb.AppendLine(new string('-', 30));
            sb.AppendLine("Students taking part in the course: ").AppendLine();
            foreach (var student in studentsInCourse)
            {
                sb.AppendFormat("{0}", student.ToString()).AppendLine().AppendLine();
            }
            sb.AppendLine(new string('-', 30));

            sb.AppendLine().AppendLine();
            sb.AppendLine(new string('*', 30));
            sb.AppendLine(new string('*', 30));

            return sb.ToString();
        }
    }
}
