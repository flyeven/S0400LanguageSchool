using LanguageSchool.Enum.Course;
using LanguageSchool.Interfaces.Courses;
using LanguageSchool.Interfaces.Courses.Adults;
using LanguageSchool.Interfaces.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchool.Courses
{
    public class LanguageCourseForAdults : AdultCourse, ILanguageCourseForAdults
    {
        private ELanguage language;
        private ELanguageLevelForAdults languageLevel;

        public LanguageCourseForAdults(string courseName, ECourseActivityStatus activityStatus, EGroupType groupType, ECoursePlace coursePlace,
            decimal price, IList<IPerson> studentsInCourse, IList<IConductedClasses> conductedClasses, EAge age, ELanguage language, 
            ELanguageLevelForAdults languageLevelForAdults)
            : base(courseName, activityStatus, groupType, coursePlace, price, studentsInCourse, conductedClasses, age)
        {
            this.Language = language;
            this.LanguageLevel = languageLevelForAdults;
        }

        public ELanguage Language
        {
            get
            {
                return this.language;
            }
            set
            {
                this.language = value;
            }
        }

        public ELanguageLevelForAdults LanguageLevel
        {
            get
            {
                return this.languageLevel;
            }
            set
            {
                this.languageLevel = value;
            }
        }
    }
}
