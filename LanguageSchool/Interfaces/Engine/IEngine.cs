using LanguageSchool.Interfaces.Person;
using System;
using System.Collections.Generic;

namespace LanguageSchool.Interfaces.Engine
{
    public interface IEngine
    {
        void DispatchCommands(string commandStatement);

        void ExecuteCreate(string[] commandStatement);

        void ExecuteConduct(string[] commandStatement);
    }
}
