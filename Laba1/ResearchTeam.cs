using System;
using System.Text;

namespace Laba1
{
    public class ResearchTeam
    {
        private string _TopicResearch;
        private string _NameOrganization;
        private int _RegisterNumber;
        private TimeFrame _TimeResearche;
        private Paper[] _Papers;

        public ResearchTeam() : this("default TopicResearch", "default NameOrganization", 0, new TimeFrame(), new Paper[] { })
        {

        }

        public ResearchTeam(string topicResearch, string nameOrganization, int registerNumber, TimeFrame timeResearche, Paper[] papers)
        {
            _TopicResearch = topicResearch;
            _NameOrganization = nameOrganization;
            _RegisterNumber = registerNumber;
            _TimeResearche = timeResearche;
            _Papers = papers;
        }

        public string TopicResearch
        {
            get { return _TopicResearch; }
            set { _TopicResearch = value; }
        }

        public string NameOrganization
        {
            get { return _NameOrganization; }
            set { _NameOrganization = value; }
        }

        public int RegisterNumber
        {
            get { return _RegisterNumber; }
            set { _RegisterNumber = value; }
        }

        public TimeFrame TimeResearche
        {
            get { return _TimeResearche; }
            set { _TimeResearche = value; }
        }

        public Paper[] Papers
        {
            get { return _Papers; }
            set { _Papers = value; }
        }

        public Paper LastPyblicatcia()
        {
            if (_Papers == null) return null;
            Paper last = new Paper();
            for (int i = 0; i < _Papers.Length - 1; i++)
            {
                for (int j = i + 1; j < _Papers.Length; j++)
                {
                    if (_Papers[i]._ReleaseDate > _Papers[j]._ReleaseDate)
                    {
                        last = _Papers[i];
                        _Papers[i] = _Papers[j];
                        _Papers[j] = last;
                    }
                }
            }
            return _Papers[_Papers.Length - 1];
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

            if (_Papers == null)
            {
                _Papers = new Paper[papers.Length];
                for (int i = 0; i < papers.Length; i++)
                {
                    _Papers[i] = papers[i];
                }

            }
            else
            {
                Paper[] temp = _Papers;
                _Papers = new Paper[temp.Length + papers.Length];
                int j = temp.Length;

                for (int i = 0; i < papers.Length; i++)
                {
                    _Papers[j++] = papers[i]; //???
                }
                for (int i = 0; i < temp.Length; i++)
                {
                    _Papers[i] = temp[i];
                }
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Paper paper in _Papers)
            {
                stringBuilder.AppendLine(paper.ToString());
            }
            return $"TopicResearch: {_TopicResearch} NameOrganization: {_NameOrganization} RegisterNumber: {_RegisterNumber} TimeResearche: {_TimeResearche} Papers: {stringBuilder}";
        }

        public virtual string ToShortString()
        {
            return $"TopicResearch: {_TopicResearch} NameOrganization: {_NameOrganization} RegisterNumber: {_RegisterNumber} TimeResearche: {_TimeResearche}";
        }

    }
}