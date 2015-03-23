using System;
using System.Collections.Generic;
using System.Linq;

namespace Encryptor
{
  public class MultiCipher : ILanguage
  {
    IList<ILanguage> algorithms = new List<ILanguage>();

    public MultiCipher(){}
    public MultiCipher(ILanguage algorithm)
    {
      Add(algorithm);
    }
    public MultiCipher(IList<ILanguage> algorithms)
    {
      Add(algorithms);
    }

    public void Add(ILanguage algorithm)
    {
      this.algorithms.Add(algorithm);
    }

    public void Add(IList<ILanguage> algorithms)
    {
      foreach (ILanguage a in algorithms)
        this.algorithms.Add(a);
    }

    public string Encrypt(string input)
    {
      string output = input;

      foreach(ILanguage a in algorithms)
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
