using System;
using System.Collections.Generic;

namespace MovieRentalRefactoringAfter
{
    public class Customer : DomainObject
    {
        private ICollection<Rental> rentals = new List<Rental>();

        public Customer(string name)
        {
            Name = name;
        }

        public String Statement()
        {
            String result = "Rental Record for " + Name + "\n";

            //show figures for this rental
            foreach (Rental each in rentals)
                result += "\t" + each.DVD.Movie.Name + "\t" + each.Charge().ToString() + "\n";

            //add footer lines
            result += "\nAmount owed is " + charge().ToString() + "\n\n";
            result += "You earned " + frequentRenterPoints().ToString() + " frequent renter points";
            return result;
        }

        public string HtmlStatement()
        {
            String result = "<h1>Rental Record for " + Name + "</h1>";
            result += "<table><tr><th>Movie</th><th>Days Rented</th></tr>";
            //show figures for this rental
            foreach (Rental each in rentals)
                result += "<tr><td>" + each.DVD.Movie.Name + "</td><td>" + each.Charge().ToString() + "</td></tr>";

            //add footer lines
            result += "</table>";
            result += "<p>Amount owed is " + charge().ToString() + "</p>";
            result += "<p>You earned " + frequentRenterPoints().ToString() + " frequent renter points</p>";
            return result;
        }

        private double frequentRenterPoints()
        {
            double result = 0;
            foreach (Rental rental in rentals)
                result += rental.calculateFrequentRenterPoints();
            return result;
        }

        private double charge()
        {
            double result = 0;
            foreach (Rental rental in rentals)
                result += rental.Charge();
            return result;
        }

        public void AddRental(Rental rental) {
            rentals.Add(rental);
        }
    }
}
