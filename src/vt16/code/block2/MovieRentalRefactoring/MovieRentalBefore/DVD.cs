using System;

namespace MovieRentalBefore
{
    public class DVD : DomainObject
    {
        public Movie Movie { get; private set; }
        private string serialNo;

        public DVD(string serialNumber, Movie movie)
        {
            serialNo = serialNumber;
            Movie = movie;
        }
    }
}
