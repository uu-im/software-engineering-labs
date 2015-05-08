using System;
using System.Collections.Generic;
using System.Linq;

namespace Encryptor
{
  public class MultiCipher : IAlgorithm
  {
    IList<IAlgorithm> algorithms = new List<IAlgorithm>();

    public MultiCipher(){}
    public MultiCipher(IAlgorithm algorithm)
    {
      Add(algorithm);
    }
    public MultiCipher(IList<IAlgorithm> algorithms)
    {
      Add(algorithms);
    }

    public void Add(IAlgorithm algorithm)
    {
      this.algorithms.Add(algorithm);
    }

    public void Add(IList<IAlgorithm> algorithms)
    {
      foreach (IAlgorithm a in algorithms)
        this.algorithms.Add(a);
    }

    public string Encrypt(string input)
    {
      string output = input;

      foreach(IAlgorithm a in algorithms)
        output = a.Encrypt(output);

      return output;
    }

    public string Decrypt(string input)
    {
      string output = input;

      for (int i = algorithms.Count - 1; i >= 0; i--)
        output = algorithms[i].Decrypt(output);

      return output;
    }

    public string GetName()
    {
      return "Reverser";
    }
  }
}
