using System;
namespace Laba1
{
    public class Paper
    {
        public string _PaperName;
        public Person _PaperAuthor;
        public DateTime _ReleaseDate;

        public Paper(string paperName, Person paperAuthor, DateTime releaseDate)
        {
            _PaperName = paperName;
            _PaperAuthor = paperAuthor;
            _ReleaseDate = releaseDate;
        }

        public Paper():this("default PaperName", new Person(), new DateTime())
        {

        }

        public override string ToString()
        {
            return $"PaperName: {_PaperName} PaperAuthor: {_PaperAuthor} ReleaseDate: {_ReleaseDate}";
        }
    }
}
