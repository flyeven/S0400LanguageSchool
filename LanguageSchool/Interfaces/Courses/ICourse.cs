using System;
using LanguageSchool.Enum.Course;
using System.Collections.Generic;

namespace LanguageSchool.Interfaces.Courses
{
    using Person;
    using LanguageSchool.People;

    public interface ICourse
    {
        ulong Id { get; }

        string CourseName { get; set; }

        IList<IPerson> TeachersInCourse
        {
            get;
            set;
        }

        ECourseActivityStatus ActivityStatus { get; set; }

        EGroupType GroupType { get; set; }

        ECoursePlace CoursePlace { get; set; }

        decimal Price { get; set; }

        IList<IPerson> StudentsInCourse { get; set; }

        IList<IClassInfo> ConductedClasses { get; set; }

        void PrintTeachersInCourse();

        void AddStudentToCourse(CourseParticipant student);

        void AddTeachersToCourse(Teacher teacher);

        void AddConductedClass(IClassInfo conductedClass);
    }
}
