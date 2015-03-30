using System;

namespace Encryptor
{
  public interface IAlgorithm
  {
    string Encrypt(string input);
    string Decrypt(string decrypt);
    string GetName();
  }
}
