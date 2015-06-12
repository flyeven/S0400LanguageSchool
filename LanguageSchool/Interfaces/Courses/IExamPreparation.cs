using System;
using System.Collections;
using LanguageSchool.Enum.Course;

namespace LanguageSchool.Interfaces.Courses
{
    public interface IExamPreparation : ICourse
    {
        EExams ExamName { get; set; }
    }
}