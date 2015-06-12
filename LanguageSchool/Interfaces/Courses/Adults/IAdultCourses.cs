using System;
using LanguageSchool.Enum.Course;

namespace LanguageSchool.Interfaces.Courses.Adults
{
    public interface IAdultCourses : ICourse
    {
        EAge Age { get; set; }
    }
}
