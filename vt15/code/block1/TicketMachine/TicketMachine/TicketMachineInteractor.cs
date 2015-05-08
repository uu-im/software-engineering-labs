using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicketMachine
{
  class TicketMachineInteractor
  {
    ITicketMachine tm;

    public TicketMachineInteractor(ITicketMachine ticketMachine)
    {
      tm = ticketMachine;
    }

    public void Start()
    {
      UserInteractor.Clear();
      Console.WriteLine(" (q) quit\t: Quit");
      Console.WriteLine(" (i) insert \t: Insert money");
      Console.WriteLine(" (b) balance \t: Show balance");
      Console.WriteLine(" (p) price \t: Show price");
      Console.WriteLine(" (r) refund \t: Refund money");
      Console.WriteLine(" (t) ticket \t: Print ticket");
      act();
    }

    private void act()
    {
      string result = "";
      switch(UserInteractor.Ask("Choose action: ")){

        case "q":
        case "quit":
        UserInteractor.Confirm();
        return;

        case "i":
        case "insert":
        result = insertMoney();
        break;

        case "b":
        case "balance":
        result = showBalance();
        break;

        case "r":
        case "refund":
        result = refundMoney();
        break;

        case "t":
        case "ticket":
        result = printTicket();
        break;

        case "p":
        case "price":
        result = showPrice();
        break;

        default:
          result = "Please enter a valid option.";
        break;
      }

      UserInteractor.Say(result);
      UserInteractor.Confirm();
      Start();
    }


    public string insertMoney()
    {
      int amount;
      while (!Int32.TryParse(UserInteractor.Ask("Please enter amount: "), out amount))
      {
        UserInteractor.Say("Only positive integers, try again: ");
      }

      return tm.InsertMoney(amount);
    }

    public string showBalance()
    {
      return tm.ShowBalance();
    }

    public string showPrice()
    {
      return tm.ShowPrice();
    }

    public string refundMoney()
    {
      return tm.RefundMoney();
    }

    public string printTicket()
    {
      return tm.PrintTicket();
    }
  }






  class UserInteractor
  {
    public static void Say(string message){
      Console.WriteLine(" >>> " + message);
    }

    public static string Ask(string message){
      Console.Write(" >   " + message);
      return Console.ReadLine();
    }

    public static void Confirm(){
      Console.WriteLine(" >   Press any key...");
      Console.ReadKey();
    }

    public static void Clear(){
      Console.Clear();
    }
  }
}
