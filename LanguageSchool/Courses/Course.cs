using LanguageSchool.Interfaces.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanguageSchool.Courses
{
    using Enum.Course;
    using Interfaces.Person;
    using LanguageSchool.People;

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
        private IList<IPerson> teachersInCourse;
        private IList<IClassInfo> conductedClasses = new List<IClassInfo>();

        protected Course(string courseName, ECourseActivityStatus activityStatus, EGroupType groupType, ECoursePlace coursePlace,
            decimal price, IList<IPerson> studentsInCourse, IList<IPerson> teachersInCourse, IList<IClassInfo> conductedClasses)
        {
            this.Id = ++Course.increaseId;
            this.CourseName = courseName;
            this.activityStatus = activityStatus;
            this.GroupType = groupType;
            this.coursePlace = coursePlace;
            this.Price = price;
            this.StudentsInCourse = studentsInCourse;
            this.TeachersInCourse = teachersInCourse;
            this.ConductedClasses = conductedClasses;
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

        public IList<IPerson> TeachersInCourse
        {
            get
            {
                return this.teachersInCourse;
            }
            set
            {
                this.teachersInCourse = value;
            }
        }

        public IList<IClassInfo> ConductedClasses
        {
            get
            {
                return this.conductedClasses;
            }
            set
            {
                this.conductedClasses = value;
            }
        }

        public static void Add(ICourse course)
        {
            Course.courseList.Add(course);
        }

        public void MakeActivityStatusToInactive()
        {
            this.ActivityStatus = ECourseActivityStatus.Inactive;
        }

        public void MakeActivityStatusToActive()
        {
            this.ActivityStatus = ECourseActivityStatus.Active;
        }

        public void AddStudentToCourse(CourseParticipant student)
        {
            this.studentsInCourse.Add(student);
        }

        public void AddTeachersToCourse(Teacher teacher)
        {
            this.teachersInCourse.Add(teacher);
        }

        public void PrintTeachersInCourse()
        {
            IList<IPerson> teachersInCourse = this.TeachersInCourse;

            foreach (var currentTeacher in teachersInCourse)
            {
                Console.WriteLine(currentTeacher.ToString());
                Console.WriteLine();
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void AddConductedClass(IClassInfo conductedClass)
        {
            this.conductedClasses.Add(conductedClass);
        }
    }
}
