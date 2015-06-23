using LanguageSchool.Interfaces.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanguageSchool.Courses
{
    using Enum.Course;
    using Interfaces.Person;

    public abstract class Course : ICourse
    {
        private static IList<ICourse> courseList = new List<ICourse>();
        private static ulong increaseId = 0;
        private ulong id;
        private string courseName;
        private ECourseActivityStatus activityStatus;
        private EGroupType groupType;
        private ECoursePlace coursePlace;
        private decimal price;
        private IList<IPerson> studentsInCourse;
        private IList<IConductedClasses> counductedClasses;

        protected Course(string courseName, ECourseActivityStatus activityStatus, EGroupType groupType, ECoursePlace coursePlace,
            decimal price, IList<IPerson> studentsInCourse, IList<IConductedClasses> conductedClasses)
        {
            this.Id = ++Course.increaseId;
            this.CourseName = CourseName;
            this.activityStatus = activityStatus;
            this.GroupType = groupType;
            this.coursePlace = coursePlace;
            this.Price = price;
            this.StudentsInCourse = studentsInCourse;
            this.ConductedClasses = counductedClasses;
        }

        public static IList<ICourse> CourseList
        {
            get
            {
                return Course.courseList;
            }
        }

        public ulong Id
        {
            get 
            {
                return this.id;
            }
            private set
            {
                this.id = value;
            }
        }

        public string CourseName
        {
            get
            {
                return this.courseName;
            }
            set
            {
                this.courseName = value;
            }
        }

        public ECourseActivityStatus ActivityStatus
        {
            get
            {
                return this.activityStatus;
            }
            set
            {
                this.activityStatus = value;
            }
        }

        public EGroupType GroupType
        {
            get
            {
                return this.groupType;
            }
            set
            {
                this.groupType = value;
            }
        }

        public ECoursePlace CoursePlace
        {
            get
            {
                return this.coursePlace;
            }
            set
            {
                this.coursePlace = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
            }
        }

        public IList<IPerson> StudentsInCourse
        {
            get
            {
                return this.studentsInCourse;
            }
            set
            {
                this.studentsInCourse = value;
            }
        }

        public IList<IConductedClasses> ConductedClasses
        {
            get
            {
                return this.counductedClasses;
            }
            set
            {
                this.counductedClasses = value;
            }
        }

        public static void Add(ICourse course)
        {
            Course.courseList.Add(course);
        }
    }
}
