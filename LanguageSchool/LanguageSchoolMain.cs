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
    using System.IO;

    class LanguageSchoolMain
    {
        static void Main()
        {
            IEngine engine = new Engine.Engine();
            try
            {
                Start(engine);
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine();
                Console.WriteLine(e.StackTrace);
            }
        }

        public static void Start(IEngine engine)
        {
            string commandStatement = String.Empty;

            if (commandStatement == "")
            {
                using (var fileStream = 
                    File.OpenRead("C:\\Users\\Miroslav\\Documents\\Programming\\PracticalProjects\\LanguageSchool\\LanguageSchool\\CreateInsertCommands.txt"))
                  using (var streamReader = new StreamReader(fileStream)) {
                    String line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        engine.DispatchCommands(line);
                    }
                  }
            }

            while (commandStatement != "end")
            {
                engine.DispatchCommands(commandStatement);
                commandStatement = Console.ReadLine();
            }
        }
    }
}
