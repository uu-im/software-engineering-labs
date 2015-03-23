using System;

namespace Encryptor
{
  public interface ILanguage
  {
    string Encrypt(string input);
    string Decrypt(string decrypt);
    string GetName();
  }
}
