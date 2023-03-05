using Lab8.domain;
using Lab8.domain.dto;
using Lab8.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.service
{
    internal class ActivePlayerService
    {
        private readonly IRepository<long, ActivePlayer> activePlayerRepository;
        private readonly IRepository<long, Player> playerRepository;
        private readonly IRepository<long, Match> matchRepository;
        private readonly IRepository<long, Team> teamRepository;

        public ActivePlayerService(IRepository<long, ActivePlayer> activePlayerRepository, IRepository<long, Player> playerRepository, IRepository<long, Match> matchRepository, IRepository<long, Team> teamRepository)
        {
            this.activePlayerRepository = activePlayerRepository;
            this.playerRepository = playerRepository;
            this.matchRepository = matchRepository;
            this.teamRepository = teamRepository;
        }

        public IEnumerable<ActivePlayerDTO> FindAll()
        {
            return activePlayerRepository.FindAll()
                .Select(x =>
                {
                    Player player = playerRepository.FindOne(x.IdPlayer);
                    Match match = matchRepository.FindOne(x.IdMatch);

                    return new ActivePlayerDTO(
                            x.Id,
                            new PlayerDTO(player.Id, player.Name, player.School, teamRepository.FindOne(player.IdTeam)),
                            new MatchDTO(match.Id, teamRepository.FindOne(match.IdFirstTeam), teamRepository.FindOne(match.IdSecondTeam), match.Date),
                            x.NumberOfPointsScored,
                            x.Type
                    );
                })
                .ToList();
        }
    }
}
