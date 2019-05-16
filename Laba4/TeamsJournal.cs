using System;
using System.Collections.Generic;
using System.Linq;
namespace Laba4
{
    public class TeamsJournal
    {
        private List<TeamsJournalEntry> _TeamsJournal { get; set; }

        public TeamsJournal()
        {
            _TeamsJournal = new List<TeamsJournalEntry>();
        }

        public void AddEvent(object source, TeamListHandlerEventArgs args)
        {
            TeamsJournalEntry teamsJournals = new TeamsJournalEntry(args.CollectionName, args.CollectionTypeChange, args.NumberChangedElement);
            _TeamsJournal.Add(teamsJournals);
        }

        public override string ToString()
        {
            return string.Format("{0}", string.Join("\n", _TeamsJournal.Select(x => x.ToString()).ToArray()));
        }
    }
}
