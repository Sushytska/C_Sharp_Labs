using System;
using System.Linq;
namespace Laba3
{
    class MainClass
    {

            public static void Main(string[] args)
            {

            ResearchTeamCollection researchTeamCollection = new ResearchTeamCollection();
            researchTeamCollection.AddResearchTeam(
                    TestCollections.GetResearchTeam(150),
                    TestCollections.GetResearchTeam(140),
                    TestCollections.GetResearchTeam(130),
                    TestCollections.GetResearchTeam(120),
                    TestCollections.GetResearchTeam(160),
                    TestCollections.GetResearchTeam(150),
                    TestCollections.GetResearchTeam(140),
                    TestCollections.GetResearchTeam(130),
                    TestCollections.GetResearchTeam(120),
                    TestCollections.GetResearchTeam(160)
                    );

            Console.WriteLine("researchTeamCollection default: \n {0}\n", string.Join(" ; ", researchTeamCollection.ResearchTeams.Select(x => x.TopicResearch).ToArray()));

            researchTeamCollection.SortTopicResearche();
            Console.WriteLine("Sorted by TopicResearche: \n {0}\n", string.Join(" ; ", researchTeamCollection.ResearchTeams.Select(x => x.TopicResearch).ToArray()));

            researchTeamCollection.SortByCountOfPapers();
            Console.WriteLine("Sorted by CountOfPapers: \n {0}\n", string.Join(" ; ", researchTeamCollection.ResearchTeams.Select(x => x.Papers.Count).ToArray()));

            researchTeamCollection.SortByNumberOfRegistration();

            Console.WriteLine("Sorted by NumberOfRegistration: \n {0}\n", string.Join(" ; ", researchTeamCollection.ResearchTeams.Select(x => x.RegisterNumber).ToArray()));

            Console.WriteLine("Min of NumberOfRegistration: {0}\n", researchTeamCollection.MinNumberOfRegistration);

            Console.WriteLine("ResearchTeam with Frequency = TwoYears:\n {0}\n",
                string.Join(" ; ", researchTeamCollection.GetTimeFrameTwoYear.Select(x => x.TimeResearche).ToArray()));

            int value = 3;
            Console.WriteLine("ResearchTeam with middle rate more then {0}:\n {1}\n", value,
                string.Join(" ; ", researchTeamCollection.NGroup(value)));

            TestCollections test = new TestCollections(10);
            Console.WriteLine("Searching time:");
            test.MeasureTime();
        }

    }
}

