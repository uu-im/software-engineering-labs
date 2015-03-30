using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicketMachine
{
    interface ITicketMachine
    {
        string InsertMoney(int amount);
        string ShowBalance();
        string ShowPrice();
        string RefundMoney();
        string PrintTicket();
    }
}