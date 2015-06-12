using System;
using LanguageSchool.Enum.Course;

namespace LanguageSchool.Interfaces.Courses.Adults
{
    public interface ILanguageCourseForAdults : IAdultCourses
    {
        ELanguage Language { get; set; }
        ELanguageLevelForAdults LanguageLevel { get; set; }
    }
}
