using System;
namespace Laba3
{
    public class Team : INameAndCopy, IComparable<Team>
    {
        private string _NameTeam;
        private int _RegisterNumberOfTeam;

        public Team(string nameTeam, int registerNumberOfTeam)
        {
            _NameTeam = nameTeam;
            _RegisterNumberOfTeam = registerNumberOfTeam;
        }

        public Team() : this("default nameOrganization", 0)
        {

        }

        public string Name
        {
            get { return _NameTeam; }
            set { _NameTeam = value; }
        }

        public int RegisterNumberOfTeam
        {
            get { return _RegisterNumberOfTeam; }
            set
            {
                _RegisterNumberOfTeam = value;
            }
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + (!Object.ReferenceEquals(null, Name) ? Name.GetHashCode() : 0);
            hash = (hash * 7) + (!Object.ReferenceEquals(null, RegisterNumberOfTeam) ? RegisterNumberOfTeam.GetHashCode() : 0);
            return hash;

        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            Team team = (Team)obj;
            return (this.Name == team.Name && this.RegisterNumberOfTeam == team.RegisterNumberOfTeam);
        }

        public static bool operator ==(Team t1, Team t2)
        {
            return (t1.Name == t2.Name && t2.RegisterNumberOfTeam == t1.RegisterNumberOfTeam);
        }

        public static bool operator !=(Team t1, Team t2)
        {
            return (t1.Name != t2.Name || t2.RegisterNumberOfTeam != t1.RegisterNumberOfTeam);
        }

        public virtual object DeepCopy()
        {
            Team team = new Team(this.Name, this.RegisterNumberOfTeam);
            return team;
        }

        public override string ToString()
        {
            return $"NameOrganization {_NameTeam} RegisterNumber {_RegisterNumberOfTeam}";
        }

        public int CompareTo(Team obj)
        {
            return RegisterNumberOfTeam - obj.RegisterNumberOfTeam;
        }
    }
}
