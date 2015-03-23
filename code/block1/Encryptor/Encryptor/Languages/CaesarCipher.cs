using System;
using System.Collections.Generic;
using System.Linq;

namespace Encryptor
{
  public class CaesarCipher : ILanguage
  {
    int shift;

    public CaesarCipher(int steps)
    {
      shift = steps;
    }

    public string Encrypt(string input)
    {
      string output = "";
      foreach(char c in input)
      {
        char cc = c;

        if(isWithinAlphabet(cc))
        {
          bool lower = isLowercase(cc);

          if(lower)
            cc = Char.ToUpper(cc);
          
          cc += (char)shift;

          while(isAboveUppercaseAlphabet(cc) || isBelowUppercaseAlphabet(cc))
          { 
            if(isAboveUppercaseAlphabet(cc))
              cc = (char)(cc - 26);
            else
              cc = (char)(cc + 26);
          }

          if(lower)
            cc = Char.ToLower(cc);
        }

        output += cc;
      }
      return output;
    }

    public string Decrypt(string input)
    {
      CaesarCipher cipher = new CaesarCipher(shift * -1);
      return cipher.Encrypt(input);
    }

    public string GetName()
    {
      return "Caesar Cipher " + shift + " step(s)";
    }

    private static bool isWithinAlphabet(char c)
    {
      return (65<=c && c<=90) || (97<=c && c<=122);
    }

    private static bool isLowercase(char c)
    {
      return (97<=c && c<=122);
    }

    private static bool isAboveUppercaseAlphabet(char c)
    {
      return c > 90;
    }

    private static bool isBelowUppercaseAlphabet(char c)
    {
      return c < 65;
    }

  }
}
