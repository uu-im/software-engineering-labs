using System;
using System.Collections.Generic;
using System.Linq;

namespace Encryptor
{
  class ReverseLang : ILanguage
  {
    public string Encrypt(string input)
    {
      string reversed = "";
      for(int i=input.Length-1; i>=0; i--)
        reversed += input[i];
      return reversed;
    }

    public string Decrypt(string input)
    {
      return Encrypt(input);
    }

    public string GetName()
    {
      return "Reverser";
    }
  }
}
