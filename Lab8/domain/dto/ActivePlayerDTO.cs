using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.domain.dto
{
    internal class ActivePlayerDTO
    {
        public long Id { get; set; }

        public PlayerDTO Player { get; set; }

        public MatchDTO Match { get; set; }

        public int NumberOfPointsScored { get; set; }

        public PlayerType Type { get; set; }

        public ActivePlayerDTO(long id, PlayerDTO player, MatchDTO match, int numberOfPointsScored, PlayerType type)
        {
            Id = id;
            Player = player;
            Match = match;
            NumberOfPointsScored = numberOfPointsScored;
            Type = type;
        }

        public override bool Equals(object? obj)
        {
            return obj is ActivePlayerDTO dTO &&
                   Id == dTO.Id &&
                   EqualityComparer<PlayerDTO>.Default.Equals(Player, dTO.Player) &&
                   EqualityComparer<MatchDTO>.Default.Equals(Match, dTO.Match) &&
                   NumberOfPointsScored == dTO.NumberOfPointsScored &&
                   Type == dTO.Type;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Player, Match, NumberOfPointsScored, Type);
        }

        public override string? ToString()
        {
            return $"Id: {Id}, Player: {Player.Name}, Match: {Match.FirstTeam.Name}-{Match.SecondTeam.Name}, NumberOfPointsScored: {NumberOfPointsScored}, Type: {Type}";
        }
    }
}
