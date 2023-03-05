using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.domain.validator
{
    internal interface IValidator<E>
    {
        void Validate(E entity);
    }
}
