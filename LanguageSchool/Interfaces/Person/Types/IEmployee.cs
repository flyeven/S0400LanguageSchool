using System;
using LanguageSchool.Enum.Person;

namespace LanguageSchool.Interfaces.Person.Types
{
    public interface IEmployee : IPerson
    {
        EPersonType PersonType { get; set; }
    }
}
