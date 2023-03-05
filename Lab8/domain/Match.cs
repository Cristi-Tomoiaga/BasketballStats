using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.domain
{
    internal class Match : Entity<long>
    {
        public long IdFirstTeam { get; set; }

        public long IdSecondTeam { get; set;}

        public DateOnly Date { get; set; }

        public Match(long idFirstTeam, long idSecondTeam, DateOnly date)
        {
            IdFirstTeam = idFirstTeam;
            IdSecondTeam = idSecondTeam;
            Date = date;
        }

        public override bool Equals(object? obj)
        {
            return obj is Match match &&
                   Id == match.Id &&
                   IdFirstTeam == match.IdFirstTeam &&
                   IdSecondTeam == match.IdSecondTeam &&
                   Date.Equals(match.Date);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, IdFirstTeam, IdSecondTeam, Date);
        }

        public override string? ToString()
        {
            return $"Id: {Id}, IdFirstTeam: {IdFirstTeam}, IdSecondTeam: {IdSecondTeam}, Date: {Date:dd-MM-yyyy}";
        }
    }
}
