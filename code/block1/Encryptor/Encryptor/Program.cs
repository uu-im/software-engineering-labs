using System;

namespace Encryptor
{
  class MainClass
  {
    public static void Main()
    {
      two();
    }

    static void one()
    {
      Translator.AddLanguage(new CaesarCipher(2));
      Translator.AddLanguage(new CaesarCipher(-5));
      Translator.AddLanguage(new RobberLanguage());
      Translator.AddLanguage(new LeetLanguage());
      Translator.Start();
    }

    static void two()
    {
      IAlgorithm lang = new ReverseLang();
      EncryptoStream ls = new EncryptoStream(lang);
      ls.Start();
    }
  }
}
