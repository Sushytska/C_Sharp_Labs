using System;
namespace Laba4
{
    public class TeamListHandlerEventArgs : System.EventArgs
    {
        public string CollectionName { get; set; }
        public string CollectionTypeChange { get; set; }
        public int NumberChangedElement { get; set; }

        public TeamListHandlerEventArgs():this("default CollectionName", "default CollectionTypeChange", 0)
        {
        }

        public TeamListHandlerEventArgs(string collectionName, string collectionTypeChange, int numberChangedElement)
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
