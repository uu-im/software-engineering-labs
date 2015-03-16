using System;

namespace Wildlife
{
  class MainClass
  {
    public static void Main(string[] args)
    {
      for(int i=0; i<3; i++)
        Simulation.Add(new Rabbit());

      for(int i=0; i<3; i++)
        Simulation.Add(new Fox());

      Simulation.Start();
    }
  }
}
