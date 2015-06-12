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
    }
}
