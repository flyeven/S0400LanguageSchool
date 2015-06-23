using System;
using LanguageSchool.Engine;
using System.Linq;

namespace LanguageSchool
{
    using Interfaces.Engine;
    using LanguageSchool.People;
    using System.Collections.Generic;
    using LanguageSchool.Interfaces.Person;

    class LanguageSchoolMain
    {
        static void Main()
        {
            IEngine engine = new Engine.Engine();
            Start(engine);

            //Person.GetAllTeachers();

            //Person.GetAllCourseParticipants();

            //Person.GetAllSecretaries();

            //Person.GetAllClients();

            //Person.GetAllEmployees();
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
