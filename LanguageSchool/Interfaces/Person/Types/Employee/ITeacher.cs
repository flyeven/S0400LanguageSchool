using System;
using System.Collections.Generic;

namespace LanguageSchool.Interfaces.Person.Types.Employee
{
    public interface ITeacher : IEmployee
    {
        string EmployeeType { get; set; }

        IList<string> teachingSubjects { get; set; }
    }
}
