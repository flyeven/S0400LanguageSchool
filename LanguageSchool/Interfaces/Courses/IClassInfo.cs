using LanguageSchool.Interfaces.Person.Types.Employee;
using System;

namespace LanguageSchool.Interfaces.Courses
{
    public interface IClassInfo
    {
        DateTime DateOfConduction { get; set; }

        DateTime ClassStartHour { get; set; }

        DateTime ClassEndHour { get; set; }

        double ClassLengthInMinutes { get; set; }

        double ConductedClassHours { get; set; }

        ITeacher Teacher { get; set; }

        ICourse Course { get; set; }
    }
}
