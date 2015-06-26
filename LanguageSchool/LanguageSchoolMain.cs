using System;
using LanguageSchool.Engine;
using System.Linq;

namespace LanguageSchool
{
    using Interfaces.Engine;
    using LanguageSchool.People;
    using System.Collections.Generic;
    using LanguageSchool.Interfaces.Person;
using LanguageSchool.Courses;
    using LanguageSchool.Interfaces.Courses;

    class LanguageSchoolMain
    {
        static void Main()
        {
            IEngine engine = new Engine.Engine();
            Start(engine);
        }

        public static void Start(IEngine engine)
        {
            string commandStatement = Console.ReadLine();

            while (commandStatement != "end")
            {
                engine.DispatchCommands(commandStatement);
                commandStatement = Console.ReadLine();
            }
        }
    }
}
