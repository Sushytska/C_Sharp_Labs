using System;
namespace Laba1
{
    public class Person
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

        public string FirstName                                
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
            return $"FirstName: {_FirstName} LastName: {_LastName} DataNarodz: {_Birthday}";
        }

        public virtual string ToShortString()
        {
            return $"FirstName: {_FirstName} LastName: {_LastName}";
        }
    }
}
