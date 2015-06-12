using System;

namespace LanguageSchool.Interfaces.Courses
{
    public interface IConductedClasses
    {
        ulong ClassId { get; set; }

        ulong TeacherId { get; set; }

        ulong CourseId { get; set; }

        IClassInfo ClassInfo { get; set; }
    }
}
