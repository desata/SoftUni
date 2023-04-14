using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    [TestFixture]
    public class BankVaultTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var vaultCells = new BankVault();

            var item = new Item("owner", "1");
            vaultCells.AddItem("a1", item);

            Assert.AreEqual(1, vaultCells.Count());
        }
    }
}