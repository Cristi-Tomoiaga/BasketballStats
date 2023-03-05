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
    internal class PlayerService
    {
        private readonly IRepository<long, Player> playerRepository;
        private readonly IRepository<long, Team> teamRepository;

        public PlayerService(IRepository<long, Player> playerRepository, IRepository<long, Team> teamRepository)
        {
            this.playerRepository = playerRepository;
            this.teamRepository = teamRepository;
        }

        public IEnumerable<PlayerDTO> FindAll()
        {
            return playerRepository.FindAll()
                .Select(x => new PlayerDTO(x.Id, x.Name, x.School, teamRepository.FindOne(x.IdTeam)))
                .ToList();
        }
    }
}
