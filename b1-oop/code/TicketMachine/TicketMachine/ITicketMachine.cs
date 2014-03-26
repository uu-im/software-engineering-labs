using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicketMachine
{
    public interface ITicketMachine
    {
        string InsertMoney(int amount);
        string ShowBalance();
        string RefundMoney();
        string PrintTicket();
        string GetTicketPrice();
    }
}