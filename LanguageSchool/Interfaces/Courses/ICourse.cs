﻿using System;
using LanguageSchool.Enum.Course;
using System.Collections.Generic;

namespace LanguageSchool.Interfaces.Courses
{
    using Person;

    public interface ICourse
    {
        IList<ICourse> courseList { get; set; }

        ulong Id { get; set; }

        string CourseName { get; set; }

        ECourseActivityStatus ActivityStatus { get; set; }

        EGroupType GroupType { get; set; }

        ECoursePlace CoursePlace { get; set; }

        decimal Price { get; set; }

        IList<IPerson> StudentsInCourse { get; set; }

        IList<IConductedClasses> ConductedClasses { get; set; }

        void Add(ICourse course);
    }
}