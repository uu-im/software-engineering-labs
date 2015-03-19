using System;

namespace Encryptor
{
  class RobberLanguage : ILanguage
  {
    public string Encrypt(string input)
    {
      return input + "encrypted";
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
