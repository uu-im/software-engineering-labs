using System;

namespace FizzBuzz
{
  public class FizzBuzzer : IFizzBuzzer
  {
    int n = 0;

    public string Next()
    {
      n++;

      if(n%15==0 && n%5==0)
        return "FizzBuzz";
      else if(n%3 == 0)
        return "Fizz";
      else if(n%5 == 0)
        return "Buzz";
      else
        return n.ToString();
    }
  }
}

