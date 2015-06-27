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

        public static void RenderCourseClassesOnTheConsole(ICourse courseWithClasses)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CourseID {0}", courseWithClasses.Id).AppendLine();
            sb.AppendFormat("Course Name: {0}", courseWithClasses.CourseName).AppendLine().AppendLine().AppendLine();
            sb.AppendFormat("{0}", "COUNDUCTED CLASSES: ").AppendLine().AppendLine();

            foreach (var course in courseWithClasses.ConductedClasses)
            {
                sb.AppendFormat("Date:{0}.{1}.{2} Start:[{4}:{5}] End:[{6}:{7}] Hours:{3} Teacher:({8} {9})", 
                    course.DateOfConduction.Day, course.DateOfConduction.Month, 
                    course.DateOfConduction.Year, 
                    course.ConductedClassHours, 
                    course.ClassStartHour.Hour, course.ClassStartHour.Minute,
                    course.ClassEndHour.Hour, course.ClassEndHour.Minute,
                    course.Teacher.FirstName, course.Teacher.LastName).AppendLine();
            }

            sb.AppendLine().AppendLine().AppendLine();

            string str = sb.ToString();

            Console.WriteLine(str);
        }

        public static void PrintTotalHoursInCourses()
        {
            foreach (var item in Courses.Course.CourseList)
            {
                Console.WriteLine("CourseID:{0} CourseName:{1} TotalHoursTaken:{2}", item.Id, item.CourseName, item.CalculateTotalHoursInCourse());
            }
        }
    }
}
