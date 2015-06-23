using LanguageSchool.Enum.Course;
using LanguageSchool.Interfaces.Courses;
using LanguageSchool.Interfaces.Courses.Adults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanguageSchool.Courses
{
    using Enum.Course;
    using Interfaces.Person;

    public abstract class AdultCourse : Course, IAdultCourses
    {
        private EAge age;

        protected AdultCourse(string courseName, ECourseActivityStatus activityStatus, EGroupType groupType, ECoursePlace coursePlace,
            decimal price, IList<IPerson> studentsInCourse, IList<IConductedClasses> conductedClasses, EAge age)
            : base(courseName, activityStatus, groupType, coursePlace, price, studentsInCourse, conductedClasses)
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
