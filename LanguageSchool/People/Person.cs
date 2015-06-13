using System;
using System.Collections.Generic;

namespace LanguageSchool.People
{
    using Interfaces.Person;
    using Enum.Person;
    using System.Text;

    public abstract class Person : IPerson
    {

        private static IList<IPerson> personList;
        private static ulong increaseId = 0;
        private ulong id;
        private string firstName;
        private string middleName;
        private string lastName;
        private string civilNumber;
        private DateTime birthDate;
        private string telephoneNumber;
        private string emailAddress;
        private string country;
        private string city;
        private DateTime registrationDate;
        private ESallaryType sallaryType;
        private decimal sallarySum;

        protected Person(string firstName, string middleName, string lastName, string civilNumber, DateTime birthDate,
            string telephoneNumber, string emailAddress, string country, string city, DateTime registrationDate, ESallaryType sallaryType,
            decimal sallarySum)
        {
            Person.increaseId++;
            this.id = increaseId;
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.CivilNumber = civilNumber;
            this.BirthDate = birthDate;
            this.TelephoneNumber = telephoneNumber;
            this.EmailAddress = emailAddress;
            this.Country = country;
            this.City = city;
            this.RegistrationDate = registrationDate;
            this.SallaryType = sallaryType;
            this.SallarySum = sallarySum;
        }

        public ulong Id
        {
            get
            {
                return this.id;
            }
        }

        public static IList<IPerson> PersonList
        {
            get
            {
                return Person.personList;
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return this.middleName;
            }
            set
            {
                this.middleName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
            }
        }

        public string CivilNumber
        {
            get
            {
                return this.civilNumber;
            }
            set
            {
                this.civilNumber = value;
            }
        }

        public DateTime BirthDate
        {
            get
            {
                return this.birthDate;
            }
            set
            {
                this.birthDate = value;
            }
        }

        public string TelephoneNumber
        {
            get
            {
                return this.telephoneNumber;
            }
            set
            {
                this.telephoneNumber = value;
            }
        }

        public string EmailAddress
        {
            get
            {
                return this.emailAddress;
            }
            set
            {
                this.emailAddress = value;
            }
        }

        public string Country
        {
            get
            {
                return this.country;
            }
            set
            {
                this.country = value;
            }
        }

        public string City
        {
            get
            {
                return this.city;
            }
            set
            {
                this.city = value;
            }
        }

        public DateTime RegistrationDate
        {
            get
            {
                return this.registrationDate;
            }
            set
            {
                this.registrationDate = value;
            }
        }

        public ESallaryType SallaryType
        {
            get
            {
                return this.sallaryType;
            }
            set
            {
                this.sallaryType = value;
            }
        }

        public decimal SallarySum
        {
            get
            {
                return this.sallarySum;
            }
            set
            {
                this.sallarySum = value;
            }
        }

        public static void Add(IPerson person)
        {
            Person.personList.Add(person);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0}", this.Id).AppendLine()
                .AppendFormat("{0}", this.FirstName).AppendLine()
                .AppendFormat("{0}", this.MiddleName).AppendLine()
                .AppendFormat("{0}", this.LastName).AppendLine()
                .AppendFormat("{0}", this.CivilNumber).AppendLine()
                .AppendFormat("{0}", this.BirthDate).AppendLine()
                .AppendFormat("{0}", this.TelephoneNumber).AppendLine()
                .AppendFormat("{0}", this.EmailAddress).AppendLine()
                .AppendFormat("{0}", this.Country).AppendLine()
                .AppendFormat("{0}", this.City).AppendLine()
                .AppendFormat("{0}", this.RegistrationDate).AppendLine()
                .AppendFormat("{0}", this.SallarySum);

            return sb.ToString();
        }
    }
}
