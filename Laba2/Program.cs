using System;
using System.Diagnostics;
using System.IO;
namespace Laba2
{
    class MainClass
    {

            public static void Main(string[] args)
            {
            string[] lines = { "some text1", "some text2", "some text3" };
            File.WriteAllLines(@"/home/valli/Projects/SystemProg_2/In_Text.txt", lines);
            Person person_1 = new Person("Korbutiak", "Tetiana", new DateTime(1985, 12, 13));
            Person person_2 = new Person("Sorovichak", "Inna", new DateTime(1996, 04, 13));
            Person person_3 = new Person("Tymovyk", "Ann", new DateTime(1998, 07, 24));
            Paper paper_1 = new Paper("City", person_1, new DateTime(2017, 12, 24));
            Paper paper_2 = new Paper("КЕКК", person_2, new DateTime(2015, 01, 24));
            Paper paper_3 = new Paper("News", person_2, new DateTime(2019, 04, 13));

            Team first = new Team("RED", 15);
            Team second = new Team("RED", 15);

            Console.WriteLine("\nFirst task equals : ");
            Console.WriteLine(" == : " + (first == second));
            Console.WriteLine(" != : " + (first != second));
            Console.WriteLine(" Equals : " + first.Equals(second));
            Console.WriteLine(" Hash : " + first.GetHashCode() + " " + second.GetHashCode());

            Console.WriteLine("\nSecond message about RegisterNumberOfTeam : ");
            Team team = new Team();
            try
            {
                team.RegisterNumberOfTeam   = -1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("\nThird task AddPaper and AddMembers: ");
            ResearchTeam researchTeam = new ResearchTeam();
            researchTeam.AddPaper(paper_1, paper_2, paper_3);
            researchTeam.AddMembers(person_1, person_2, person_3);
            Console.WriteLine(researchTeam);

            Console.WriteLine("\nFourth show Team from ResearchTeam: ");
            Console.WriteLine(researchTeam.TeamNew);

            Console.WriteLine("\nFifth task DeepCopy : ");
            ResearchTeam researchTeam1 = new ResearchTeam("Hello", "Guys", 12, TimeFrame.Year, researchTeam.Papers, researchTeam.MemberPapers);
            ResearchTeam researchCopy = new ResearchTeam();
            //Console.WriteLine(researchTeam1.ToString());
            researchCopy = (ResearchTeam)researchTeam1.DeepCopy();
            researchTeam1.MemberPapers[0].Name = "Lobutiak";
            Console.WriteLine(researchTeam1.ToString());
            Console.WriteLine(researchCopy.ToString());

            Console.WriteLine("\nSixth task foreach MemberPapers :");
            foreach (Person person in researchTeam.GetMemberPapers1())
            {
                Console.WriteLine(person);
            }

            Console.WriteLine("\nSeven task foreach Papers :");
            foreach (Paper papers in researchTeam.GetPapers(2))
            {
                Console.WriteLine(papers);
            }

            Console.WriteLine("\nFirst addition task :");
            foreach (Person person in researchTeam.GetMemberPapers2())
            {
                Console.WriteLine(person);
            }

            Console.WriteLine("\nSecond addition task :");
            foreach (Person person in researchTeam.GetMemberPapers3())
            {
                Console.WriteLine(person);
            }

            Console.WriteLine("\nThird addition task :");
            foreach (Paper papers in researchTeam.GetPapers2(2019))
            {
                Console.WriteLine(papers);
            }
        }

    }
}

