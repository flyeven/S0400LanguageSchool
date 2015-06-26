using LanguageSchool.Enum.Course;
using LanguageSchool.Interfaces.Courses;
using LanguageSchool.Interfaces.Courses.Children;
using LanguageSchool.Interfaces.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchool.Courses
{
    public class LanguageCourseForChildren : ChildrenCourse, ILanguageCourseForChildren
    {
        private ELanguage language;
        private ELanguageLevelForChildren languageLevel;

        public LanguageCourseForChildren(string courseName, ECourseActivityStatus activityStatus, EGroupType groupType, ECoursePlace coursePlace,
            decimal price, IList<IPerson> studentsInCourse, IList<IPerson> teachersInCourse, IList<IClassInfo> conductedClasses, EAge age, ELanguage language, 
            ELanguageLevelForChildren languageLevelForChildren)
            : base(courseName, activityStatus, groupType, coursePlace, price, studentsInCourse, teachersInCourse, conductedClasses, age)
        {
            this.Language = language;
            this.LanguageLevel = languageLevelForChildren;
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

        public ELanguageLevelForChildren LanguageLevel
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
