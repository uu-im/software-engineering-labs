using System;

namespace Encryptor
{
  interface ILanguage
  {
    string Encrypt(string input);
    string Decrypt(string decrypt);
    string GetName();
  }
}
