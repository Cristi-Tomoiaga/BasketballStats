using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.domain.dto
{
    internal class MatchDTO
    {
        public long Id { get; set; }

        public Team FirstTeam { get; set; }

        public Team SecondTeam { get; set; }

        public DateOnly Date { get; set; }

        public MatchDTO(long id, Team firstTeam, Team secondTeam, DateOnly date)
        {
            Id = id;
            FirstTeam = firstTeam;
            SecondTeam = secondTeam;
            Date = date;
        }

        public override bool Equals(object? obj)
        {
            return obj is MatchDTO dTO &&
                   Id == dTO.Id &&
                   EqualityComparer<Team>.Default.Equals(FirstTeam, dTO.FirstTeam) &&
                   EqualityComparer<Team>.Default.Equals(SecondTeam, dTO.SecondTeam) &&
                   Date.Equals(dTO.Date);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, FirstTeam, SecondTeam, Date);
        }

        public override string? ToString()
        {
            return $"Id: {Id}, FirstTeam: {FirstTeam.Name}, SecondTeam: {SecondTeam.Name}, Date: {Date:dd-MM-yyyy}";
        }
    }
}
