using System;
using System.Collections.Generic;
using System.Linq;
using LanguageSchool.Interfaces.Person.Types.Client;
using LanguageSchool.Enum.Person;

namespace LanguageSchool.People
{
    class CourseParticipant : Client, ICourseParticipant
    {
        private string clientType;

        public CourseParticipant(ulong id, string firstName, string middleName, string lastName, string civilNumber, DateTime birthDate,
            string telephoneNumber, string emailAddress, string country, string city, DateTime registrationDate, ESallaryType sallaryType,
            decimal sallarySum)
            : base(id, firstName, middleName, lastName, civilNumber, birthDate, telephoneNumber, emailAddress, country, city,
            registrationDate, sallaryType, sallarySum)
        {

        }

        public string ClientType
        {
            get
            {
                return this.clientType;
            }
            set
            {
                this.clientType = "course_participant";
            }
        }
    }
}
