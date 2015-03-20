using System;

namespace Encryptor
{
  class MainClass
  {
    public static void Main()
    {
      Translator.AddLanguage(new CaesarCipher(2));
      Translator.AddLanguage(new CaesarCipher(-5));
      Translator.AddLanguage(new RobberLanguage());
      Translator.AddLanguage(new LeetLanguage());
      Translator.Start();
    }
  }
}
