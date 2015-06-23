using System;
using LanguageSchool.Interfaces.Person.Types;
using LanguageSchool.Enum.Person;

namespace LanguageSchool.People
{
    public abstract class Client : Person, IClient
    {
        private EPersonType personType;
        private ulong id;
        public static ulong increaseId = 0;

        protected Client(string firstName, string middleName, string lastName, string civilNumber, DateTime birthDate,
            string telephoneNumber, string emailAddress, string country, string city, DateTime registrationDate, ESallaryType sallaryType,
            decimal sallarySum)
            : base(firstName, middleName, lastName, civilNumber, birthDate, telephoneNumber, emailAddress, country, city, registrationDate,
            sallaryType, sallarySum)
        {
            Client.increaseId++;
            this.Id = Client.increaseId;
        }

        public EPersonType PersonType
        {
            get
            {
                return this.personType;
            }
            set
            {
                this.personType = EPersonType.Client;
            }
        }

        public override ulong Id
        {
            get
            {
                return this.id;
            }
            protected set
            {
                this.id = value;
            }
        }
    }
}
