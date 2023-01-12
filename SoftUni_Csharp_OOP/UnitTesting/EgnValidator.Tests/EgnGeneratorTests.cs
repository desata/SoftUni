using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EgnValidator.Tests
{
    [TestFixture]
    public class EgnGeneratorTests
    {
        [SetUp]
        public void SomeMethod()
        {
            Console.WriteLine("Before!!!");
        }

        [TearDown]
        public void AfterAll()
        {
            Console.WriteLine("After!!!");
        }

        [Test]
        public void GenerateShouldReturnListOfNumbersForValidInput()
        {
            var generator = new EgnValidatorProgram.EgnValidator();
            var result = generator.Generate(DateTime.Now, "София - град", EgnValidatorProgram.Gender.Female);
            Assert.NotNull(result);
            Assert.AreEqual(49, result.Length);
        }

        // Regression test
        [Test]
        public void GenerateShouldReturnListOfNumbersForValidInputForVarna()
        {
            var generator = new EgnValidatorProgram.EgnValidator();
            var result = generator.Generate(new DateTime(2001, 1, 1), "Варна", EgnValidatorProgram.Gender.Female);
            Assert.NotNull(result, "Result is null.");
            Assert.AreEqual(23, result.Length);
            // For collections: Assert.That(coll1, Is.EquivalentTo(coll2))
        }

        [Test]
        public void GenerateShouldThrowAnExceptionWhenInvalidYearProvided()
        {
            var generator = new EgnValidatorProgram.EgnValidator();
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                generator.Generate(
                    new DateTime(1760, 1, 1),
                    "Варна",
                    EgnValidatorProgram.Gender.Female));
        }

        [Test]
        public void GenerateShouldGenerateValidNumbers()
        {
            var generator = new EgnValidatorProgram.EgnValidator();
            var numbers = generator.Generate(DateTime.Now, "Пловдив", EgnValidatorProgram.Gender.Male);
            foreach (var number in numbers)
            {
                Assert.AreEqual(10, number.Length);
                Assert.True(generator.Validate(number));
            }
        }
    }
}
