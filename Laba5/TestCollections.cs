using System;
using System.Collections.Generic;
namespace Laba5
{
    public class TestCollections
    {
        public List<Team> Teams { get; set; }
        public List<string> TeamsString { get; set; }
        public Dictionary<Team, ResearchTeam> TeamViewDictionary { get; set; }
        public Dictionary<string, ResearchTeam> TeamStringDictionary { get; set; }

        public static ResearchTeam GetResearchTeam(int index)
        {
            ResearchTeam researchTeam = new ResearchTeam("TopicResearche" + index, "NameOrganization" + index, index, TimeFrame.TwoYears,

                new List<Paper>
                {
                    new Paper("paperName " + index + 1, new Person("FirstName" + index + 1, "LastName" + index + 1, DateTime.Today.AddDays(index + 1)),
                                DateTime.Today.AddDays(index + 1)),
                    new Paper("paperName " + index + 2, new Person("FirstName" + index + 2, "LastName" + index + 2, DateTime.Today.AddDays(index + 2)),
                                DateTime.Today.AddDays(index + 2)),
                    new Paper("paperName " + index + 3, new Person("FirstName" + index + 3, "LastName" + index + 3, DateTime.Today.AddDays(index + 3)),
                                DateTime.Today.AddDays(index + 3))

                },
                new List<Person>
                {
                    new Person("FirstName" + index + 1, "LastName" + index + 1, DateTime.Today.AddDays(index + 1)),
                    new Person("FirstName" + index + 2, "LastName" + index + 2, DateTime.Today.AddDays(index + 2)),
                    new Person("FirstName" + index + 3, "LastName" + index + 3, DateTime.Today.AddDays(index + 3))
                });
            return researchTeam;
        }

        public TestCollections(int count)
        {
            Teams = new List<Team>();
            TeamsString = new List<string>();
            TeamViewDictionary = new Dictionary<Team, ResearchTeam>();
            TeamStringDictionary = new Dictionary<string, ResearchTeam>();

            for (int i = 0; i < count; i++)
            {
                ResearchTeam researchTeam = GetResearchTeam(i);
                Team team = researchTeam.TeamNew;

                Teams.Add(team);
                TeamsString.Add(team.ToString());
                TeamViewDictionary.Add(team, researchTeam);
                TeamStringDictionary.Add(team.ToString(), researchTeam);
            }
        }

        public void MeasureTime()
        {
            int length = Teams.Count - 1;
            int[] indexes = { 0, length, length / 2, length + 1 };
            foreach (var index in indexes)
            {
                var searcherResearchTeam = GetResearchTeam(index);
                var searcherTeamResearchTeam = searcherResearchTeam.TeamNew;

                Console.WriteLine("----------------------------");

                var start = Environment.TickCount;
                var answer = Teams.Contains(searcherTeamResearchTeam);
                var end = Environment.TickCount;
                Console.WriteLine("List teams at index {0}: " + (end - start) + " {1}", index, answer);

                start = Environment.TickCount;
                answer = TeamsString.Contains(searcherTeamResearchTeam.ToString());
                end = Environment.TickCount;
                Console.WriteLine("List text toString at index {0}: " + (end - start) + " {1}", index, answer);

                start = Environment.TickCount;
                answer = TeamViewDictionary.ContainsKey(searcherTeamResearchTeam);
                end = Environment.TickCount;
                Console.WriteLine("Dictionary<Team, ResearchTeam> key at index {0}: " + (end - start) + " {1}", index, answer);

                start = Environment.TickCount;
                answer = TeamViewDictionary.ContainsValue(searcherResearchTeam);
                end = Environment.TickCount;
                Console.WriteLine("Dictionary<Team, ResearchTeam> value at index {0}: " + (end - start) + " {1}", index, answer);

                start = Environment.TickCount;
                answer = TeamStringDictionary.ContainsKey(searcherTeamResearchTeam.ToString());
                end = Environment.TickCount;
                Console.WriteLine("Dictionary<string, ResearchTeam> key at index {0}: " + (end - start) + " {1}", index, answer);

                start = Environment.TickCount;
                answer = TeamStringDictionary.ContainsValue(searcherResearchTeam);
                end = Environment.TickCount;
                Console.WriteLine("Dictionary<string, ResearchTeam> value at index {0}: " + (end - start) + " {1}", index, answer);
            }
        }
    }
}
