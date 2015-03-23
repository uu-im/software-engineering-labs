using System;
using System.Collections.Generic;
using System.Linq;

namespace Encryptor
{
  public class LeetLanguage : ILanguage
  {
    static IList<KeyValuePair<char,char>> shifts = new List<KeyValuePair<char,char>>()
    {
      new KeyValuePair<char,char>('a','4'),
      new KeyValuePair<char,char>('b','6'),
      new KeyValuePair<char,char>('e','3'),
      new KeyValuePair<char,char>('g','9'),
      new KeyValuePair<char,char>('i','!'),
      new KeyValuePair<char,char>('l','1'),
      new KeyValuePair<char,char>('o','0'),
      new KeyValuePair<char,char>('t','7')
    };

    public string Encrypt(string input)
    {
      return convert(input, true);
    }

    public string Decrypt(string input)
    {
      return convert(input, false); 
    }

    public string GetName()
    {
      return "1337 Language";
    }

    private static string convert(string input, bool encode)
    {
      string output = "";
      foreach(char c in input.ToLower())
      {
        char cc = c;
        foreach(KeyValuePair<char,char> kvp in shifts)
        {
          char fromChar = encode ? kvp.Key   : kvp.Value;
          char toChar   = encode ? kvp.Value : kvp.Key;

          if(fromChar == c)
          {
            cc = toChar;
            break;
          }
        }
        output += cc;
      }
      return output;
    }
  }
}
