using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalRefactoring
{
    public class DomainObject
    {
        public string Name { get; protected set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
