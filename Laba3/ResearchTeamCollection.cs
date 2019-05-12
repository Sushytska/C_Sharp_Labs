using System;
using System.Collections.Generic;
using System.Linq;

namespace Laba3
{
    public class ResearchTeamCollection : ResearchTeam
    {
        private List<ResearchTeam> _ResearchTeam  { get; set; }

        public void AddDefaults()
        {
            ResearchTeam newResearchTeam = new ResearchTeam("default TopicResearch", "default NameOrganization", 1, new TimeFrame(),
                new List<Paper>
                {
                    new Paper("default PaperName", new Person(), new DateTime())
                },
                new List<Person>
                {
                    new Person("default FirstName", "default LastName", new DateTime())
                }
                );
            _ResearchTeam.Add(newResearchTeam);
        }

        public void AddResearchTeam(params ResearchTeam[] researchTeams)
        {
            _ResearchTeam = new List<ResearchTeam>();
            foreach (ResearchTeam researchteam in researchTeams)
            {
                _ResearchTeam.Add(researchteam);
            }
        }

        public List<ResearchTeam> ResearchTeams
        {
            get { return _ResearchTeam; }
            set { _ResearchTeam = value; }
        }

        public override string ToString()
        {
            return string.Format("ResearchTeam:\n{0}", string.Join("\n", ResearchTeams.Select(x => x.ToString()).ToArray()));
        }

        public virtual string ToShortList()
        {
            return string.Format("ResearchTeam:\n{0}", string.Join("\n", ResearchTeams.Select(x => x.ToShortString()).ToArray()));
        }

        public void SortByNumberOfRegistration()
        {
            ResearchTeams.Sort();
        }

        public void SortByCountOfPapers()
        {
            ResearchTeams.Sort(new PaperCountResearchTeam().Compare);
        }

        public void SortTopicResearche() => ResearchTeams.Sort(new ResearchTeam().Compare);

        public int MinNumberOfRegistration
        {  
            get
            {
                if (ResearchTeams.Count != 0)
                { return ResearchTeams.Select(x => x.RegisterNumberOfTeam).Min(); }
                else
                {
                    return 0;
                }
            }
        }

        public IEnumerable<ResearchTeam> GetTimeFrameTwoYear
        {
            get
            {
                return ResearchTeams.Where(x => x.TimeResearche == TimeFrame.TwoYears);
            }
        }

         public List<IGrouping<bool, ResearchTeam>> NGroup(int value)
        {
            return _ResearchTeam.GroupBy(x => x.MemberPapers.Count == value).ToList();
        }
    }
}
 