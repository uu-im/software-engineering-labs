using System;
using System.Collections.Generic;
using System.Linq;

namespace Encryptor
{
  class ReverseLang : ILanguage
  {
    public string Encrypt(string input)
    {
      var chars = input
        .ToCharArray()
        .OfType<char>()
        .ToList();

      chars.Reverse();

      return new String(chars.ToArray());
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
