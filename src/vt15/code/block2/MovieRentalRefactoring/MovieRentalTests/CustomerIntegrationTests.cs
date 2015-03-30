using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieRentalBefore;

namespace MovieRentalTests
{
    [TestClass]
    public class CustomerIntegrationTests
    {
        private Customer customer;

        [TestMethod]
        public void Statement_OneCustomerWithTwoRentals_Statement()
        {
            // Act
            string actual = customer.Statement();
            string expected = "Rental Record for Sarah\n\tMovieA\t2\n\tMovieB\t3\n\nAmount owed is 5\n\nYou earned 2 frequent renter points";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HtmlStatement_OneCustomerWithTwoRentals_HtmlStatement()
        {
            // Act
            //string actual = customer.HtmlStatement();
            //string expected = "<h1>Rental Record for Sarah</h1><table><tr><th>Movie</th><th>Days Rented</th></tr><tr><td>MovieA</td><td>2</td></tr><tr><td>MovieB</td><td>3</td></tr></table><p>Amount owed is 5</p><p>You earned 2 frequent renter points</p>";

            // Assert
            //Assert.AreEqual(expected, actual);
        }

        [TestInitialize]
        public void giveCustomerTwoRentals()
        {
            /* ARRANGE */
            // Create customer
            customer = new Customer("Sarah");

            // First movie
            Movie m1 = new Movie("MovieA", Movie.REGULAR);
            DVD d1 = new DVD("123", m1);
            Rental r1 = new Rental(d1, 2);

            // Second movie
            Movie m2 = new Movie("MovieB", Movie.NEW_RELEASE);
            DVD d2 = new DVD("321", m2);
            Rental r2 = new Rental(d2, 1);

            // Add rentals
            customer.AddRental(r1);
            customer.AddRental(r2);
        }

        [TestCleanup]
        public void resetCustomer()
        {
            customer = null;
        }

        
    }
}
