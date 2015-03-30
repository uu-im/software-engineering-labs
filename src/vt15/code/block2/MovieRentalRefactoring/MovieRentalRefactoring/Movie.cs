using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalRefactoring
{
    public class Movie : DomainObject
    {
        public const int CHILDRENS = 2;
        public const int REGULAR = 0;
        public const int NEW_RELEASE = 1;

        public int PriceCode { get; private set; }

        public Movie(String name, int priceCode)
        {
            Name = name;
            PriceCode = priceCode;
        }
    }
}
