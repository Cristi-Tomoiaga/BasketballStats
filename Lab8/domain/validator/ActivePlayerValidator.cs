using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.domain.validator
{
    internal class ActivePlayerValidator : IValidator<ActivePlayer>
    {
        public void Validate(ActivePlayer entity)
        {
            string errors = "";

            if (entity.Id <= 0)
                errors += "Invalid id\n";
            if (entity.IdPlayer <= 0)
                errors += "Invalid player id\n";
            if (entity.IdMatch <= 0)
                errors += "Invalid match id\n";
            if (entity.NumberOfPointsScored < 0)
                errors += "Invalid number of points scored\n";

            if (!errors.Equals(""))
                throw new ValidationException(errors);
        }
    }
}
