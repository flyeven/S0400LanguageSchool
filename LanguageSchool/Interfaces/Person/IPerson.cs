using System;
using LanguageSchool.Enum.Person;
using System.Collections.Generic;

namespace LanguageSchool.Interfaces.Person
{
    public interface IPerson
    {
        IList<IPerson> personList { get; set; }

        ulong Id { get; set; }

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

        ESalaryType SalaryType { get; set; }

        decimal SallarySum { get; set; }

        void Add(IPerson person);
    }
}
