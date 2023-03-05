using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.domain
{
    enum PlayerType
    {
        Substitute,
        Participant
    }

    internal class ActivePlayer : Entity<long>
    {
        public long IdPlayer { get; set; }

        public long IdMatch { get; set; }

        public int NumberOfPointsScored { get; set; }

        public PlayerType Type { get; set; }

        public ActivePlayer(long idPlayer, long idMatch, int numberOfPointsScored, PlayerType type)
        {
            IdPlayer = idPlayer;
            IdMatch = idMatch;
            NumberOfPointsScored = numberOfPointsScored;
            Type = type;
        }

        public override bool Equals(object? obj)
        {
            return obj is ActivePlayer player &&
                   Id == player.Id &&
                   IdPlayer == player.IdPlayer &&
                   IdMatch == player.IdMatch &&
                   NumberOfPointsScored == player.NumberOfPointsScored &&
                   Type == player.Type;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, IdPlayer, IdMatch, NumberOfPointsScored, Type);
        }

        public override string? ToString()
        {
            return $"Id: {Id}, IdPlayer: {IdPlayer}, IdMatch: {IdMatch}, NumberOfPointsScored: {NumberOfPointsScored}, Type: {Type}";
        }
    }
}
