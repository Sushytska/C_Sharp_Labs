using System;
using System.IO;

namespace Laba5
{
    class MainClass
    {

            public static void Main(string[] args) 
            {
           
            string fileName = "NewFile";
            ResearchTeam research_1 = new ResearchTeam();
            ResearchTeam research_2 = (ResearchTeam) research_1.DeepCopy();

            Console.WriteLine("Original is \n{0} \nCopy is \n {1}", research_1, research_2);

            Console.WriteLine("Please enter file name:");
            fileName = Console.ReadLine();

            if (!File.Exists(fileName))
            {
                Console.WriteLine("File not exist. Creating new file...");
                File.Create(fileName);
            }
            research_1.AddFromConsole();
            research_1.Save(fileName);
            research_1.Load(fileName);

            Console.WriteLine("-------------------------------");
            Console.WriteLine(research_1);

            ResearchTeam.Load(fileName, research_1);
            research_1.AddFromConsole();
            ResearchTeam.Save(fileName, research_1);

            Console.WriteLine("-------------------------------");
            Console.WriteLine(research_1);
        }

    }
}

