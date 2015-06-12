using System;

namespace LanguageSchool
{
    using Interfaces.Engine;
    class LanguageSchoolMain
    {
        static void Main()
        {
            Start();
        }

        public static void Start()
        {
            string commandStatement = Console.ReadLine();

            while (commandStatement != "end")
            {
                commandStatement = Console.ReadLine();
                Console.WriteLine(commandStatement);
            }
        }
    }
}
