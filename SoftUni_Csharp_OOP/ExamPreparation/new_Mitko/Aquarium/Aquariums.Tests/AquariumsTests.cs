namespace Aquariums.Tests
{
    using Newtonsoft.Json.Linq;
    using NUnit.Framework;
    using System;
    using System.Xml.Linq;

    [TestFixture]

    public class AquariumsTests
    {
        [Test]
        [TestCase("TestName", 0)]
        [TestCase("TestName1", 1)]
        [TestCase("TestName2", 10)]
        [TestCase("TestName3", 1005)]

        public void ConstructorNameCorrect(string name, int capacity)
        {
            Aquarium aquaruim = new Aquarium(name, capacity);

            Assert.AreEqual(name, aquaruim.Name);
            Assert.AreEqual(capacity, aquaruim.Capacity);

        }

        [Test]
        [TestCase("Riba")]
        [TestCase(null)]
        [TestCase("Riba2")]
        [TestCase("Riba3")]

        public void ConstructorFishNameCorrect(string name)
        {
            Fish fish = new Fish(name);

            Assert.AreEqual(name, fish.Name);

        }

        [Test]
        [TestCase("Riba")]
        [TestCase(null)]
        [TestCase("Riba2")]
        [TestCase("Riba3")]
        public void ConstructorFishIsAvailableCorrect(string name)
        {
            Fish fish = new Fish(name);


            Assert.IsTrue(fish.Available);

        }


        [Test]

        [TestCase(null)]
        [TestCase("")]
        public void ConstructorNameNull(string name)
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(name, 5), "Invalid aquarium name!");
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-1100)]
        [TestCase(int.MinValue)]
        public void ConstructorCapacityZeroLessThrowsEx(int capacity)
        {            
            Assert.Throws<ArgumentException>(() => new Aquarium("Test", int.MinValue), "Invalid aquarium capacity!");
        }

        [Test]

        public void CorrectFishCount()
        {
            Aquarium aquaruim = new Aquarium("A", 5);
            Fish fish1 = new Fish("Nemo");
            Fish fish2 = new Fish("Dory");

            aquaruim.Add(fish1);
            aquaruim.Add(fish2);

            Assert.AreEqual(2, aquaruim.Count);

        }

        [Test]
        public void CorrectFishCountZero()
        {
            Aquarium aquaruim = new Aquarium("A", 5);

            Assert.AreEqual(0, aquaruim.Count);
        }

        [Test]
        public void FishAddFIsh()
        {

            Aquarium aquaruim = new Aquarium("A", 5);
            Fish fish1 = new Fish("A1");
            Fish fish2 = new Fish("A2");
            Fish fish3 = new Fish("A3");
            Fish fish4 = new Fish("A4");
            Fish fish5 = new Fish("A5");

            aquaruim.Add(fish1);
            aquaruim.Add(fish2);
            aquaruim.Add(fish3);
            aquaruim.Add(fish4);
            aquaruim.Add(fish5);

            Assert.AreEqual(5, aquaruim.Count);
        }

            [Test]
        public void FishAddFIshFullThrowsEx()
        {
 
            Aquarium aquaruim = new Aquarium("A", 5);
            Fish fish1 = new Fish("A1");
            Fish fish2 = new Fish("A2");
            Fish fish3 = new Fish("A3");
            Fish fish4 = new Fish("A4");
            Fish fish5 = new Fish("A5");
            Fish fish6 = new Fish("A6");

            aquaruim.Add(fish1);
            aquaruim.Add(fish2);
            aquaruim.Add(fish3);
            aquaruim.Add(fish4);
            aquaruim.Add(fish5);

            Assert.Throws<InvalidOperationException>(() => aquaruim.Add(fish4), "Aquarium is full!");

        }

        [Test]

        public void RemoveFishCorrect()
        {
            Aquarium aquaruim = new Aquarium("A", 5);
            Fish fish1 = new Fish("A1");
            Fish fish2 = new Fish("A2");
            Fish fish3 = new Fish("A3");

            aquaruim.Add(fish1);
            aquaruim.Add(fish2);
            aquaruim.Add(fish3);


            aquaruim.RemoveFish("A1");
            Assert.AreEqual(2, aquaruim.Count);
            aquaruim.RemoveFish("A2");
            Assert.AreEqual(1, aquaruim.Count);
            aquaruim.RemoveFish("A3");
            Assert.AreEqual(0, aquaruim.Count);

        }

        [Test]

        public void RemoveFishIncorrect()
        {
            Aquarium aquaruim = new Aquarium("A", 5);
            Fish fish1 = new Fish("A1");
            Fish fish2 = new Fish("A2");
            Fish fish3 = new Fish("A3");

            aquaruim.Add(fish1);
            aquaruim.Add(fish2);
            aquaruim.Add(fish3);

            Assert.Throws<InvalidOperationException>(() => aquaruim.RemoveFish("A5"), "Fish with the name A5 doesn't exist!");
        }

        [Test]

        public void RemoveFishIncorrect1()
        {
            Aquarium aquaruim = new Aquarium("A", 5);

            Assert.Throws<InvalidOperationException>(() => aquaruim.RemoveFish("A5"), "Fish with the name A5 doesn't exist!");
        }

        [Test]

        public void SellFishCorrect() 
        {
            Aquarium aquaruim = new Aquarium("A", 5);
            Fish fish1 = new Fish("A1");
            Fish fish2 = new Fish("A2");
            Fish fish3 = new Fish("A3");

            aquaruim.Add(fish1);
            aquaruim.Add(fish2);
            aquaruim.Add(fish3);

            aquaruim.SellFish("A1");
            Assert.IsFalse(fish1.Available);
        }


        [Test]

        public void SellFishIncorrect() 
        {
            Aquarium aquaruim = new Aquarium("A", 5);
            Fish fish1 = new Fish("A1");
            Fish fish2 = new Fish("A2");
            Fish fish3 = new Fish("A3");

            aquaruim.Add(fish1);
            aquaruim.Add(fish2);
            aquaruim.Add(fish3);

            Assert.Throws<InvalidOperationException>(() => aquaruim.SellFish("A5"), "Fish with the name A5 doesn't exist!");
        }

        [Test]
        public void ReportCorrect()
        {
            Aquarium aquaruim = new Aquarium("A", 5);
            Fish fish1 = new Fish("A1");
            Fish fish2 = new Fish("A2");
            Fish fish3 = new Fish("A3");

            aquaruim.Add(fish1);
            aquaruim.Add(fish2);
            aquaruim.Add(fish3);

            string testReport = aquaruim.Report();
            string expectedReport = $"Fish available at {aquaruim.Name}: A1, A2, A3";
            Assert.AreEqual(expectedReport, testReport);

        }

        [Test]
        public void ReportCorrectOneName()
        {
            Aquarium aquaruim = new Aquarium("A", 5);
            Fish fish1 = new Fish("A1");
            Fish fish2 = new Fish("A2");
            Fish fish3 = new Fish("A3");

            aquaruim.Add(fish1);

            string testReport = aquaruim.Report();
            string expectedReport = $"Fish available at {aquaruim.Name}: A1";
            Assert.AreEqual(expectedReport, testReport);
        }

        [Test]
        public void ReportCorrectNoName()
        {
            Aquarium aquaruim = new Aquarium("A", 5);


            string testReport = aquaruim.Report();
            string expectedReport = $"Fish available at A: ";
            Assert.AreEqual(expectedReport, testReport);
        }
    }
}
