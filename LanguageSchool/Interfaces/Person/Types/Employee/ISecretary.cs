using System;

namespace LanguageSchool.Interfaces.Person.Types.Employee
{
    public interface ISecretary : IEmployee
    {
        string EmployeeType { get; set; }
    }
}
