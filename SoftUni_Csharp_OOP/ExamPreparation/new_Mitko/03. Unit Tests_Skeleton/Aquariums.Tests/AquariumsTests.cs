namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class AquariumsTests
    {
        [Test]
        [TestCase("Rif",5)]
        [TestCase("Rif6",50)]
        [TestCase("Rif76",int.MaxValue)]
        public void ConstructorShouldWorksProperly(string name, int capacity)
        {
            Aquarium aquarium = new Aquarium(name, capacity);

            Assert.AreEqual(name, aquarium.Name);
            Assert.AreEqual(capacity, aquarium.Capacity);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void ConstructorShouldThrowExForName(string name)
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(name,5));
        }

        [Test]
        public void ConstructorShouldThrowExForNameEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(String.Empty, 5));
        }

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(-1)]
        [TestCase(-999)]
        public void ConstructorShouldThrowExForCapacity(int capacity)
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("Dory", capacity));
        }


        [Test]
        public void CountShouldWorkProperly()
        {
            Aquarium aquarium = new Aquarium("Riffle", 50);
            Fish fish1 = new Fish("Nemo");

            aquarium.Add(fish1);

            Assert.AreEqual(1, aquarium.Count);
        }


        [Test]
        public void AddShouldThrowExFirLimit()
        {
            Aquarium aquarium = new Aquarium("Riffle", 2);
            Fish fish1 = new Fish("Nemo");
            Fish fish2 = new Fish("Dory");
            Fish fish3 = new Fish("Marlin");

            aquarium.Add(fish1);
            aquarium.Add(fish2);
            

            Assert.Throws<InvalidOperationException>(() => aquarium.Add(fish2));
        }

        [Test]
        public void RemoveShouldWorkProperly()
        {
            Aquarium aquarium = new Aquarium("Riffle", 50);
            Fish fish1 = new Fish("Nemo");
            Fish fish2 = new Fish("Dory");
            Fish fish3 = new Fish("Marlin");

            aquarium.Add(fish1);
            aquarium.Add(fish2);
            aquarium.Add(fish3);

            aquarium.RemoveFish("Nemo");

            Assert.AreEqual(2, aquarium.Count);
        }

        [Test]
        public void RemoveShouldThrowEx()
        {
            string name = "prazno";

            Aquarium aquarium = new Aquarium("Riffle", 50);
            Fish fish1 = new Fish("Nemo");
            Fish fish2 = new Fish("Dory");
            Fish fish3 = new Fish("Marlin");

            aquarium.Add(fish1);
            aquarium.Add(fish2);
            aquarium.Add(fish3);

            
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish(null));
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Riba"));
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish(name));

        }


        [Test]
        public void SellFishCorresct()
        {
            Aquarium aquarium = new Aquarium("Riffle", 50);
            Fish fish1 = new Fish("Nemo");
            Fish fish2 = new Fish("Dory");
            Fish fish3 = new Fish("Marlin");

            aquarium.Add(fish1);
            aquarium.Add(fish2);
            aquarium.Add(fish3);

            aquarium.SellFish("Nemo");
            Assert.IsFalse(fish1.Available);
        }


        [Test]
        public void SellFishShouldThrowExZero()
        {
            string name = "Non";
            Aquarium aquarium = new Aquarium("Riffle", 50);
            Fish fish1 = new Fish("Nemo");
            Fish fish2 = new Fish("Dory");
            Fish fish3 = new Fish("Marlin");

            aquarium.Add(fish1);
            aquarium.Add(fish2);
            aquarium.Add(fish3);


            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish(null));
            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("Riba"));
            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish(name));

        }

        [Test]
        public void ReportShouldWorkCorrect()
        {
            Aquarium aquarium = new Aquarium("Riffle", 50);
            Fish fish1 = new Fish("Nemo");
            Fish fish2 = new Fish("Dory");
            Fish fish3 = new Fish("Marlin");

            aquarium.Add(fish1);
            aquarium.Add(fish2);
            aquarium.Add(fish3);

            string testReport = aquarium.Report();
            string expectedReport = $"Fish available at {aquarium.Name}: Nemo, Dory, Marlin";

            Assert.AreEqual(expectedReport, testReport);

        }

        [Test]
        public void ReportShouldWorkCorrectWithOne()
        {
            Aquarium aquarium = new Aquarium("Riffle", 50);
            Fish fish1 = new Fish("Nemo");

            aquarium.Add(fish1);

            string testReport = aquarium.Report();
            string expectedReport = $"Fish available at {aquarium.Name}: Nemo";

            Assert.AreEqual(expectedReport, testReport);
        }

        [Test]
        public void ReportShouldWorkCorrectWithZero()
        {
            Aquarium aquarium = new Aquarium("Riffle", 50);
           
            string testReport = aquarium.Report();
            string expectedReport = $"Fish available at {aquarium.Name}: ";

            Assert.AreEqual(expectedReport, testReport);
        }
    }
}
