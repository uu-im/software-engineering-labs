using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieRentalRefactoringAfter;

namespace MovieRentalTests
{
    [TestClass]
    public class MovieRentalAfterTests
    {
        private Customer customer;

        [TestMethod]
        public void After_Statement_OneCustomerWithTwoRentals_Statement()
        {
            // Act
            string actual = customer.Statement();
            string expected = "Rental Record for Sarah\n\tMovieA\t2\n\tMovieB\t3\n\nAmount owed is 5\n\nYou earned 2 frequent renter points";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void After_HtmlStatement_OneCustomerWithTwoRentals_HtmlStatement()
        {
            // Act
            string actual = customer.HtmlStatement();
            string expected = "<h1>Rental Record for Sarah</h1><table><tr><th>Movie</th><th>Days Rented</th></tr><tr><td>MovieA</td><td>2</td></tr><tr><td>MovieB</td><td>3</td></tr></table><p>Amount owed is 5</p><p>You earned 2 frequent renter points</p>";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestInitialize]
        public void giveCustomerTwoRentals()
        {
            /* ARRANGE */
            // Create customer
            customer = new Customer("Sarah");

            // First movie
            Movie m1 = Movie.NewRegularMovie("MovieA");
            DVD d1 = new DVD("123", m1);
            Rental r1 = new Rental(d1, 2);

            // Second movie
            Movie m2 = Movie.NewNewReleaseMovie("MovieB");
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
