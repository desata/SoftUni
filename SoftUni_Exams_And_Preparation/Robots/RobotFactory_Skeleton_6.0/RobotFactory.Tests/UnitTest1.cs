using NUnit.Framework;

namespace RobotFactory.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SupplementNew()
        {
            
            Supplement supplement = new Supplement("Laser", 1234);
            Robot robot = new Robot("R2", 12.12, 222);
            Factory factory = new Factory("Factory", 5);



            Assert.AreEqual(1, factory.);
        }
    }
}