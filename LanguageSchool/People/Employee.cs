using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LanguageSchool.Interfaces.Person.Types;
using LanguageSchool.Enum.Person;

namespace LanguageSchool.People
{
    public abstract class Employee : Person, IEmployee
    {
        private EPersonType personType;

        protected Employee(string firstName, string middleName, string lastName, string civilNumber, DateTime birthDate,
            string telephoneNumber, string emailAddress, string country, string city, DateTime registrationDate, ESallaryType sallaryType,
            decimal sallarySum)
            : base(firstName, middleName, lastName, civilNumber, birthDate, telephoneNumber, emailAddress, country, city,
            registrationDate, ESallaryType.Monthly, sallarySum)
        {

        }

        public EPersonType PersonType
        {
            get
            {
                return this.personType;
            }
            set
            {
                this.PersonType = EPersonType.Employee;
            }
        }
    }
}
