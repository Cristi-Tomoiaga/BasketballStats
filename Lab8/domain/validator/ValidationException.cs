using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.domain.validator
{
    internal class ValidationException : ApplicationException
    {
        public ValidationException(string? message) : base(message)
        {
        }
    }
}
