using System;
using LanguageSchool.Enum.Person;
using System.Collections.Generic;

namespace LanguageSchool.Interfaces.Person
{
    public interface IPerson
    {
        ulong Id { get; }

        string FirstName { get; set; }

        string MiddleName { get; set; }

        string LastName { get; set; }

        string CivilNumber { get; set; }

        DateTime BirthDate { get; set; }

        string TelephoneNumber { get; set; }

        string EmailAddress { get; set; }

        string Country { get; set; }

        string City { get; set; }

        DateTime RegistrationDate { get; set; }

        ESallaryType SallaryType { get; set; }

        decimal SallarySum { get; set; }
    }
}
