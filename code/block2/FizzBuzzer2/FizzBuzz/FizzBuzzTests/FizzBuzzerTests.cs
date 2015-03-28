using NUnit.Framework;
using System;
using FizzBuzz;

namespace FizzBuzzTests
{
  [TestFixture()]
  public class FizzBuzzerTests
  {
    [Test()]
    public void FirstTwo_GivesNumber()
    {
      IFizzBuzzer fb = getInstance(0);
      Assert.AreEqual("1", fb.Next());
      Assert.AreEqual("2", fb.Next());
    }

    [Test()]
    public void Third_GivesFizz()
    {
      IFizzBuzzer fb = getInstance(2);
      Assert.AreEqual("Fizz", fb.Next());
    }

    [Test()]
    public void Fourth_GivesNumber()
    {
      IFizzBuzzer fb = getInstance(3);
      Assert.AreEqual("4", fb.Next());
    }

    [Test()]
    public void Fifth_GivesNumber()
    {
      IFizzBuzzer fb = getInstance(4);
      Assert.AreEqual("Buzz", fb.Next());
    }

    [Test()]
    public void Sixth_GivesNumber()
    {
      IFizzBuzzer fb = getInstance(5);
      Assert.AreEqual("Fizz", fb.Next());
    }

    [Test()]
    public void Fifteenth_GivesFizzBuzz()
    {
      IFizzBuzzer fb = getInstance(14);
      Assert.AreEqual("FizzBuzz", fb.Next());
    }

    [Test()]
    public void AtHighNumbersDivisibleBy3_Fizz()
    {
      Assert.AreEqual("Fizz", getInstance(101).Next());
      Assert.AreEqual("Fizz", getInstance(107).Next());
      Assert.AreEqual("Fizz", getInstance(110).Next());
    }

    [Test()]
    public void AtHighNumbers_Buzz()
    {
      Assert.AreEqual("Buzz", getInstance(99).Next());
      Assert.AreEqual("Buzz", getInstance(109).Next());
    }

    [Test()]
    public void AtHighNumbersDivisibeBy3And5_FizzBuzz()
    {
      Assert.AreEqual("FizzBuzz", getInstance(104).Next());
      Assert.AreEqual("FizzBuzz", getInstance(119).Next());
    }

    [Test()]
    public void AtHighNumbersNotDivisibeBy3Nor5_Regular()
    {
      Assert.AreEqual("101", getInstance(100).Next());
      Assert.AreEqual("103", getInstance(102).Next());
      Assert.AreEqual("104", getInstance(103).Next());
      Assert.AreEqual("106", getInstance(105).Next());
    }



    private IFizzBuzzer getInstance(int n)
    {
      IFizzBuzzer fb = new FizzBuzzer();
      for(int i=0; i<n; i++)
        fb.Next();
      return fb;
    }
  }
}

