using System;
using System.Collections.Generic;

namespace LanguageSchool.Interfaces.Engine
{
    public interface IEngine
    {
        void DispatchCommands(string commandStatement);

        void ExecuteCreate(List<string> commandStatement);

        void ExecuteAdd(List<string> commandStatement);

        void ExecuteConduct(List<string> commandStatement);
    }
}
