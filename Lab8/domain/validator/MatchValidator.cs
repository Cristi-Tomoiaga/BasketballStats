using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.domain.validator
{
    internal class MatchValidator : IValidator<Match>
    {
        public void Validate(Match entity)
        {
            string errors = "";

            if (entity.Id <= 0)
                errors += "Invalid id\n";
            if (entity.IdFirstTeam <= 0)
                errors += "Invalid first team id\n";
            if (entity.IdSecondTeam <= 0)
                errors += "Invalid second team id\n";

            if (!errors.Equals(""))
                throw new ValidationException(errors);
        }
    }
}
