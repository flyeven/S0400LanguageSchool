using System;

namespace LanguageSchool.Interfaces.Courses
{
    public interface IMaturityExamination : ICourse
    {
        string maturityExaminationLevel { get; set; }

        string MaturityExaminationSubject { get; set; }
    }
}
