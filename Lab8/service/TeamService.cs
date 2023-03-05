using Lab8.domain;
using Lab8.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.service
{
    internal class TeamService
    {
        private readonly IRepository<long, Team> teamRepository;

        public TeamService(IRepository<long, Team> teamRepository)
        {
            this.teamRepository = teamRepository;
        }

        public IEnumerable<Team> FindAll()
        {
            return teamRepository.FindAll();
        }
    }
}
