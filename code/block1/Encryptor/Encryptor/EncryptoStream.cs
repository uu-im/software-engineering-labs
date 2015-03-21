using System;
using System.Collections.Generic;
using System.Linq;

namespace Encryptor
{
  class EncryptoStream
  {
    ILanguage language;
    ConsoleKeyInfo lastKey;
    string input = "";
    string output;

    public EncryptoStream(ILanguage lang)
    {
      language = lang;
    }

    public void Start()
    {
      Console.Clear();
      Console.Clear();
      Console.WriteLine(language.GetName() + "\r\n");
      Console.WriteLine("Simply start typing... esc to quit.");
      read();
    }

    void read()
    {
      lastKey = Console.ReadKey();
      evaluate();
    }

    void evaluate()
    {
      switch(lastKey.Key)
      {
        case ConsoleKey.Escape:
        return;

        case ConsoleKey.Backspace:
        input = input.Substring(0, input.Length - 1);
        break;

        default:
        char c = lastKey.KeyChar;
        input += c;
        break;
      }
      output = language.Encrypt(input);
      print();
    }

    void print()
    {
      Console.Clear();
      Console.WriteLine(language.GetName() + "\r\n");
      Console.WriteLine("======== P L A I N =========");
      Console.WriteLine(input + "\r\n");
      Console.WriteLine("==== E N C R Y P T E D =====");
      Console.WriteLine(output);
      read();
    }
  }
}
