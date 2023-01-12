using NUnit.Framework;
using System;
using System.Net.Sockets;

namespace Aquariums.Tests
{
    [TestFixture]
    public class FishTests
    {

        [Test]
        [TestCase("Nemo")]
        [TestCase("Dory")]
        [TestCase("Ribka")]
        public void ConstructorSetNameCorrect(string name)
        {
            Fish fish = new Fish(name);

            Assert.AreEqual(name, fish.Name);    
        }

        [Test]

        public void ConstructorSetAvailabilityCorrect()
        {
            Fish fish = new Fish("Dory");

            Assert.AreEqual("Dory", fish.Name);
            Assert.IsTrue(fish.Available);
        }

    }

}
