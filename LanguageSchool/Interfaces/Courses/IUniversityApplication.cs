using System;

namespace LanguageSchool.Interfaces.Courses
{
    public interface IUniversityApplication : ICourse
    {
        string UniversityApplicationSubject { get; set; }
    }
}
