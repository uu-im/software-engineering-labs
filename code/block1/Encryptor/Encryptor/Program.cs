using System;

namespace Encryptor
{
  class MainClass
  {
    public static void Main()
    {
      Translator.AddLanguage(new RobberLanguage());
      Translator.AddLanguage(new RobberLanguage());
      Translator.Start();
    }
  }
}
