using LanguageSchool.Enum.Course;
using LanguageSchool.Interfaces.Person;
using LanguageSchool.People;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchool.Courses
{
    public static class CourseInputer
    {
        public static string CourseNameCreator(string courseName)
        {
            string name = courseName.ToLower();
            char[] arr = name.ToCharArray();
            char first = char.Parse(arr[0].ToString().ToUpper());
            arr[0] = first;
            string outputString = new string(arr);
            return outputString;
        }

        public static ECourseActivityStatus CourseActivityCreator(string activity)
        {
            ECourseActivityStatus activityStatus = (activity == "active") ? ECourseActivityStatus.Active : ECourseActivityStatus.Inactive;

            return activityStatus;
        }

        public static EGroupType GroupTypeCreator(string type)
        {
            string[] str = type.Split('_');
            EGroupType output = EGroupType.Individual;

            if (str[0] == "individual")
            {
                output = EGroupType.Individual;
            }
            else
            {
                switch(str[1])
                {
                    case "2":
                        output = EGroupType.Group2;
                        break;
                    case "3":
                        output = EGroupType.Group3;
                        break;
                    case "4":
                        output = EGroupType.Group4;
                        break;
                    case "5":
                        output = EGroupType.Group5;
                        break;
                    case "6":
                        output = EGroupType.Group6;
                        break;
                    case "7":
                        output = EGroupType.Group7;
                        break;
                    case "8":
                        output = EGroupType.Group8;
                        break;
                    case "over8":
                        output = EGroupType.GroupOver8;
                        break;
                }
            }

            return output;
        }

        public static IList<IPerson> GetCoursistsInCourse(string coursists)
        {
            IList<IPerson> outputCoursists = new List<IPerson>();

            string[] coursistStringArray = coursists.Split(',');

            IList<IPerson> allClients = new List<IPerson>();

            allClients = Person.GetAllCourseParticipants();

            foreach (string coursist in coursistStringArray)
            {
                string[] currentCoursist = coursist.Split('_');
                string name = currentCoursist[0];
                string middleName = currentCoursist[1];
                string lastName = currentCoursist[2];
                string email = currentCoursist[3];

                

                foreach (var currentClient in allClients)
                {
                    if (currentClient.FirstName == name
                        && currentClient.MiddleName == middleName
                        && currentClient.LastName == lastName
                        && currentClient.EmailAddress == email)
                    {
                        outputCoursists.Add(currentClient);
                        break;
                    }
                }

            }
            return outputCoursists;
        }

        public static IList<IPerson> GetTeachersInCourse(string teachers)
        {
            IList<IPerson> outputTeachers = new List<IPerson>();

            string[] teachersStringArray = teachers.Split(',');

            IList<IPerson> allTeachers = new List<IPerson>();

            allTeachers = Person.GetAllTeachers();

            foreach (string t in teachersStringArray)
            {
                string[] currentTeacher = t.Split('_');
                string name = currentTeacher[0];
                string middleName = currentTeacher[1];
                string lastName = currentTeacher[2];
                string email = currentTeacher[3];



                foreach (var persentTeacher in allTeachers)
                {
                    if (persentTeacher.FirstName == name
                        && persentTeacher.MiddleName == middleName
                        && persentTeacher.LastName == lastName
                        && persentTeacher.EmailAddress == email)
                    {
                        outputTeachers.Add(persentTeacher);
                        break;
                    }
                }

            }
            return outputTeachers;
        }

        public static ELanguage GetLanguage(string language)
        {
            ELanguage output = new ELanguage();

            string toLower = language.ToLower();
            char[] charArray = toLower.ToCharArray();
            char firstLetter = char.Parse(charArray[0].ToString().ToUpper());
            charArray[0] = firstLetter;
            string outputString = new string(charArray);
            
            List<ELanguage> languages = new List<ELanguage>(){ELanguage.Danish, ELanguage.English, 
            ELanguage.French, ELanguage.German, ELanguage.Greek, ELanguage.Italian, ELanguage.Norwegian, ELanguage.Polish, 
            ELanguage.Portuguese, ELanguage.Russian, ELanguage.Swedish, ELanguage.Turkish};

            foreach(var lang in languages)
            {
                var enumLanguage = lang.ToString();
                string strLanguage = enumLanguage;

                if(outputString == strLanguage)
                {
                    output = lang;
                    break;
                }
            }

            return output;
        }

        public static ELanguageLevelForAdults LanguageLevelAdults (string level)
        {

            ELanguageLevelForAdults output = new ELanguageLevelForAdults();

            var lev = new ELanguageLevelForAdults().GetType().GetEnumValues();

            foreach (var l in lev)
            {
                string levelToString = l.ToString();
                string levelToLower = levelToString.ToLower();

                if (levelToLower == level)
                {
                    output = (ELanguageLevelForAdults)l;
                    break;
                }
            }

            

            return output;
        }
    }
}
