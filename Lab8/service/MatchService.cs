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
    internal class MatchService
    {
        private readonly IRepository<long, Match> matchRepository;
        private readonly IRepository<long, Team> teamRepository;

        public MatchService(IRepository<long, Match> matchRepository, IRepository<long, Team> teamRepository)
        {
            this.matchRepository = matchRepository;
            this.teamRepository = teamRepository;
        }

        public IEnumerable<MatchDTO> FindAll() 
        {
            return matchRepository.FindAll()
                .Select(x => new MatchDTO(x.Id, teamRepository.FindOne(x.IdFirstTeam), teamRepository.FindOne(x.IdSecondTeam), x.Date))
                .ToList();
        }
    }
}
