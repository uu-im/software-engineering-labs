using System;

namespace Wildlife
{
  class Fox : IAnimal
  {
    public string GetDescription()
    {
      return "Friendly Fox";
    }

    public char ToChar()
    {
      return 'W';
    }

    public int Eat(){
      return 5;
    }
  }
}
