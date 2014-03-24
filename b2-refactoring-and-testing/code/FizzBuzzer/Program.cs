using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FizzBuzzer
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            do
            {
                n = askForInput();
                Console.WriteLine(n + " => " + FizzBuzzer.FizzOrBuzz(n));
            }
            while (n != -1);
        }

        static int askForInput()
        {
            Console.Write("Enter the number you wish to FizzBuzz: ");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
