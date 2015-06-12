using System;
using LanguageSchool.Enum.Course;

namespace LanguageSchool.Interfaces.Courses.Children
{
    public interface ILanguageCourseForAdults : IChildrenCourses
    {
        ELanguage Language { get; set; }
        ELanguageLevelForChildren LanguageLevel { get; set; }
    }
}
