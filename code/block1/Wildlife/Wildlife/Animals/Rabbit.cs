using System;

namespace Wildlife
{
  class Rabbit : IAnimal
  {
    public string GetDescription()
    {
      return "Quick Rabbit";
    }


    public char ToChar()
    {
      return '"';
    }

    public int Eat(){
      return 2;
    }
  }
}
