using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicketMachine
{
    class TicketMachineInteractor
    {
        private ITicketMachine _ticketMachine;

        public TicketMachineInteractor(ITicketMachine ticketMachine)
        {
            _ticketMachine = ticketMachine;
        }

        public void Start()
        {
            showMenu();
            next();
        }

        private void next()
        {
            Console.WriteLine("\r\n ==============================================");
            Console.WriteLine(" Choose action (h for help)");
            if(handleInput(read()))
                next();
        }

        private void write(string msg)
        {
            Console.WriteLine(" >>> " + msg);
        }

        private string read()
        {
            Console.Write(" >   ");
            return Console.ReadLine();
        }

        private bool handleInput(string input)
        {
            switch (input)
            {
                case "input": case "i":
                    write("Enter the amount you wish to insert (SEK): ");
                    int amount;
                    while (!Int32.TryParse(read(), out amount))
                        write("Only positive integers, try again:");
                    write(_ticketMachine.InsertMoney(amount));
                    return true;
                case "balance": case "b":
                    write(_ticketMachine.ShowBalance());
                    return true;
                case "refund": case "r":
                    write(_ticketMachine.RefundMoney());
                    return true;
                case "ticket": case "t":
                    write(_ticketMachine.PrintTicket());
                    return true;
                case "p": case "price":
                    write(_ticketMachine.GetTicketPrice());
                    return true;
                case "q": case "quit":
                    return false;
                default:
                    showMenu();
                    return true;
            }
        }

        private void showMenu()
        {
            Console.WriteLine("");
            Console.WriteLine(" (q) quit\t: Quit");
            Console.WriteLine(" (i) insert \t: Insert money");
            Console.WriteLine(" (r) refund \t: Refund money");
            Console.WriteLine(" (t) ticket \t: Print ticket");
            Console.WriteLine(" (p) price \t: Show price");
        }
    }
}
