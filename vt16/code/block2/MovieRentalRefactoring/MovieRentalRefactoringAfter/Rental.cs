using System;

namespace MovieRentalRefactoringAfter
{
    public class Rental : DomainObject
    {
        public int DaysRented { get; private set; }
        public DVD DVD { get; private set; }

        public Rental(DVD dvd, int daysRented) {
    	    DVD = dvd;
    	    DaysRented = daysRented;
        }

        public double Charge()
        {
            return DVD.Movie.Charge(DaysRented);
        }

        public int calculateFrequentRenterPoints()
        {
            return DVD.Movie.FrequentRenterPoints(DaysRented);
        }
    }
}
