using System;

namespace MovieRentalBefore
{
    public class Rental : DomainObject
    {
        public int DaysRented { get; private set; }
        public DVD DVD { get; private set; }

        public Rental(DVD dvd, int daysRented) {
    	    DVD = dvd;
    	    DaysRented = daysRented;
        }
    }
}
