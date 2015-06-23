using System;
using System.Collections.Generic;
using System.Linq;

namespace LanguageSchool.People
{
    using Interfaces.Person;
    using Enum.Person;
    using System.Text;
    using LanguageSchool.Interfaces.Person.Types;

    public abstract class Person : IPerson
    {

        private static IList<IPerson> personList = new List<IPerson>();
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

        public virtual ulong Id
        {
            get;
            protected set;
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

        public static List<IPerson> GetAllTeachers()
        {

            List<IPerson> teachers = new List<IPerson>();
            IList<IPerson> persons = Person.personList;

            foreach (var item in persons)
            {
                string teacher = item.GetType().Name;
                if (teacher == "Teacher")
                {
                    teachers.Add(item);
                }
            }

            return teachers;
        }

        public static List<IPerson> GetAllCourseParticipants()
        {
            List<IPerson> participants = new List<IPerson>();
            IList<IPerson> persons = Person.personList;

            foreach (var item in persons)
            {
                string courseParticipant = item.GetType().Name;
                if (courseParticipant == "CourseParticipant")
                {
                    participants.Add(item);
                }
            }

            return participants;
        }

        public static List<IPerson> GetAllSecretaries()
        {
            List<IPerson> secretaries = new List<IPerson>();

            IList<IPerson> persons = Person.personList;

            foreach (var item in persons)
            {
                string secretary = item.GetType().Name;
                if (secretary == "Secretary")
                {
                    secretaries.Add(item);
                }
            }

            return secretaries;
        }

        public static List<IPerson> GetAllClients()
        {
            List<IPerson> clientsOutput = new List<IPerson>();
            IList<IPerson> clients = Person.personList;

            foreach (var item in clients)
            {
                string client = item.GetType().BaseType.ToString().Split('.')[2];
                if (client == "Client")
                {
                    clientsOutput.Add(item);
                }
            }

            return clientsOutput;
        }

        public static List<IPerson> GetAllEmployees()
        {
            List<IPerson> outputEmployees = new List<IPerson>();
            IList<IPerson> employees = Person.personList;

            foreach (var item in employees)
            {
                string employee = item.GetType().BaseType.ToString().Split('.')[2];
                if (employee == "Employee")
                {
                    outputEmployees.Add(item);
                }
            }

            return outputEmployees;
        }
    }
}
