using System;

namespace MovieRentalRefactoringAfter
{
    public class DomainObject
    {
        public string Name { get; protected set; }

        public DomainObject(string name)
	    {
            Name = name;
	    }

	    public DomainObject()
	    {
            Name = "No name";
	    }

        public override string ToString()
        {
 	         return Name;
        }
    }
}
