using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EgnValidator.Tests
{
    [TestFixture]
    public class EgnValidatorTests
    {
        [TestCase("0000000000")]
        [TestCase("abcdefghij")]
        [TestCase("6602301111")]
        [TestCase("2151196248")]
        [TestCase("123456789")]
        [TestCase(null)]
        public void ValidShouldReturnFalseForInvalidNumber(string egn)
        {
            var validator = new EgnValidatorProgram.EgnValidator();
            var result = validator.Validate(egn);
            Assert.False(result);
        }

        [Test]
        public void ValidateShouldReturnTrueForValidEgn()
        {
            var validator = new EgnValidatorProgram.EgnValidator();
            var result = validator.Validate("6101057509");
            Assert.True(result);
        }

        [Test]
        public void ValidateShouldReturnTrueForValidEgn2()
        {
            var validator = new EgnValidatorProgram.EgnValidator();
            var result = validator.Validate("2151196247");
            Assert.True(result);
        }
    }
}
