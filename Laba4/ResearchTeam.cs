using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace Laba4
{
    public class ResearchTeam : Team, INameAndCopy, IComparer<ResearchTeam>
    {
        private string _TopicResearch;
        private TimeFrame _TimeResearche;
        private List<Paper> _Papers;
        private List<Person> _MemberPapers;

        public ResearchTeam() : this("default TopicResearch", "default NameOrganization", 1, new TimeFrame(), new List<Paper>(), new List<Person>())
        {

        }

        public ResearchTeam(string topicResearch, string nameOrganization, int registerNumber, TimeFrame timeResearche, List<Paper> papers, List<Person> memberpaper)
        {
            _TopicResearch = topicResearch;
            Name = nameOrganization;
            RegisterNumberOfTeam = registerNumber;
            _TimeResearche = timeResearche;
            _Papers = papers;
            _MemberPapers = memberpaper;
        }

        public string TopicResearch
        {
            get { return _TopicResearch; }
            set { _TopicResearch = value; }
        }

        public string NameOrganization
        {
            get { return Name; }
            set { Name = value; }
        }

        public int RegisterNumber
        {
            get { return RegisterNumberOfTeam; }
            set { RegisterNumberOfTeam = value; }
        }

        public TimeFrame TimeResearche
        {
            get { return _TimeResearche; }
            set { _TimeResearche = value; }
        }

        public List<Paper> Papers
        {
            get { return _Papers; }
            set { _Papers = value; }
        }

        public List<Person> MemberPapers
        {
            get { return _MemberPapers; }
            set { _MemberPapers = value; }
        }

        public Paper LastPyblicatcia()
        {
            if (_Papers == null) return null;
           
            return _Papers[_Papers.Count - 1];
        }

        public bool this[TimeFrame timeResearche]
        {
            get
            {
                return (_TimeResearche == timeResearche);
            }
        }

        public void AddPaper(params Paper[] papers)
        {
            Papers.AddRange(papers);
        }

        public void AddMembers(params Person[] person)
        {
            if (person != null)
            {
                MemberPapers.AddRange(person);
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder1 = new StringBuilder();
            StringBuilder stringBuilder2 = new StringBuilder();
            foreach (Paper paper in Papers)
            {
                stringBuilder1.AppendLine(paper.ToString());
            }
            foreach (Person memberpaper in MemberPapers)
            {
                stringBuilder2.AppendLine(memberpaper.ToString());
            }
            return $"TopicResearch: {TopicResearch} NameOrganization: {Name} RegisterNumber: {RegisterNumberOfTeam} TimeResearche: {TimeResearche} Papers: {stringBuilder1} MemberPapers: {stringBuilder2}";
        }

        public virtual string ToShortString()
        {
            return $"TopicResearch: {TopicResearch} NameOrganization: {Name} RegisterNumber: {RegisterNumberOfTeam} TimeResearche: {TimeResearche}";
        }

        public Team TeamNew
        {
            get { return new Team(Name, RegisterNumberOfTeam); }
            set
            {
                Name = value.Name;
                RegisterNumberOfTeam = value.RegisterNumberOfTeam;
            }
        }

        public IEnumerable GetMemberPapers1()
        { 
            foreach(Person person in MemberPapers)
            {
                int bulo = 0;
                foreach (Paper papers in Papers)
                {
                    if (papers.PaperAuthor!=person)
                    {
                        bulo = 1;
                    }
                    else
                    {
                        bulo = 0;
                        break;
                    }
                }
                if (bulo == 1)
                {
                    yield return person;
                }
            }
        }

        public IEnumerable GetMemberPapers2()
        {
            foreach (Person person in MemberPapers)
            {
                int bulo = 0;
                foreach (Paper papers in Papers)
                {
                    if (papers.PaperAuthor.Equals(person))
                    {
                        bulo = 1;
                    }
                }
                if (bulo!=0)
                {
                    yield return person;
                }
            }
        }

        public IEnumerable GetMemberPapers3()
        {
            foreach (Person person in MemberPapers)
            {
                int i = 0;
                foreach (Paper papers in Papers)
                {
                    if (papers.PaperAuthor == person)
                    {
                        i++;
                    }
                }
                if (i > 1)
                {
                    yield return person;
                }
            }
        }

        public IEnumerable GetPapers(int n)
        {
            foreach (Paper paper in Papers)
            {
                if (paper.ReleaseDate.Year >= 2019 - n && paper.ReleaseDate.Year <= 2019)
                {
                    yield return paper;
                }
            }
        }

        public IEnumerable GetPapers2(int n)
        {
            foreach (Paper paper in Papers)
            {
                if (paper.ReleaseDate.Year == n)
                {
                    yield return paper;
                }
            }
        }

        protected bool Equals(ResearchTeam other)
        {
            return string.Equals(_TopicResearch, other._TopicResearch) && Name == other.Name && RegisterNumberOfTeam == other.RegisterNumberOfTeam && _TimeResearche.Equals(other._TimeResearche) && Equals(_Papers, other._Papers) && Equals(_MemberPapers, other._MemberPapers);
        }

        public override bool Equals(object obj)
        { 
            if (obj.GetType() != this.GetType()) return false;
            ResearchTeam researchTeam = (ResearchTeam)obj;
            return (this.TopicResearch == researchTeam.TopicResearch && this.NameOrganization == researchTeam.NameOrganization &&
                this.TimeResearche == researchTeam.TimeResearche && this.RegisterNumber == researchTeam.RegisterNumber &&
                this.Papers == researchTeam.Papers && this.MemberPapers == researchTeam.MemberPapers);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 13;
                hash = (hash * 7) + (!Object.ReferenceEquals(null, TopicResearch) ? TopicResearch.GetHashCode() : 0);
                hash = (hash * 7) + (!Object.ReferenceEquals(null, NameOrganization) ? NameOrganization.GetHashCode() : 0);
                hash = (hash * 7) + (!Object.ReferenceEquals(null, TimeResearche) ? TimeResearche.GetHashCode() : 0);
                hash = (hash * 7) + (!Object.ReferenceEquals(null, RegisterNumber) ? RegisterNumber.GetHashCode() : 0);
                hash = (hash * 7) + (!Object.ReferenceEquals(null, Papers) ? Papers.GetHashCode() : 0);
                hash = (hash * 7) + (!Object.ReferenceEquals(null, MemberPapers) ? MemberPapers.GetHashCode() : 0);
                return hash;
            }
        }

        public static bool operator ==(ResearchTeam left, ResearchTeam right)
        {
            return (left.TopicResearch == right.TopicResearch && left.NameOrganization == right.NameOrganization &&
                left.TimeResearche == right.TimeResearche && left.RegisterNumber == right.RegisterNumber &&
                left.Papers == right.Papers && left.MemberPapers == right.MemberPapers);
        }

        public static bool operator !=(ResearchTeam left, ResearchTeam right)
        {
            return (left.TopicResearch != right.TopicResearch && left.NameOrganization != right.NameOrganization &&
                left.TimeResearche != right.TimeResearche && left.RegisterNumber != right.RegisterNumber &&
                left.Papers != right.Papers && left.MemberPapers != right.MemberPapers);
        }

        public override object DeepCopy()
        {
            ResearchTeam other = new ResearchTeam();
            foreach (Person person in MemberPapers)
                other.MemberPapers.Add(person.DeepCopy() as Person);
            foreach (Paper paper in Papers)
                other.Papers.Add(paper.DeepCopy() as Paper);

            ResearchTeam researchTeam = new ResearchTeam(this.TopicResearch, this.NameOrganization, this.RegisterNumber, this.TimeResearche, other.Papers, other.MemberPapers);

            return researchTeam;
        }

        public int Compare(ResearchTeam x, ResearchTeam y)
        {
            return string.Compare(x.TopicResearch, y.TopicResearch);
        }
    }
}