using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Laba5
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

        public IEnumerable PersonHavePaper()
        { 
            foreach(Person person in MemberPapers)
            {
                foreach (Paper papers in Papers)
                {
                    if (papers.PaperAuthor==person)
                    {
                        yield return person; break;
                    }
                }
            }
        }

        public IEnumerable PersonHaveMoreThanOnePaper()
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

        public IEnumerable PaperForTheLastYear(int n)
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

        public int Compare(ResearchTeam x, ResearchTeam y)
        {
            return string.Compare(x.TopicResearch, y.TopicResearch);
        }

        public override object DeepCopy()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                if (this.GetType().IsSerializable)
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, this);
                    stream.Position = 0;
                    return formatter.Deserialize(stream);
                }
                return null;
            }
        }

        public bool AddFromConsole()
        {
            try
            {
                Console.WriteLine("Hello, you can enter here Paper in format:\n" +
                                  "PersonName PersonLastName PersonBirth(dd.mm.yyyy) PaperName ReleaseDate(dd.mm.yyyy),   " +
                                  "use space as text split");
                string[] input = Console.ReadLine().Split(' ');
                if (input.Length % 5 != 0)
                {
                    throw new Exception("Input Error");
                }

                int i = 0;
                while (i < input.Length)
                {
                    string personName = input[i++];
                    string personLastName = input[i++];
                    DateTime personBirth = DateTime.ParseExact(input[i++], "dd.MM.yyyy", null);
                    string paperName = input[i++];
                    DateTime releaseDate = DateTime.ParseExact(input[i++], "dd.MM.yyyy", null);

                    AddPaper(new Paper(paperName, new Person(personName, personLastName, personBirth), releaseDate));
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool Save(string filename)
        {
            try
            {
                using (FileStream stream = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, this);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool Load(string filename)
        {
            using (FileStream stream = new FileStream(filename, FileMode.Open))
            {
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    ResearchTeam researchTeam = (ResearchTeam)formatter.Deserialize(stream);

                    this.TopicResearch = researchTeam.TopicResearch;
                    this.NameOrganization = researchTeam.NameOrganization;
                    this.RegisterNumber = researchTeam.RegisterNumber;
                    this.TimeResearche = researchTeam.TimeResearche;
                    this.Papers = researchTeam.Papers;
                    this.MemberPapers = researchTeam.MemberPapers;
                    this.TeamNew = researchTeam.TeamNew;

                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }

            }
        }

        public static bool Save(string filename, ResearchTeam obj)
        {
            return obj.Save(filename);
        }

        public static bool Load(string filename, ResearchTeam obj)
        {
            return obj.Load(filename);
        }

    }
}