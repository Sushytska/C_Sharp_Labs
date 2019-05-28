using System;
namespace Laba5
{
    public class TeamsJournalEntry
    {
        public string CollectionName { get; set; }
        public string CollectionTypeChange { get; set; }
        public int NumberChangedElement { get; set; }

        public TeamsJournalEntry() : this("default CollectionName", "default CollectionTypeChange", 0)
        {
        }

        public TeamsJournalEntry(string collectionName, string collectionTypeChange, int numberChangedElement)
        {
            CollectionName = collectionName;
            CollectionTypeChange = collectionTypeChange;
            NumberChangedElement = numberChangedElement;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", CollectionName, CollectionTypeChange, NumberChangedElement);
        }
    }
}
