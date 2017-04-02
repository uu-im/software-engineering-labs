using System;

namespace MovieRentalRefactoringAfter
{
    public class Movie : DomainObject
    {
        public const int CHILDRENS = 2;
        public const int REGULAR = 0;
        public const int NEW_RELEASE = 1;

        private Price _price;

        public Movie(string name)
        {
            Name = name;
        }

        public static Movie NewNewReleaseMovie(string name)
        {
            Movie movie = new Movie(name);
            movie.BeNewRelease();
            return movie;
        }
        public static Movie NewChildrensMovie(string name)
        {
            Movie movie = new Movie(name);
            movie.BeChildrens();
            return movie;
        }
        public static Movie NewRegularMovie(string name)
        {
            Movie movie = new Movie(name);
            movie.BeRegular();
            return movie;
        }

        public void BeRegular()
        {
            _price = Price.Regular();
        }

        public void BeNewRelease()
        {
            _price = Price.NewRelease();
        }

        public void BeChildrens()
        {
            _price = Price.Childrens();
        }

        public double Charge(int daysRented)
        {
            return _price.Charge(daysRented);
        }

        public int FrequentRenterPoints(int daysRented)
        {
            return _price.FrequentRenterPoints(daysRented);
        }
    }
}
