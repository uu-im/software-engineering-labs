using System;

namespace MovieRentalBefore
{
    class Movie : DomainObject
    {
        public const int CHILDRENS = 2;
        public const int REGULAR = 0;
        public const int NEW_RELEASE = 1;

        public int PriceCode { get; private set; }

        public Movie(string name, int priceCode)
        {
            Name = name;
            PriceCode = priceCode;
        }
    }
}
