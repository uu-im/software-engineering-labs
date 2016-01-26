using System;

namespace MathLibrary
{
    public class MathLib
    {
        public static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        public static int Max(int[] numbers)
        {
            int max = -1;
            foreach (int n in numbers)
                if (n > max)
                    max = n;
            return max;
        }

        public static int Average(int[] numbers)
        {
            throw new NotImplementedException();
        }

        public static int Reverse(int number)
        {
            throw new NotImplementedException();
        }

        public static int Factorial(int number)
        {
            throw new NotImplementedException();
        }

        public static bool IsLeapYear(int year)
        {
            throw new NotImplementedException();
        }

        public static int[] Primes(int max)
        {
            throw new NotImplementedException();
        }

        public static bool IsPrime(int number)
        {
            throw new NotImplementedException();
        }
    }
}
