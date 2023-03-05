using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.domain
{
    internal abstract class Entity<ID>
    {
        public ID Id { get; set; }
    }
}
