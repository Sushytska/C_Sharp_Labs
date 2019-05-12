using System.Collections.Generic;
namespace Laba3
{
    public class PaperCountResearchTeam : IComparer<ResearchTeam>
    {
        public int Compare(ResearchTeam x, ResearchTeam y)
        {
            return x.Papers.Count - y.Papers.Count;
        }
    }
}
