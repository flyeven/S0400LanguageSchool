using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageSchool.Interfaces.Person.Types.Employee;
using LanguageSchool.Enum.Person;

namespace LanguageSchool.People
{
    public class Teacher : Employee, ITeacher
    {
        private string employeeType;
        private List<string> teachingSubjects;

        public Teacher(string firstName, string middleName, string lastName, string civilNumber, DateTime birthDate,
            string telephoneNumber, string emailAddress, string country, string city, DateTime registrationDate, ESallaryType sallaryType,
            decimal sallarySum)
            : base(firstName, middleName, lastName, civilNumber, birthDate, telephoneNumber, emailAddress, country,
            city, registrationDate, Enum.Person.ESallaryType.Monthly, sallarySum)
        {

        }

        public string EmployeeType
        {
            get
            {
                return this.employeeType;
            }
            set
            {
                this.employeeType = value;
            }
        }

        public IList<string> TeachingSubjects
        {
            get
            {
                return this.teachingSubjects;
            }
            set
            {
                this.TeachingSubjects = value;
            }
        }
    }
}
