using System;
using System.Collections.Generic;
using System.Linq;

namespace Encryptor
{
  class Translator
  {
    private static IList<ILanguage> languages = new List<ILanguage>();

    public static void AddLanguage(ILanguage language)
    {
      languages.Add(language);
    }

    public static void Start()
    {
      ILanguage language;
      LanguageStrategy strategy;

      while((language = LanguageSelector.Start(languages)) != null)
        while((strategy = LanguageStrategySelector.Start(language)) != null)
          while(StrategyEvaluator.Start(strategy));
    }
  }

  class LanguageStrategySelector
  {
    static ILanguage language;

    public static LanguageStrategy Start(ILanguage lang)
    {
      language = lang;
      return print();
    }

    private static LanguageStrategy print()
    {
      Console.Clear();
      Console.WriteLine("LANGUAGE: " + language.GetName() + "\r\n");
      Console.WriteLine("[  1  ]  Encrypt");
      Console.WriteLine("[  2  ]  Decrypt");
      Console.WriteLine("[ Esc ]  Go back");
      Console.WriteLine("\r\nSelect option by pressing appropriate key: "); 
      return read();
    }

    private static LanguageStrategy read()
    {
      var key = Console.ReadKey();
      switch(key.Key)
      {
        case(ConsoleKey.D1):
          return new LanguageEncodeStrategy(language);
        break;

        case(ConsoleKey.D2):
          return new LanguageDecodeStrategy(language);
        break;

        case(ConsoleKey.Escape):
          return null;

        default:
          return print();
      }
    }
  }

  abstract class LanguageStrategy
  {
    protected ILanguage language;
    public LanguageStrategy(ILanguage lang)
    {
      language = lang;
    }
    public abstract string Translate(string input);
    public abstract string GetTranslationType();
    public string GetLanguageName()
    {
      return language.GetName();
    }

  }

  class LanguageEncodeStrategy : LanguageStrategy
  {
    public LanguageEncodeStrategy(ILanguage lang) : base(lang){}
    public override string Translate(string input)
    {
      return language.Encrypt(input);
    }
    public override string GetTranslationType()
    {
      return "Encryption";
    }
  }

  class LanguageDecodeStrategy : LanguageStrategy
  {
    public LanguageDecodeStrategy(ILanguage lang) : base(lang){}
    public override string Translate(string input)
    {
      return language.Decrypt(input);
    }
    public override string GetTranslationType()
    {
      return "Decryption";
    }
  }


  abstract class StrategyEvaluator
  {
    static LanguageStrategy strategy;

    public static bool Start(LanguageStrategy strat)
    {
      strategy = strat;
      return print();
    }

    private static bool print()
    {
      Console.Clear();
      Console.WriteLine("LANGUAGE: " + strategy.GetLanguageName());
      Console.WriteLine("ACTION:   " + strategy.GetTranslationType());
      Console.WriteLine("\r\nEnter a string, then press enter.\r\n");
      return read();
    }

    private static bool read()
    {
      Console.Write("INPUT  : ");

      string input = Console.ReadLine();
      string output = strategy.Translate(input);

      Console.WriteLine("OUTPUT : " + output);
      Console.WriteLine();

      return evaluate();
    }

    private static bool evaluate()
    {
      Console.WriteLine("Press any key to make another translation, esc to go back");
      var key = Console.ReadKey();
      return key.Key != ConsoleKey.Escape;
    }
  }




  class LanguageSelector
  {
    static IList<ILanguage> languages;
    static ILanguage selectedLanguage;
    static int offset = 0;
    static bool selected;

    public static ILanguage Start(IList<ILanguage> langs)
    {
      if(langs.Count < 1)
        throw new ArgumentException("No languages given");

      languages = langs;
      selectedLanguage = langs[0];

      return print();
    }

    private static ILanguage print()
    {
      Console.Clear();
      Console.WriteLine("WELCOME TO THE ENCRYPTOR");
      Console.WriteLine("Select encryption language");
      Console.WriteLine("Arrow keys to navigate, enter to accept, esc to quit.");
      foreach(ILanguage l in languages)
      {
        if(l == selectedLanguage)
        Console.WriteLine("(*) " + l.GetName());
        else
        Console.WriteLine("( ) " + l.GetName());
      }
      return read();
    }

    private static ILanguage read()
    {
      var key = Console.ReadKey();
      switch(key.Key)
      {
        case(ConsoleKey.DownArrow):
          offset++;
          break;

        case(ConsoleKey.UpArrow):
          offset--;
          break;

        case(ConsoleKey.Enter):
          return choose();

        case(ConsoleKey.Escape):
          return null;
      }
      return evaluate();
    }

    private static ILanguage evaluate()
    {
      if(offset < 0)
        offset = languages.Count - 1;
      else if(offset >= languages.Count)
        offset = 0;

      selectedLanguage = languages[offset];

      return print();
    }

    private static ILanguage choose()
    {
      return languages[offset];
    }
  }
}
