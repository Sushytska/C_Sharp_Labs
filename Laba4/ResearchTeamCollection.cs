using System;
using System.Collections.Generic;
using System.Linq;

namespace Laba4
{
    public class ResearchTeamCollection : ResearchTeam
    {
        public delegate void TeamListHandler(object source, TeamListHandlerEventArgs args);
        public string CollectionName { get; set; }
        public List<ResearchTeam> _ResearchTeam { get; set; }
        //public Action<object, TeamListHandlerEventArgs> RearchTeamAdded { get; internal set; }

        public event TeamListHandler ResearchTeamAdded;
        public event TeamListHandler ResearchTeamInserted;

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
            ResearchTeamAdded(this, new TeamListHandlerEventArgs(CollectionName, "Element was added by AddDefaults", _ResearchTeam.Count - 1));
        }

        public void AddResearchTeam(params ResearchTeam[] researchTeams)
        {
            _ResearchTeam = new List<ResearchTeam>();
            foreach (ResearchTeam researchteam in researchTeams)
            {
                _ResearchTeam.Add(researchteam);
            }
            if (_ResearchTeam != null)
                ResearchTeamAdded(this, new TeamListHandlerEventArgs(CollectionName, "Element was added by AddResearchTeam", _ResearchTeam.Count - 1));
        }

        public override string ToString()
        {
            return string.Format("ResearchTeam:\n{0}", string.Join("\n", _ResearchTeam.Select(x => x.ToString()).ToArray()));
        }

        public virtual string ToShortList()
        {
            return string.Format("ResearchTeam:\n{0}", string.Join("\n", _ResearchTeam.Select(x => x.ToShortString()).ToArray()));
        }

        public void SortByNumberOfRegistration()
        {
            _ResearchTeam.Sort();
        }

        public void SortByCountOfPapers()
        {
            _ResearchTeam.Sort(new PaperCountResearchTeam().Compare);
        }

        public void SortTopicResearche() => _ResearchTeam.Sort(new ResearchTeam().Compare);

        public int MinNumberOfRegistration
        {
            get
            {
                if(_ResearchTeam.Count != 0)
                {
                    return _ResearchTeam.Select(x => x.RegisterNumberOfTeam).Min();
                }
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
                return _ResearchTeam.Where(x => x.TimeResearche == TimeFrame.TwoYears);
            }
        }

        public List<IGrouping<bool, ResearchTeam>> NGroup(int value)
        {
            return _ResearchTeam.GroupBy(x => x.MemberPapers.Count == value).ToList();
        }

        public void InsertAt(int j, ResearchTeam researchTeam)
        {
            if (_ResearchTeam.Count >= j)
            {
                _ResearchTeam.Insert(j, researchTeam);
                ResearchTeamInserted(this, new TeamListHandlerEventArgs(CollectionName, "Element was added by InsertAt", j));
            }
            else
            {
                _ResearchTeam.Add(researchTeam);
                ResearchTeamAdded(this, new TeamListHandlerEventArgs(CollectionName, "Element was added by InsertAt", _ResearchTeam.Count - 1));
            }
        }

        public ResearchTeam this[int index]
        {
            get { return _ResearchTeam[index]; }
            set { _ResearchTeam[index] = value; }
        }

    }
}
