using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Refactoring
{
    public class DomainObject
    {
        public string Name { get; protected set; }

        public override string  ToString()
        {
            return Name;
        }
    }
}
