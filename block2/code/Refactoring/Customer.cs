using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Refactoring
{
    class Customer : DomainObject
    {
        private ICollection<Rental> rentals = new List<Rental>();

        public Customer(String name)
        {
            Name = name;
        }

        public String Statement()
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            String result = "Rental Record for " + Name + "\n";

            foreach (Rental each in rentals)
            {
                double thisAmount = 0;

                //determine amounts for each line
                switch (each.DVD.Movie.PriceCode)
                {
                    case Movie.REGULAR:
                        thisAmount += 2;
                        if (each.DaysRented > 2)
                            thisAmount += (each.DaysRented - 2) * 1.5;
                        break;
                    case Movie.NEW_RELEASE:
                        thisAmount += each.DaysRented * 3;
                        break;
                    case Movie.CHILDRENS:
                        thisAmount += 1.5;
                        if (each.DaysRented > 3)
                            thisAmount += (each.DaysRented - 3) * 1.5;
                        break;

                }
                totalAmount += thisAmount;

                // add frequent renter points
                frequentRenterPoints++;
                // add bonus for a two day new release rental
                if ((each.DVD.Movie.PriceCode == Movie.NEW_RELEASE) && each.DaysRented > 1) frequentRenterPoints++;

                //show figures for this rental
                result += "\t" + each.DVD.Movie.Name + "\t" + thisAmount + "\n";

            }
            //add footer lines
            result += "Amount owed is " + totalAmount + "\n";
            result += "You earned " + frequentRenterPoints + " frequent renter points";
            return result;
        }

        public void AddRental(Rental rental)
        {
            rentals.Add(rental);
        }
    }
}
