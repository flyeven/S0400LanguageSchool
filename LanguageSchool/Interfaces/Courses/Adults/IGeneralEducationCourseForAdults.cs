using System;
using LanguageSchool.Enum.Course;

namespace LanguageSchool.Interfaces.Courses.Adults
{
    public interface IGeneralEducationCourseForAdults : IAdultCourses
    {
        EGeneralEducationSubjects GeneralEducationSubject { get; set; }
    }
}
