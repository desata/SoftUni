using EgnValidatorProgram;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EgnValidator.Tests
{
    [TestFixture]
    public class SummatorTests
    {
        [Test]
        public void SumOfDigitsShouldWorkCorrectlyForADigit()
        {
            // Arange
            var summator = new Summator();

            // Act
            var result = summator.SumOfDigits(8);

            // Assert
            Assert.AreEqual(8, result);
        }

        [Test]
        public void SumOfDigitsShouldWorkCorrectlyWithMillions()
        {
            var summator = new Summator();
            var result = summator.SumOfDigits(1111111);
            Assert.AreEqual(7, result);
        }

        [Test]
        public void SumOfDigitsShouldWorkCorrectlyWithLongNumber()
        {
            var summator = new Summator();
            var result = summator.SumOfDigits(9876543210);
            Assert.AreEqual(45, result);
        }

        [Test]
        public void SumOfDigitsShouldWorkCorrectlyWithZero()
        {
            var summator = new Summator();
            var result = summator.SumOfDigits(0);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void SumOfDigitsShouldWorkCorrectlyWithNegativeNumber()
        {
            var summator = new Summator();
            var result = summator.SumOfDigits(-123);
            Assert.AreEqual(6, result);
        }
    }
}
