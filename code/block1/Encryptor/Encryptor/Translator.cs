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

      Alternative alt = AlternativeSelector.Start(
        Alternative.CreateMany(langs),
        new List<string>(){
          "WELCOME TO THE ENCRYPTOR",
          "Select language.",
          "Arrow keys to navigate, enter to accept, esc to quit."});

      return (ILanguage)(alt.GetObject());
    }
  }





  class AlternativeSelector
  {
    static IList<Alternative> alternatives;
    static int selectedIndex = 0;
    static IList<string> preStrings;
    static IList<string> postStrings;

    public static Alternative Start(IList<Alternative> alts, IList<string> pre, IList<string> post)
    {
      alternatives  = alts;
      selectedIndex = 0;
      preStrings    = pre;
      postStrings   = post;
      return print();
    }

    public static Alternative Start(IList<Alternative> alts, IList<string> pre)
    {
      return Start(alts, pre, new List<string>());
    }

    private static Alternative print()
    {
      Console.Clear();
      printPreStrings();
      printAlternatives();
      printPostStrings();
      return read();
    }

    private static Alternative read()
    {
      var key = Console.ReadKey();
      switch(key.Key)
      {
        case(ConsoleKey.DownArrow):
        selectedIndex++;
        break;

        case(ConsoleKey.UpArrow):
        selectedIndex--;
        break;

        case(ConsoleKey.Enter):
        return choose();

        case(ConsoleKey.Escape):
        return null;
      }
      return evaluate();
    }

    private static Alternative evaluate()
    {
      if(selectedIndex < 0)
        selectedIndex = alternatives.Count - 1;
      else if(selectedIndex >= alternatives.Count)
        selectedIndex = 0;

      return print();
    }

    private static Alternative choose()
    {
      return alternatives[selectedIndex];
    }

    private static void printPreStrings()
    {
      foreach(string s in preStrings)
      Console.WriteLine(s);
    }

    private static void printPostStrings()
    {
      foreach(string s in postStrings)
      Console.WriteLine(s);

    }

    private static void printAlternatives()
    {
      Console.WriteLine("Arrow keys to navigate, enter to accept, esc to quit.");
      for(int i=0; i<alternatives.Count; i++)
      {
        if(i == selectedIndex)
          Console.WriteLine("(*) " + alternatives[i].GetName());
        else
          Console.WriteLine("( ) " + alternatives[i].GetName());
      }
    }
  }


  class Alternative
  {
    string title;
    object obj;

    private Alternative(string title, object obj)
    {
      this.title = title;
      this.obj   = obj;
    }

    public string GetName()
    {
      return title;
    }

    public object GetObject()
    {
      return obj;
    }

    public static IList<Alternative> CreateMany(IList<ILanguage> langs)
    {
      return langs.Select(l => new Alternative(l.GetName(), l))
        .ToList<Alternative>();
    }

    public static IList<Alternative> CreateMany(IList<LanguageStrategy> strats)
    {
      return strats.Select(s => new Alternative(s.GetTranslationType(), s))
        .ToList<Alternative>();
    }
  }
}
