using System;
using LanguageSchool.Enum.Course;

namespace LanguageSchool.Interfaces.Courses.Adults
{
    public interface IComputerCourseForAdults : IAdultCourses
    {
        EComputerLanguage ComputerLanguage { get; set; }
    }
}
