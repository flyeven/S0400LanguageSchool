using LanguageSchool.Enum.Course;
using LanguageSchool.Interfaces.Courses;
using LanguageSchool.Interfaces.Courses.Children;
using LanguageSchool.Interfaces.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchool.Courses
{
    public abstract class ChildrenCourse : Course, IChildrenCourses
    {
        private EAge age;

        protected ChildrenCourse(string courseName, ECourseActivityStatus activityStatus, EGroupType groupType, ECoursePlace coursePlace,
            decimal price, IList<IPerson> studentsInCourse, IList<IPerson> teachersInCourse,  IList<IConductedClasses> conductedClasses, EAge age)
            : base(courseName, activityStatus, groupType, coursePlace, price, studentsInCourse, teachersInCourse, conductedClasses)
        {
            this.Age = age;
        }

        public EAge Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }
    }
}
