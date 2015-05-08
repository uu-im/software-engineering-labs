using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicketMachine
{
    class TicketMachine : ITicketMachine
    {
        private int _cost, _balance;

        public TicketMachine(int cost)
        {
            _cost = cost;
        }
        public string InsertMoney(int amount)
        {
            if (amount > 0){
                _balance += amount;
                return "Inserted " + amount;
            }else{
                return "Cannot insert negative amounts.";
            }
        }

        public string ShowBalance()
        {
            return "Your balance is currently: " + _balance + " kr";
        }

        public string RefundMoney()
        {
            if (_balance > 0)
            {
                int balance = _balance;
                _balance = 0;
                return "Refunding " + balance;
            }
            else
            {
                return "Nothing to refund";
            }
        }

        public string PrintTicket()
        {
            if (_balance >= _cost)
            {
                _balance -= _cost;
                if (_balance > 0)
                    return "Printing ticket... " + RefundMoney();
                else
                    return "Printing ticket.... ";
            }
            else
            {
                return "Insufficient funds..";
            }
        }

        public string ShowPrice()
        {
            return "The price of one ticket is " + _cost.ToString() + " kr";
        }
    }
}
