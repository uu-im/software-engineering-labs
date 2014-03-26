using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicketMachine
{
    class Program
    {
        private static TicketMachineInteractor _interactor;

        public static void Main()
        {
            ITicketMachine machine = new TicketMachine(200);
            _interactor = new TicketMachineInteractor(machine);
            _interactor.Start();
        }
    }
}
