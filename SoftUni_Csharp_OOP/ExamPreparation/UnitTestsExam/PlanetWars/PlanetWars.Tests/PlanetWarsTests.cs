using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]
            [TestCase("Earth")]
            [TestCase("A-47")]
            [TestCase("A")]
            [TestCase("Mars")]
            public void ConstructorShouldSetPlanetNameCorrect(string name)
            {
                Planet planet = new Planet(name, 12.23);
                Assert.AreEqual(name, planet.Name);
            }

            [Test]
            [TestCase(null)]
            [TestCase("")]
            public void ConstructorShouldThrowExPlanetNameNotcorrect(string name)
            {

                Assert.Throws<ArgumentException>(() => new Planet(name, 12.23));
            }

            [Test]
            [TestCase("Earth", 0)]
            [TestCase("A-47", 10.88)]
            [TestCase("A-47", 1.6)]
            [TestCase("A-47", 1)]
            [TestCase("A", double.MaxValue)]
            [TestCase("Mars", 5000)]
            public void ConstructorShouldSetPlanetNameCorrect(string name, double budget)
            {
                Planet planet = new Planet(name, budget);
                Assert.AreEqual(name, planet.Name);
                Assert.AreEqual(budget, planet.Budget);
            }

            [Test]
            [TestCase(-1)]
            [TestCase(double.MinValue)]
            [TestCase(-5000)]
            public void ConstructorShouldThrowExPlanetBudgetBelowZero(double budget)
            {
                Assert.Throws<ArgumentException>(() => new Planet("ASDF", budget));
            }


            [Test]
            public void AddWeaponCorrect()
            {
                Weapon weapon1 = new Weapon("AK-47", 12345.67, 51);
                Weapon weapon2 = new Weapon("AK-37", 123456.67, 2);
                Weapon weapon3 = new Weapon("AK-27", 1234.67, 200);


                Planet planet = new Planet("A", 3456789);
                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);
                planet.AddWeapon(weapon3);

                Assert.AreEqual(3, planet.Weapons.Count);

            }

            [Test]
            public void AddWeaponInCorrect()
            {
                Planet planet = new Planet("A", 3456789);

                Weapon weapon1 = new Weapon("AK-47", 12345.67, 51);
                Weapon weapon2 = new Weapon("AK-37", 123456.67, 2);
                Weapon weapon3 = new Weapon("AK-47", 1234.67, 200);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                Assert.Throws<InvalidOperationException>(() => planet.AddWeapon(weapon3));
                Assert.Throws<InvalidOperationException>(() => planet.AddWeapon(weapon1));

            }

            [Test]
            [TestCase(1)]
            [TestCase(123.45)]
            [TestCase(12345)]
            [TestCase(12345.66)]
            public void SpendFundsCorrect(double amount)
            {
                Planet planet = new Planet("A", 12345.67);

                planet.SpendFunds(amount);
                double budget = 12345.67 - amount;

                Assert.IsTrue(amount < 12345.67);
                Assert.AreEqual(budget, planet.Budget);
            }

            [Test]
            [TestCase(1000000000)]
            [TestCase(double.MaxValue)]
            [TestCase(2312345)]
            [TestCase(112345.66)]
            public void SpendFundsINCorrect(double amount)
            {
                Planet planet = new Planet("A", 12345.67);

                Assert.Throws<InvalidOperationException>(() => planet.SpendFunds(amount));
            }


            [Test]
            [TestCase(1000000000)]
            public void ProfitCheck(double amount)
            {
                Planet planet = new Planet("A", 12345.67);

                planet.Profit(amount);

                double exspectedSum = 1000000000 + 12345.67;
                double actSum = amount + 12345.67;

                Assert.AreEqual(exspectedSum, actSum);

            }

            [Test]
            public void RemoveWeaponCorrect()
            {
                Weapon weapon1 = new Weapon("AK-47", 12345.67, 51);
                Weapon weapon2 = new Weapon("AK-37", 123456.67, 2);
                Weapon weapon3 = new Weapon("AK-27", 1234.67, 200);

                Planet planet = new Planet("A", 3456789);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);
                planet.AddWeapon(weapon3);

                planet.RemoveWeapon("AK-47");

                Assert.AreEqual(2, planet.Weapons.Count);
            }

            [Test]
            public void UpgradeWeaponCorrect()
            {
                Weapon weapon1 = new Weapon("AK-47", 12345.67, 51);
                Weapon weapon2 = new Weapon("AK-37", 123456.67, 2);
                Weapon weapon3 = new Weapon("AK-27", 1234.67, 200);

                Planet planet = new Planet("A", 3456789);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);
                planet.AddWeapon(weapon3);

                planet.UpgradeWeapon("AK-47");
                Assert.AreEqual(52, weapon1.DestructionLevel);
            }

            [Test]
            public void UpgradeWeaponInCorrect()
            {
                Weapon weapon1 = new Weapon("AK-47", 12345.67, 51);
                Weapon weapon2 = new Weapon("AK-37", 123456.67, 2);
                Weapon weapon3 = new Weapon("AK-27", 1234.67, 200);

                Planet planet = new Planet("A", 3456789);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);
                planet.AddWeapon(weapon3);


                Assert.Throws<InvalidOperationException>(() => planet.UpgradeWeapon("A-47"));
                Assert.Throws<InvalidOperationException>(() => planet.UpgradeWeapon(null));
            }

            [Test]
            public void DesrtuctOpponentCorrect()
            {
                Planet planetA = new Planet("A", 3456789);

                Weapon weaponA1 = new Weapon("AK-47", 12345.67, 51);
                Weapon weaponA2 = new Weapon("AK-37", 123456.67, 2);
                Weapon weaponA3 = new Weapon("AK-27", 1234.67, 200);

                planetA.AddWeapon(weaponA1);
                planetA.AddWeapon(weaponA2);
                planetA.AddWeapon(weaponA3);

                Planet planetB = new Planet("B", 3456788);

                Weapon weaponB1 = new Weapon("AK-47", 12345.67, 1);
                Weapon weaponB2 = new Weapon("AK-37", 123456.67, 2);
                Weapon weaponB3 = new Weapon("AK-27", 1234.67, 20);

                planetB.AddWeapon(weaponB1);
                planetB.AddWeapon(weaponB2);
                planetB.AddWeapon(weaponB3);

                planetA.DestructOpponent(planetB);

                string exp = $"B is destructed!"; 
                string act = $"{planetB.Name} is destructed!";

                Assert.AreEqual(exp, act);
            }

            [Test]
            public void DesrtuctOpponentIncorrect()
            {
                Planet planetA = new Planet("A", 3456789);

                Weapon weaponA1 = new Weapon("AK-47", 12345.67, 51);
                Weapon weaponA2 = new Weapon("AK-37", 123456.67, 2);
                Weapon weaponA3 = new Weapon("AK-27", 1234.67, 200);

                planetA.AddWeapon(weaponA1);
                planetA.AddWeapon(weaponA2);
                planetA.AddWeapon(weaponA3);

                Planet planetB = new Planet("B", 3456788);

                Weapon weaponB1 = new Weapon("AK-47", 12345.67, 1001);
                Weapon weaponB2 = new Weapon("AK-37", 123456.67, 2);
                Weapon weaponB3 = new Weapon("AK-27", 1234.67, 20);

                planetB.AddWeapon(weaponB1);
                planetB.AddWeapon(weaponB2);
                planetB.AddWeapon(weaponB3);
                              

                Assert.Throws<InvalidOperationException>(() => planetA.DestructOpponent(planetB));
            }
            [Test]
            public void DesrtuctOpponentIncorrectEqual()
            {
                Planet planetA = new Planet("A", 3456789);

                Weapon weaponA1 = new Weapon("AK-47", 12345.67, 51);
                Weapon weaponA2 = new Weapon("AK-37", 123456.67, 2);
                Weapon weaponA3 = new Weapon("AK-27", 1234.67, 200);

                planetA.AddWeapon(weaponA1);
                planetA.AddWeapon(weaponA2);
                planetA.AddWeapon(weaponA3);

                Planet planetB = new Planet("B", 3456788);

                Weapon weaponB1 = new Weapon("AK-47", 12345.67, 51);
                Weapon weaponB2 = new Weapon("AK-37", 123456.67, 2);
                Weapon weaponB3 = new Weapon("AK-27", 1234.67, 200);

                planetB.AddWeapon(weaponB1);
                planetB.AddWeapon(weaponB2);
                planetB.AddWeapon(weaponB3);


                Assert.Throws<InvalidOperationException>(() => planetA.DestructOpponent(planetB));
            }
        }
    }
}
