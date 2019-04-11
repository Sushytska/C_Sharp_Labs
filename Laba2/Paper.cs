using System;
namespace Laba2
{
    public class Paper : INameAndCopy
    {
        private string _PaperName;
        private Person _PaperAuthor;
        private DateTime _ReleaseDate;

        public Paper(string paperName, Person paperAuthor, DateTime releaseDate)
        {
            _PaperName = paperName;
            _PaperAuthor = paperAuthor;
            _ReleaseDate = releaseDate;
        }

        public string Name
        {
            get { return _PaperName; }
            set { _PaperName = value; }
        }

        public Person PaperAuthor
        {
            get { return _PaperAuthor; }
            set { _PaperAuthor = value; }
        }

        public DateTime ReleaseDate
        {
            get { return _ReleaseDate; }
            set { _ReleaseDate = value; }
        }

        public Paper():this("default PaperName", new Person(), new DateTime())
        {

        }

        public override string ToString()
        {
            return $"PaperName: {Name} PaperAuthor: {PaperAuthor} ReleaseDate: {ReleaseDate}";
        }
        public virtual object DeepCopy()
        {
            Paper paper = new Paper(this.Name, PaperAuthor.DeepCopy() as Person, this.ReleaseDate);
            return paper;
        }
    }
}
