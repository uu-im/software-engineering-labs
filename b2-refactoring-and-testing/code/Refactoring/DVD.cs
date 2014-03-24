using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Refactoring
{
    class DVD : DomainObject
    {
        public Movie Movie { get; private set; }
        public string SerialNumber { get; private set; }

        public DVD(String serialNumber, Movie movie)
        {
            SerialNumber = serialNumber;
            Movie = movie;
        }
    }
}
