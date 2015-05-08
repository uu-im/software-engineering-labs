using System;

namespace FizzBuzzer
{
    public class FizzBuzz
    {
        public static string FizzOrBuzz(int n)
        {
            bool divisibleByThree = n % 3 == 0,
                 divisibleByFive = n % 5 == 0;

            if (divisibleByThree && divisibleByFive)
                return "FizzBuzz";
            else if (divisibleByThree)
                return "Fizz";
            else if (divisibleByFive)
                return "Buzz";
            else
                return n.ToString();
        }
    }
}
