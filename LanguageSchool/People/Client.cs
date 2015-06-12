using System;
using LanguageSchool.Interfaces.Person.Types;
using LanguageSchool.Enum.Person;

namespace LanguageSchool.People
{
    public abstract class Client : Person, IClient
    {
        private EPersonType personType;

        protected Client(ulong id, string firstName, string middleName, string lastName, string civilNumber, DateTime birthDate,
            string telephoneNumber, string emailAddress, string country, string city, DateTime registrationDate, ESallaryType sallaryType,
            decimal sallarySum)
            : base(id, firstName, middleName, lastName, civilNumber, birthDate, telephoneNumber, emailAddress, country, city, registrationDate,
            sallaryType, sallarySum)
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
                this.personType = EPersonType.Client;
            }
        }
    }
}
