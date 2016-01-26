using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBook
{
    public class PhoneBook
    {
        public IDictionary<string, int> People { get; private set; }

        public PhoneBook()
        {
            People = new Dictionary<string, int>();
        }

        public bool Put(string name, string number)
        {
            // Null check name and number
            if (name == null
                || number == null
                || String.IsNullOrEmpty(name)
                || String.IsNullOrEmpty(number))
                return false;

            // Check to see if person already exist
            if (People.Keys.Contains(name))
                return false;

            // Remove potential dash from number
            if (number.Contains("-"))
                number = number.Replace("-", String.Empty);

            // Remove whitespace from number
            number = number.Replace(" ", String.Empty);

            // Length check number
            // (Length is like Swedish cell-phone numbers)
            if (number.Length != 10)
                return false;

            // Parse number to int
            int no = 0;
            if (!Int32.TryParse(number, out no))
                return false;

            // Save entry
            People.Add(name, no);

            // Report success
            return true;
        }

        public string Get(string name)
        {
            // Is the person in the phone book?
            if (!People.Keys.Contains(name))
                return "Not found";

            string number = People.First(p => p.Key == name).Value.ToString();

            // Extract number parts
            string firstPart = number.Substring(0, 3),
                   secondPart = number.Substring(3, 3),
                   thirdPart = number.Substring(6, 2),
                   fourthPart = number.Substring(8, 2);

            // Return number
            return String.Format("{0}-{1} {2} {3}", firstPart, secondPart, thirdPart, fourthPart);
        }
    }
}
