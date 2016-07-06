using System;
using NUnit.Framework;

namespace FizzBuzz.Test
{
    [TestFixture]
    public class FizzBuzzerTests
    {
        private IFizzBuzzer _fizzBuzzer;

        [TestFixtureSetUp]
        public void Setup()
        {
            _fizzBuzzer = new FizzBuzzer();
        }

        [Test]
        public void Implements_IFizzBuzzer()
        {
            Assert.IsInstanceOf<IFizzBuzzer>(_fizzBuzzer);
        }

        [Test]
        [TestCase(1, 100, "12fizz4buzzfizz78fizzbuzz11fizz1314fizzbuzz1617fizz19buzzfizz2223fizzbuzz26fizz2829fizzbuzz3132fizz34buzzfizz3738fizzbuzz41fizz4344fizzbuzz4647fizz49buzzfizz5253fizzbuzz56fizz5859fizzbuzz6162fizz64buzzfizz6768fizzbuzz71fizz7374fizzbuzz7677fizz79buzzfizz8283fizzbuzz86fizz8889fizzbuzz9192fizz94buzzfizz9798fizzbuzz")]
        [TestCase(5, 50, "buzzfizz78fizzbuzz11fizz1314fizzbuzz1617fizz19buzzfizz2223fizzbuzz26fizz2829fizzbuzz3132fizz34buzzfizz3738fizzbuzz41fizz4344fizzbuzz4647fizz49buzz")]
        [TestCase(17, 98, "17fizz19buzzfizz2223fizzbuzz26fizz2829fizzbuzz3132fizz34buzzfizz3738fizzbuzz41fizz4344fizzbuzz4647fizz49buzzfizz5253fizzbuzz56fizz5859fizzbuzz6162fizz64buzzfizz6768fizzbuzz71fizz7374fizzbuzz7677fizz79buzzfizz8283fizzbuzz86fizz8889fizzbuzz9192fizz94buzzfizz9798")]
        public void FizzBuzzRange_Returns_A_Correct_FizzBuzz_Result_For_A_Given_Range(int start, int end, string expectedResult)
        {
            var result = _fizzBuzzer.FizzBuzzRange(start, end);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
