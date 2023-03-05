using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.domain.validator
{
    internal class TeamValidator : IValidator<Team>
    {
        public void Validate(Team entity)
        {
            string errors = "";

            if (entity.Id <= 0)
                errors += "Invalid id\n";
            if (entity.Name.Equals(""))
                errors += "Invalid name\n";

            if (!errors.Equals(""))
                throw new ValidationException(errors);
        }
    }
}
