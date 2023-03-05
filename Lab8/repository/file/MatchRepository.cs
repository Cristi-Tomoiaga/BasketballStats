using Lab8.domain;
using Lab8.domain.validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.repository.file
{
    internal class MatchRepository : InFileRepository<long, Match>
    {
        public MatchRepository(IValidator<Match> validator, string filename) : base(validator, filename, CSVMappers.CreateMatch)
        {
        }
    }
}
