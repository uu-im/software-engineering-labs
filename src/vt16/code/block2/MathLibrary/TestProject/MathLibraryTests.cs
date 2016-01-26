using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathLibrary;

namespace TestProject
{
    /// <summary>
    /// Test cases for the public methods of the MathLib class.
    /// 
    /// The test cases are named by the following convention:
    ///     "MethodName_InputValue_ExpectedOutput"
    ///     
    /// </summary>
    [TestClass]
    public class MathLibraryTests
    {
        #region IsEven
        [TestMethod]
        public void IsEven_Even_True()
        {
            // act
            bool result = MathLib.IsEven(2);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsEven_Odd_False()
        {
            // act
            bool result = MathLib.IsEven(1);

            // assert
            Assert.IsFalse(result);
        }
        #endregion


        #region Max
        [TestMethod]
        public void Max_SingleNumber_ReturnsMax()
        {
            // arrange
            int[] numbers = new int[1] { 10 };

            // act
            int result = MathLib.Max(numbers);

            // assert
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void Max_MaxFirst_ReturnsMax()
        {
            // given a list withonly one number
            // Max returns the one number
        }

        [TestMethod]
        public void Max_MaxLast_ReturnsMax()
        {
            // given a list with its max as the last element
            // Max returns the max
        }

        [TestMethod]
        public void Max_MaxMiddle_ReturnsMax()
        {
            // given a list with its max in the middle
            // Max returns the max
        }
        #endregion


        #region Average
        [TestMethod]
        public void Average_OneNumber_ReturnsAverage()
        {
            // when given a list of a single number
            // it returns the single number
        }

        [TestMethod]
        public void Average_FewNumbers_ReturnsAverage()
        {
            // when given a short list of numbers
            // it returns the correct average
        }

        [TestMethod]
        public void Average_ManyNumbers_ReturnsAverage()
        {
            // when given a long list of numbers
            // it returns the correct average
        }
        #endregion


        #region Reverse
        [TestMethod]
        public void Reverse_OneDigit_ReturnsSameDigit()
        {
            // when given a single digit number
            // it returns that digit
        }

        [TestMethod]
        public void Reverse_PositiveWithoutTrailingZero_ReturnsReverse()
        {
            // when given a positive number
            // where the last digit is not 0
            // it returns the reversed number
        }

        [TestMethod]
        public void Reverse_NegativeWithoutTrailingZero_ReturnsReverseWithoutDash()
        {
            // when given a negative number
            // where the last digit is not 0
            // it returns the reversed number
            // without the "-" (dash) sign 
        }

        [TestMethod]
        public void Reverse_WithTrailingZero_ReturnsReverseWithoutZero()
        {
            // when given a number
            // where the last digit is a 0
            // it returns the reversed number
            // without the "first" 0
        }
        #endregion


        #region Factorial
        [TestMethod]
        public void Factorial_Zero_One()
        {
            // when given a 0
            // it returns 1
        }

        [TestMethod]
        public void Factorial_One_One()
        {
            // when given a 1
            // it returns 1
        }

        [TestMethod]
        public void Factorial_SmallNumber_Factorial()
        {
            // when given a small number
            // it returns the factorial
        }

        [TestMethod]
        public void Factorial_LargeNumber_Factorial()
        {
            // when given a large number
            // it returns the factorial
        }
        #endregion


        #region IsLeapYear
        // Read more about leap years here:
        // http://en.wikipedia.org/wiki/Leap_years#Algorithm
        [TestMethod]
        public void IsLeapYear_DivisibleBy400_True()
        {
            // given year that
            // is divisible by 400
            // => leap year
        }

        [TestMethod]
        public void IsLeapYear_NotDivisibleBy4_False()
        {
            // given year that
            // is not divisible by 4
            // => not leap year
        }

        [TestMethod]
        public void IsLeapYear_DivisibleBy4ButNot100_True()
        {
            // given year that
            // is divisible by 4
            // but not divisible by 100
            // => leap year
        }

        [TestMethod]
        public void IsLeapYear_DivisbleBy4And100_False()
        {
            // given year that
            // is divisible by 4
            // and divisible by 100
            // => not leap year
        }

        [TestMethod]
        public void IsLeapYear_DivisibleBy4And100ButNot400_False()
        {
            // given year that
            // is divisible by 4
            // and divisible by 100
            // but not divisible by 400
            // => not leap year
        }
        #endregion


        #region Primes
        [TestMethod]
        public void Primes_SmallX_AllPrimesUnderX()
        {
            // given a small x
            // returns all prime numbers below x
            // including x if x is prime
        }

        [TestMethod]
        public void Primes_LargeX_AllPrimesUnderX()
        {
            // given a large x
            // returns all prime numbers below x
            // including x if x is prime
        }

        [TestMethod]
        public void Primes_One_EmptyArray()
        {
            // given one (1)
            // returns empty array
        }

        [TestMethod]
        public void Primes_Zero_EmptyArray()
        {
            // given zero (0)
            // returns empty array
        }
        #endregion


        #region IsPrime
        [TestMethod]
        public void Primes_SmallNumberNotDivisibleByAnyNumberOtherThan1AndItself_True()
        {
            // given a small number that
            // is not divisible by any number
            // but 1 and itself
            // => prime
        }

        [TestMethod]
        public void Primes_LargeNumberNotDivisibleByAnyNumberOtherThan1AndItself_True()
        {
            // given a large number that
            // is not divisible by any number
            // but 1 and itself
            // => prime
        }

        [TestMethod]
        public void Primes_NegativeNumber_False()
        {
            // given a negative number
            // => not prime
        }

        [TestMethod]
        public void Primes_Zero_False()
        {
            // given zero (0)
            // => not prime
        }
        #endregion
    }
}
