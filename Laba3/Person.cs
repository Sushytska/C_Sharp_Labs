using System;
namespace Laba3
{
    public class Person : INameAndCopy
    {
        private string _FirstName;
        private string _LastName;
        private DateTime _Birthday;

        public Person(string firstName, string lastName, DateTime birthday)
        {
            _FirstName = firstName;
            _LastName = lastName;
            _Birthday = birthday;
        }

        public Person() : this("default Name", "default Last Name", new DateTime())
        {

        }

        public string Name                                
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        public DateTime Birthday
        {
            get { return _Birthday; }
            set { _Birthday = value; }
        }

        public int ChangeYear
        {
            get { return this._Birthday.Year; }
            set { _Birthday = new DateTime(value, _Birthday.Month, _Birthday.Day); }
        }

        public override string ToString()
        {
            return $"FirstName: {Name} LastName: {LastName} DataNarodz: {Birthday}";
        }

        public virtual string ToShortString()
        {
            return $"FirstName: {Name} LastName: {LastName}";
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + (!Object.ReferenceEquals(null, Name) ? Name.GetHashCode() : 0);
            hash = (hash * 7) + (!Object.ReferenceEquals(null, LastName) ? LastName.GetHashCode() : 0);
            hash = (hash * 7) + (!Object.ReferenceEquals(null, Birthday) ? Birthday.GetHashCode() : 0);
            return hash;

        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            Person person = (Person)obj;
            return (this.Name == person.Name && this.LastName == person.LastName && this.Birthday == person.Birthday);
        }

        public static bool operator ==(Person p1, Person p2)
        {
            return (p1.Name == p2.Name && p1.LastName == p2.LastName && p1.Birthday == p2.Birthday);
        }

        public static bool operator !=(Person p1, Person p2)
        {
            return (p1.Name != p2.Name && p1.LastName != p2.LastName && p1.Birthday != p2.Birthday);
        }

        public virtual object DeepCopy()
        {
            Person person = new Person(this.Name, this.LastName, this.Birthday);
            return person;
        }
    }
}
