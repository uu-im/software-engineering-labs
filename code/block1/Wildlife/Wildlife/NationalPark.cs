using System;
using System.Collections.Generic;
using System.Linq;

namespace Wildlife
{
  class NationalPark
  {
   /* private static int guids = 0;
    private int guid = generateGuid();
    private ICollection<IAnimal> animals;
    private int time = 0;

    public NationalPark()
    {
      animals = new List<IAnimal>();
      Console.WriteLine("NationalPark ["+guid+"] CREATED");
    }

    public void Add(IAnimal animal)
    {
      animals.Add(animal);
    }

    public void PrintInfo()
    {
      Console.WriteLine("\r\nPARK NO." +guid + "     TIME " + time);
      Console.WriteLine("=====================");
      Console.WriteLine("NO.ANIMALS: " + animals.Count);
      Console.WriteLine();

      IEnumerable<IGrouping<string, IAnimal>> groups =
        animals.GroupBy(a => a.GetDescription(), a => a);

      foreach(IGrouping<string, IAnimal> g in groups)
      {
        Console.Write("- " + g.ToList().Count + " ");
        Console.Write(g.Key + "(s)");
        Console.WriteLine();
      }

      Console.WriteLine("=====================\r\n");
    }

    public void StartSimulation()
    {
      while(++time > 0)
      {
        foreach(IAnimal a in animals)
        {
          a.Eat();
        }
        PrintInfo();

        Console.WriteLine("Press any key... (Ctrl + C to escape)");
        Console.ReadKey();
      }
    }

    private static int generateGuid()
    {
      return ++guids;
    }*/
  }
}
