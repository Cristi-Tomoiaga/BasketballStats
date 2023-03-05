using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.domain
{
    internal class Team : Entity<long>
    {
        public string Name { get; set; }

        public Team(string name)
        {
            Name = name;
        }

        public override bool Equals(object? obj)
        {
            return obj is Team team &&
                   Id == team.Id &&
                   Name == team.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }

        public override string? ToString()
        {
            return $"Id: {Id}, Name: {Name}";
        }
    }
}
