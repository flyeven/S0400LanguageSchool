using System;
using System.Collections.Generic;
using LanguageSchool.Enum.Person;

namespace LanguageSchool.Engine
{
    using Interfaces.Engine;
    using LanguageSchool.People;
    using LanguageSchool.Interfaces.Person;
    using LanguageSchool.Enum.Course;
    using LanguageSchool.Courses;
    using LanguageSchool.Interfaces.Courses;

    public class Engine : IEngine
    {


        public void DispatchCommands(string commandStatement)
        {
            string[] commandWords = commandStatement.Split(' ');

            switch (commandWords[0])
            {
                case "create":
                    this.ExecuteCreate(commandWords);
                    break;
                case "print":
                    this.ExecutePrint(commandWords);
                    break;
                default:
                    break;
            }
        }

        public void ExecuteCreate(string[] commandWords)
        {
            string[] cW = commandWords;
            switch (cW[1])
            {
                case "course_participant":
                    Person courseParticipant = new CourseParticipant(cW[2], cW[3], cW[4],
                        cW[5], this.ConvertStrintIntoDateTime(cW[6]), cW[7], cW[8], cW[9], cW[10], 
                        this.ConvertStrintIntoDateTime(cW[11]), ESallaryType.Monthly,
                        decimal.Parse(cW[13]));
                    this.ExecuteAdd(courseParticipant);
                    break;
                case "teacher":
                    Person teacher = new Teacher(cW[2], cW[3], cW[4],
                        cW[5], this.ConvertStrintIntoDateTime(cW[6]), cW[7], cW[8], cW[9], cW[10],
                        this.ConvertStrintIntoDateTime(cW[11]), ESallaryType.Monthly,
                        decimal.Parse(cW[13]));
                    this.ExecuteAdd(teacher);
                    break;
                case "secretary":
                    Person secretary = new Secretary(cW[2], cW[3], cW[4],
                        cW[5], this.ConvertStrintIntoDateTime(cW[6]), cW[7], cW[8], cW[9], cW[10],
                        this.ConvertStrintIntoDateTime(cW[11]), ESallaryType.Monthly,
                        decimal.Parse(cW[13]));
                    this.ExecuteAdd(secretary);
                     break;
                case "adult_language_course":
                     string courseName = CourseInputer.CourseNameCreator(cW[2]);
                     ECourseActivityStatus status = CourseInputer.CourseActivityCreator(cW[3]);
                     EGroupType groupType = CourseInputer.GroupTypeCreator(cW[4]);
                     ECoursePlace coursePlace = cW[5] == "local" ? ECoursePlace.Local : ECoursePlace.Online;
                     decimal coursePrice = decimal.Parse(cW[6]);
                     IList<IPerson> coursists = CourseInputer.GetCoursistsInCourse(cW[7]);
                     IList<IPerson> teachers = CourseInputer.GetTeachersInCourse(cW[8]);
                     IList<IConductedClasses> conductedClasses = new List<IConductedClasses>();
                     EAge age = EAge.Adults;
                     ELanguage language = CourseInputer.GetLanguage(cW[11]);
                     ELanguageLevelForAdults level = CourseInputer.LanguageLevelAdults("a1");
                     LanguageCourseForAdults languageCourseAdults = new LanguageCourseForAdults(courseName, status, groupType, 
                         coursePlace, coursePrice, coursists, teachers, conductedClasses, age, language, level);
                     Course.Add(languageCourseAdults);
                     break;
                default:
                    break;
            }
        }

        public void ExecutePrint(string[] commandWords)
        {
            string[] cW = commandWords;

            switch (cW[1])
            {
                case "all_teachers":
                    Console.WriteLine();
                    Console.WriteLine(new string('-', 20));
                    foreach(var teacher in Person.GetAllTeachers())
                    {
                        Console.WriteLine(teacher);
                        Console.WriteLine();
                    }
                    Console.WriteLine(new string('-', 20));
                    Console.WriteLine();
                    break;
                case "all_students":
                    Console.WriteLine();
                    Console.WriteLine(new string('-', 20));
                    foreach(var coursist in Person.GetAllCourseParticipants())
                    {
                        Console.WriteLine(coursist);
                        Console.WriteLine();
                    }
                    Console.WriteLine(new string('-', 20));
                    Console.WriteLine();
                    break;
                case "all_secretaries":
                    Console.WriteLine();
                    Console.WriteLine(new string('-', 20));
                    foreach(var secretary in Person.GetAllSecretaries())
                    {
                        Console.WriteLine(secretary);
                        Console.WriteLine();
                    }
                    Console.WriteLine(new string('-', 20));
                    Console.WriteLine();
                    break;
                case "all_clients":
                    Console.WriteLine();
                    Console.WriteLine(new string('-', 20));
                    foreach (var client in Person.GetAllClients())
                    {
                        Console.WriteLine(client);
                        Console.WriteLine();
                    }
                    Console.WriteLine(new string('-', 20));
                    Console.WriteLine();
                    break;
                case "all_employees":
                    Console.WriteLine();
                    Console.WriteLine(new string('-', 20));
                    foreach (var employee in Person.GetAllEmployees())
                    {
                        Console.WriteLine(employee);
                        Console.WriteLine();
                    }
                    Console.WriteLine(new string('-', 20));
                    Console.WriteLine();
                    break;
                case "all_courses":
                    Console.WriteLine();
                    foreach (var course in Course.CourseList)
                    {
                        Console.WriteLine(course);
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    break;
                case "course":
                    string courseName = cW[2];

                    foreach (var currentCourse in Course.CourseList)
                    {
                        if (courseName == currentCourse.CourseName.ToLower())
                        {
                            Console.WriteLine(currentCourse);
                            Console.WriteLine();
                        }
                    }
                    break;
                case "student":
                    string firstName = cW[2];
                    string middleName = cW[3];
                    string lastName = cW[4];

                    List<IPerson> allStudents = Person.GetAllCourseParticipants();

                    Console.WriteLine();

                    foreach (var currentStudent in allStudents)
                    {
                        if (currentStudent.FirstName.ToLower() == firstName.ToLower()
                            && currentStudent.MiddleName.ToLower() == middleName.ToLower()
                            && currentStudent.LastName.ToLower() == lastName.ToLower())
                        {
                            Console.WriteLine(currentStudent.ToString());
                            Console.WriteLine();
                        }
                    }

                    break;
                default:
                    break;
            }
        }

        private void ExecuteAdd(IPerson person)
        {
            Person.Add(person);
        }

        public void ExecuteConduct(string[] commandWords)
        {
            throw new NotImplementedException();
        }

        private DateTime TurnStringIntoDate(string stringDate)
        {
            string[] str = stringDate.Split('.');

            DateTime outputDate = new DateTime(int.Parse(str[2]), int.Parse(str[1]), int.Parse(str[0]));

            return outputDate;
        }

        private DateTime ConvertStrintIntoDateTime(string stringDate)
        {
            string[] dateArray = stringDate.Split('.');
            DateTime outputDate = new DateTime(int.Parse(dateArray[2]), int.Parse(dateArray[1]), int.Parse(dateArray[0]));

            return outputDate;
        }
    }
}
