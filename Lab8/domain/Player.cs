using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.domain
{
    internal class Player : Student
    {
        public long IdTeam { get; set; }

        public Player(string name, string school, long idTeam) : base(name, school)
        {
            IdTeam = idTeam;
        }

        public override bool Equals(object? obj)
        {
            return obj is Player player &&
                   base.Equals(obj) &&
                   IdTeam == player.IdTeam;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), IdTeam);
        }

        public override string? ToString()
        {
            return base.ToString() + $", IdTeam: {IdTeam}";
        }
    }
}
