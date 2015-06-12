using System;
using LanguageSchool.Enum.Person;

namespace LanguageSchool.Interfaces.Person.Types
{
    public interface IClient : IPerson
    {
        EPersonType PersonType { get; set; }
    }
}
