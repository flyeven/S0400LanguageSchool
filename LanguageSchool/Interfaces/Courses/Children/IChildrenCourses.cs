using System;
using LanguageSchool.Enum.Course;

namespace LanguageSchool.Interfaces.Courses.Children
{
    public interface IChildrenCourses : ICourse
    {
        EAge Age { get; set; }
    }
}
