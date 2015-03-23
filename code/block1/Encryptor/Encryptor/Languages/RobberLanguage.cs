using System;
using System.Collections.Generic;
using System.Linq;

namespace Encryptor
{
  public class RobberLanguage : ILanguage
  {
    IList<char> vowels = new List<char>(){
      'a', 'o', 'u', 'e', 'i', 'y'
    };

    public string Encrypt(string input)
    {
      string output = "";
      foreach(char c in input)
        if(vowels.Contains(c))
          output += c;
        else
          output += c + "o" + c;
      return output;
    }

    public string Decrypt(string decrypt)
    {
      return "decrypted";
    }

    public string GetName()
    {
      return "Language of the robbers";
    }
  }
}
