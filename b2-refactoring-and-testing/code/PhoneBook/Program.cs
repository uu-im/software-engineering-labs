using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneBook
{
    class Program
    {
        static PhoneBook PB = new PhoneBook();

        static void Main(string[] args)
        {
            string input = null;

            do
            {
                printMenu();

                input = Console.ReadLine();
                int choice;

                if (Int32.TryParse(input, out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            newPersonPrompt();
                            break;
                        case 2:
                            searchPrompt();
                            break;
                    }
                }
                else
                    Console.WriteLine("Invalid input");
            }
            while (input != "0");
        }

        static void printMenu()
        {
            Console.WriteLine("== Menu ==");
            Console.WriteLine("0: Exit");
            Console.WriteLine("1: Add entry");
            Console.WriteLine("2: Find entry");
            Console.WriteLine("============");
            Console.Write("Choose action: ");
        }

        static void newPersonPrompt()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter number: ");
            string number = Console.ReadLine();
            if (PB.Put(name, number))
                Console.WriteLine("Successfully saved person");
            else
                Console.WriteLine("Could not save person");
            
        }

        static void searchPrompt()
        {
            Console.Write("Enter the name of the person you wish to find: ");
            string name = Console.ReadLine();
            Console.WriteLine(name + " : " + PB.Get(name));
        }
    }
}
