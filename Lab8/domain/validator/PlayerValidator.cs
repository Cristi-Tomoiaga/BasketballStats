using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.domain.validator
{
    internal class PlayerValidator : IValidator<Player>
    {
        public void Validate(Player entity)
        {
            string errors = "";

            if (entity.Id <= 0)
                errors += "Invalid id\n";
            if (entity.Name.Equals(""))
                errors += "Invalid name\n";
            if (entity.School.Equals(""))
                errors += "Invalid school\n";
            if (entity.IdTeam <= 0)
                errors += "Invalid team id\n";

            if (!errors.Equals(""))
                throw new ValidationException(errors);
        }
    }
}
