using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalBefore
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create customer
            Customer cust = new Customer("Sarah");

            // First movie
            Movie m1  = new Movie("The Matrix", Movie.REGULAR);
            DVD d1    = new DVD("123456789", m1);
            Rental r1 = new Rental(d1, 2);

            // Second movie
            Movie m2  = new Movie("TRON: Legacy", Movie.NEW_RELEASE);
            DVD d2    = new DVD("987654321", m2);
            Rental r2 = new Rental(d2, 1);

            // Add rentals
            cust.AddRental(r1);
            cust.AddRental(r2);

            // Print statement
            string foo = cust.Statement();
            Console.ReadKey();
        }
    }
}
