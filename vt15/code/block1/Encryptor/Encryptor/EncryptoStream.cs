using System;
using System.Collections.Generic;
using System.Linq;

namespace Encryptor
{
  class EncryptoStream
  {
    IAlgorithm language;
    ConsoleKeyInfo lastKey;
    string input = "";
    string encrypted;
    string decrypted;

    public EncryptoStream(IAlgorithm lang)
    {
      language = lang;
    }

    public void Start()
    {
      Console.Clear();
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
        if(input.Length > 0)
          input = input.Substring(0, input.Length - 1);
        break;

        default:
        input += (char)lastKey.KeyChar;
        break;
      }

      input = input
        .Replace("\n",   "")
        .Replace("\r",   "")
        .Replace("\r\n", "");

      encrypted = language.Encrypt(input);
      decrypted = language.Decrypt(encrypted);

      print();
    }

    void print()
    {
      Console.Clear();
      Console.WriteLine(language.GetName() + "\r\n");
      Console.WriteLine("> " + input + "\r\n");
      Console.WriteLine("ENCRYPTED: " + encrypted + "\r\n");
      Console.WriteLine("DECRYPTED: " + decrypted);
      read();
    }
  }
}
