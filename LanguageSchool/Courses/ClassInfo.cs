using LanguageSchool.Interfaces.Courses;
using LanguageSchool.Interfaces.Person.Types.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchool.Courses
{
    public class ClassInfo : IClassInfo
    {
        private DateTime dateOfConduction;
        private DateTime classStartHour;
        private DateTime classEndHour;
        private double classLengthInMinutes;
        private double conductedClassHours;
        private ITeacher teacher;
        private ICourse course;

        public ClassInfo(DateTime dateOfConduction, DateTime  classStartHour, DateTime classEndHour, ITeacher teacher, ICourse course)
        {
            this.DateOfConduction = dateOfConduction;
            this.ClassStartHour = classStartHour;
            this.ClassEndHour = classEndHour;
            this.ClassLengthInMinutes = CalculateClassLengthInMinutes(this.ClassStartHour, this.ClassEndHour);
            this.Teacher = teacher;
            this.Course = course;
        }

        public DateTime DateOfConduction
        {
            get
            {
                return this.dateOfConduction;
            }
            set
            {
                this.dateOfConduction = value;
            }
        }

        public DateTime ClassStartHour
        {
            get
            {
                return this.classStartHour;
            }
            set
            {
                this.classStartHour = value;
            }
        }

        public DateTime ClassEndHour
        {
            get
            {
                return this.classEndHour;
            }
            set
            {
                this.classEndHour = value;
            }
        }

        public double ClassLengthInMinutes
        {
            get
            {
                return this.classLengthInMinutes;
            }
            set
            {
                this.classLengthInMinutes = value;
            }
        }

        public double ConductedClassHours
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public ITeacher Teacher
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public ICourse Course
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        private double CalculateClassLengthInMinutes(DateTime start, DateTime end)
        {
            double minutes = end.Date.Hour - start.Date.Hour;

            return 0;
        }
    }
}
