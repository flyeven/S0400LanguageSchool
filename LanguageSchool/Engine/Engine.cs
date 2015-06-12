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
        }

        public void ExecuteCreate(List<string> commandStatement)
        {
            throw new NotImplementedException();
        }

        public void ExecuteAdd(List<string> commandStatement)
        {
            throw new NotImplementedException();
        }

        public void ExecuteConduct(List<string> commandStatement)
        {
            throw new NotImplementedException();
        }
    }
}
