using System;
using System.Collections.Generic;
using LanguageSchool.Enum.Person;

namespace LanguageSchool.Engine
{
    using Interfaces.Engine;
    using LanguageSchool.People;
    using LanguageSchool.Interfaces.Person;

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
                    break;
                case "teacher":
                    Person teacher = new Teacher(cW[2], cW[3], cW[4],
                        cW[5], this.ConvertStrintIntoDateTime(cW[6]), cW[7], cW[8], cW[9], cW[10],
                        this.ConvertStrintIntoDateTime(cW[11]), ESallaryType.Monthly,
                        decimal.Parse(cW[13]));
                    break;
                case "secretary":
                    Person secretary = new Secretary(cW[2], cW[3], cW[4],
                        cW[5], this.ConvertStrintIntoDateTime(cW[6]), cW[7], cW[8], cW[9], cW[10],
                        this.ConvertStrintIntoDateTime(cW[11]), ESallaryType.Monthly,
                        decimal.Parse(cW[13]));
                    break;
                default:
                    break;
            }
        }

        public void ExecuteAdd(string[] commandWords)
        {
            throw new NotImplementedException();
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
