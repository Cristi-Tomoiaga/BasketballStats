using Lab8.domain;
using Lab8.domain.validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.repository.file
{
    internal class PlayerRepository : InFileRepository<long, Player>
    {
        public PlayerRepository(IValidator<Player> validator, string filename) : base(validator, filename, CSVMappers.CreatePlayer)
        {
        }
    }
}
