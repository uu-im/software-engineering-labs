using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Refactoring
{
    class Rental : DomainObject
    {
        public DVD DVD { get; private set; }
        public int DaysRented { get; private set; }

        public Rental(DVD dvd, int daysRented)
        {
            DVD = dvd;
            DaysRented = daysRented;
        }
    }
}
