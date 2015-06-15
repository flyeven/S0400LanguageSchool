using LanguageSchool.Enum.Person;
using LanguageSchool.Interfaces.Person.Types.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchool.People
{
    class Secretary : Employee, ISecretary
    {
        string employeeType;

        public Secretary(string firstName, string middleName, string lastName, string civilNumber, DateTime birthDate,
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
                this.employeeType = "secretary";
            }
        }
    }
}
