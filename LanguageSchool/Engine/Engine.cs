﻿using System;
using System.Collections.Generic;
using LanguageSchool.Enum.Person;
using System.Linq;

namespace LanguageSchool.Engine
{
    using Interfaces.Engine;
    using LanguageSchool.People;
    using LanguageSchool.Interfaces.Person;
    using LanguageSchool.Enum.Course;
    using LanguageSchool.Courses;
    using LanguageSchool.Interfaces.Courses;
    using LanguageSchool.Interfaces.Person.Types.Employee;

    public class Engine : IEngine
    {


        public void DispatchCommands(string commandStatement)
        {
            string[] commandWords = new string[20];
            string[] comm = commandStatement.Split(' ');

            for (int i = 0; i < comm.Length; i++)
            {
                commandWords[i] = comm[i];
            }

            switch (commandWords[0])
            {
                case "create":
                    this.ExecuteCreate(commandWords);
                    break;
                case "print":
                    this.ExecutePrint(commandWords);
                    break;
                case "insert":
                    this.ExecuteInsert(commandWords);
                    break;
                case "set":
                    this.ExecuteSet(commandWords);
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
                     IList<IClassInfo> conductedClasses = new List<IClassInfo>();
                     EAge age = EAge.Adults;
                     ELanguage language = CourseInputer.GetLanguage(cW[11]);
                     ELanguageLevelForAdults level = CourseInputer.LanguageLevelAdults("a1");
                     LanguageCourseForAdults languageCourseAdults = new LanguageCourseForAdults(courseName, status, groupType, 
                         coursePlace, coursePrice, coursists, teachers, conductedClasses, age, language, level);
                     Course.Add(languageCourseAdults);
                     break;
                case "class":
                     ICourse courseToAddToClass = null;

                     ulong courseId = ulong.Parse(cW[5].Split('_')[1]);
                     foreach (var currentCourse in Course.CourseList)
                     {
                         if (currentCourse.Id == courseId)
                         {
                             courseToAddToClass = currentCourse;
                         }
                     }

                     ITeacher teacherToAddToClass = null;

                    ulong teacherId = ulong.Parse(cW[6].Split('_')[1]);
                     foreach (var currentTeacher in Person.GetAllTeachers())
                     {
                         if (currentTeacher.Id == teacherId)
                         {
                             teacherToAddToClass = (ITeacher)currentTeacher;
                         }
                     }

                     string[] conductionDateString = cW[2].Split('_')[1].Split('.');
                     int conductionDateYear = int.Parse(conductionDateString[2]);
                     int conductionDateMonth = int.Parse(conductionDateString[1]);
                     int conductionDateDay = int.Parse(conductionDateString[0]);
                     DateTime conductionDate = new DateTime(conductionDateYear, conductionDateMonth, conductionDateDay);

                    string[] startHourStringArray = cW[3].Split('_')[2].Split(':');
                    int startHourHour = int.Parse(startHourStringArray[0]);
                    int startHourMinutes = int.Parse(startHourStringArray[1]);
                    DateTime startHour = new DateTime(conductionDateYear, conductionDateMonth, conductionDateDay, startHourHour, startHourMinutes, 0);

                    string[] endHourStringArray = cW[4].Split('_')[2].Split(':');
                    int endHourHour = int.Parse(endHourStringArray[0]);
                    int endHourMinutes = int.Parse(endHourStringArray[1]);
                    DateTime endHour = new DateTime(conductionDateYear, conductionDateMonth, conductionDateDay, endHourHour, endHourMinutes, 0);

                    ClassInfo currentClass = new ClassInfo(conductionDate, startHour, endHour, teacherToAddToClass, courseToAddToClass);

                    bool presentTeacher = false;

                    foreach (var teacherInCourse in courseToAddToClass.TeachersInCourse)
                    {
                        if(teacherInCourse.Id == teacherToAddToClass.Id)
                        {
                            presentTeacher = true;
                            break;
                        }
                    }

                    if (presentTeacher == true)
                    {
                        courseToAddToClass.AddConductedClass(currentClass);
                    }
                    else
                    {
                        throw new ArgumentException(String.Format("There's no teacher with ID {0} who conducts classes in the course with ID {1}", 
                            teacherToAddToClass.Id, courseToAddToClass.Id));
                    }
                     break;
                default:
                    break;
            }
        }

        public void ExecuteInsert(string[] commandWords)
        {
            string[] cW = commandWords;

            if (cW[5] == "course")
            {
                string courseName = cW[6];
                string courseId = cW[7];

                ICourse courseToInsertInto = null;

                foreach (var currentCourse in Course.CourseList)
                {
                    if (currentCourse.CourseName.ToLower() == courseName.ToLower() && currentCourse.Id == ulong.Parse(courseId))
                    {
                        courseToInsertInto = currentCourse;
                    }
                }

                switch (cW[1])
                {
                    case "student":
                        string studentName = cW[2];
                        string studentId = cW[3];
                        CourseParticipant studentToInsert;

                        foreach (var currentStudent in Person.GetAllClients())
                        {
                            if (currentStudent.FirstName.ToLower() == studentName.ToLower()
                                && currentStudent.Id == ulong.Parse(studentId))
                            {
                                studentToInsert = (CourseParticipant)currentStudent;
                                courseToInsertInto.AddStudentToCourse(studentToInsert);
                            }
                        }
                        break;
                    case "teacher":
                        string teacherName = cW[2];
                        string teacherId = cW[3];
                        Teacher teacherToInsert;

                        foreach (var currentTeacher in Person.GetAllTeachers())
                        {
                            if (currentTeacher.FirstName.ToLower() == teacherName.ToLower()
                                && currentTeacher.Id == ulong.Parse(teacherId))
                            {
                                teacherToInsert = (Teacher)currentTeacher;
                                courseToInsertInto.AddTeachersToCourse(teacherToInsert);
                            }
                        }
                        break;
                    default:
                        break;
                }
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
                    string courseName = cW[2] == null ? "null" : cW[2];

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
                    string firstName = cW[2] == null ? "null" : cW[2];
                    string middleName = cW[3] == null ? "null" : cW[3];
                    string lastName = cW[4] == null ? "null" : cW[4];

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
                case "teacher":
                    string firstNameTeacher = cW[2] == null ? "null" : cW[2];
                    string middleNameTeacher = cW[3] == null ? "null" : cW[3];
                    string lastNameTeacher = cW[4] == null ? "null" : cW[4];

                    List<IPerson> allteachers = Person.GetAllTeachers();

                    Console.WriteLine();

                    foreach (var currentTeacher in allteachers)
                    {
                        if (currentTeacher.FirstName.ToLower() == firstNameTeacher.ToLower()
                            && currentTeacher.MiddleName.ToLower() == middleNameTeacher.ToLower()
                            && currentTeacher.LastName.ToLower() == lastNameTeacher.ToLower())
                        {
                            Console.WriteLine(currentTeacher.ToString());
                            Console.WriteLine();
                        }
                    }

                    break;
                case "classes":
                    ulong classesInCourseWithId = ulong.Parse(cW[3].Split('_')[1]);
                    ICourse courseWithClasses = null;

                    foreach (var c in Course.CourseList)
                    {
                        if (c.Id == classesInCourseWithId)
                        {
                            courseWithClasses = c;
                            ConsoleRenderer.RenderCourseClassesOnTheConsole(courseWithClasses);
                        }
                    }

                    break;
                case "total_hours_in_courses":
                    ConsoleRenderer.PrintTotalHoursInCourses();
                    break;
                default:
                    break;
            }
        }

        public void ExecuteSet(string[] commandWords)
        {
            string cW = commandWords[1].Split('_')[0];
            switch(cW)
            {
                case "honorarium":
                    ulong courseId = ulong.Parse(commandWords[2].Split('_')[1]);
                    ulong teacherId = ulong.Parse(commandWords[3].Split('_')[1]);
                    Course course = CourseInputer.GetCourseFromId(courseId);
                    Teacher teacher = CourseInputer.GetTeacherFromId(teacherId);
                    decimal result = 0M;
                    string hon = commandWords[1].Split('_')[1];
                    result = decimal.Parse(hon.ToLower().ToString());

                    bool exists = HonorariumTeacher.HonoraryCheck(courseId, teacherId);

                    if(exists == false)
                    {
                        HonorariumTeacher honorarium = 
                            new HonorariumTeacher(teacher, course, result);

                        HonorariumTeacher.AddHonorariumToBase(honorarium);
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
