using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.domain.dto
{
    internal class PlayerDTO
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string School { get; set; }

        public Team Team { get; set; }

        public PlayerDTO(long id, string name, string school, Team team)
        {
            Id = id;
            Name = name;
            School = school;
            Team = team;
        }

        public override bool Equals(object? obj)
        {
            return obj is PlayerDTO dTO &&
                   Id == dTO.Id &&
                   Name == dTO.Name &&
                   School == dTO.School &&
                   EqualityComparer<Team>.Default.Equals(Team, dTO.Team);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, School, Team);
        }

        public override string? ToString()
        {
            return $"Id: {Id}, Name: {Name}, School: {School}, Team: {Team.Name}";
        }
    }
}
