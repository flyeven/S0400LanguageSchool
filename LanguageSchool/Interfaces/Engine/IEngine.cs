using System;

namespace LanguageSchool.Interfaces.Engine
{
    public interface IEngine
    {
        void DispatchCommands(string commandStatement);

        void ExecuteCreate(string commandStatement);

        void ExecuteAdd(string commandStatement);

        void ExecuteConduct(string commandStatement);
    }
}
