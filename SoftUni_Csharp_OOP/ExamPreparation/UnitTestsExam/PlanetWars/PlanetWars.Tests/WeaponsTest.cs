using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class WeaponsTests
    {
        [TestFixture]
        public class Tests
        {
            [Test]
            [TestCase("AK-47")]
            public void ConstructorNameWeapon(string name)
            {
                Weapon weapon = new Weapon(name, 20.99, 3);
                Assert.AreEqual(name, weapon.Name);
            }

            [Test]
            [TestCase(50)]
            [TestCase(20.99)]
            [TestCase(double.MaxValue)]
            [TestCase(0)]
            public void ConstructorSetValidPrice(double price)
            {
                Weapon weapon = new Weapon("AK-47", price, 3);
                Assert.AreEqual(price, weapon.Price);
            }

            [Test]
            [TestCase(-1)]
            [TestCase(-20.99)]
            [TestCase(double.MinValue)]
            [TestCase(-1000)]
            public void ConstructorSetInvalidPrice(double price)
            {
                
                Assert.Throws<ArgumentException>(() => new Weapon("AK-47", price, 3));
            }


            [Test]
            [TestCase(0)]
            [TestCase(5)]
            [TestCase(9)]
            public void ConstructorDestrLvlWeapon(int destructionLvl)
            {
                Weapon weapon = new Weapon("AK-47", 20.99, destructionLvl);
                Assert.AreEqual(destructionLvl, weapon.DestructionLevel);
                Assert.IsFalse(weapon.IsNuclear);
            }


            [Test]
            [TestCase(20)]
            [TestCase(10)]
            [TestCase(1000)]
            public void ConstructorDestrLvlWeaponNuclear(int destructionLvl)
            {
                Weapon weapon = new Weapon("AK-47", 20.99, destructionLvl);
                Assert.AreEqual(destructionLvl, weapon.DestructionLevel);
                Assert.IsTrue(weapon.IsNuclear);
            }
        }
    }
}
