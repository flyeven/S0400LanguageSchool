using System;
using LanguageSchool.Enum.Course;

namespace LanguageSchool.Interfaces.Courses.Children
{
    public interface IGeneralEducationCourseForAdults : IChildrenCourses
    {
        EGeneralEducationSubjects GeneralEducationSubject { get; set; }
    }
}
