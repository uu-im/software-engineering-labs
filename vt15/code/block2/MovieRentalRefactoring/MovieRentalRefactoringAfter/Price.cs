
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalRefactoringAfter
{
    public abstract class Price
    {
        private static Price _childrens = new ChildrensPrice();
        private static Price _newRelease = new NewReleasePrice();
        private static Price _regular = new RegularPrice();

        public static Price Regular()
        {
            return _regular;
        }

        public static Price Childrens()
        {
            return _childrens;
        }

        public static Price NewRelease()
        {
            return _newRelease;
        }

        public abstract int PriceCode();
        public abstract double Charge(int daysRented);
        public virtual int FrequentRenterPoints(int daysRented)
        {
            return 1;
        }
    }

    class ChildrensPrice : Price
    {
        public override int PriceCode()
        {
            return Movie.CHILDRENS;
        }

        public override double Charge(int daysRented)
        {
            double result = 1.5;
            if (daysRented > 3)
                result += (daysRented - 3) * 1.5;
            return result;
        }
    }

    class NewReleasePrice : Price
    {
        public override int PriceCode()
        {
            return Movie.NEW_RELEASE;
        }

        public override double Charge(int daysRented)
        {
            return daysRented * 3;
        }

        public override int FrequentRenterPoints(int daysRented)
        {
            return (daysRented > 1) ? 2 : 1;
        }
    }

    class RegularPrice : Price
    {
        public override int PriceCode()
        {
            return Movie.REGULAR;
        }

        public override double Charge(int daysRented)
        {
            double result = 2;
            if (daysRented > 2)
                result += (daysRented - 2) * 1.5;
            return result;
        }
    }
}
