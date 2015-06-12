using System;
using System.Collections.Generic;

namespace LanguageSchool.Engine
{
    using Interfaces.Engine;

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
            switch (commandWords[1])
            {
                case "course_participant":
                    Console.WriteLine("Created {0}", commandWords[1]);
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
    }
}
