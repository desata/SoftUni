namespace Robots.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography.X509Certificates;

    [TestFixture]

    public class RobotsTests
    {

        [Test]
        public void ConstructorShouldSetCapacity()
        {
            var robot = new RobotManager(4);    
            Assert.AreEqual(4, robot.Capacity);
        }
        
        [Test]
        public void ConstructorShouldThrowExNegativeCapacity()
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(-4));
           
        }

        [Test]
        public void EmpytyRobotManagerCountOfZero()
        {
            var robot = new RobotManager(4);
            Assert.AreEqual(0, robot.Count);

        }

        [Test]
        public void EmpytyRobotManagerProperCount()
        {
            var robots = new RobotManager(4);
            robots.Add(new Robot("First", 100));
            robots.Add(new Robot("Second", 100));
            robots.Add(new Robot("Third", 100));

            Assert.AreEqual(3, robots.Count);
        }

        [Test]
        public void AddShouldThrowExSameName()
        {
            var robots = new RobotManager(4);

            robots.Add(new Robot("First", 100));
            
            Assert.Throws<InvalidOperationException>(() => robots.Add(new Robot("First", 1000)));

        }


        [Test]
        public void AddShouldThrowExNotEnoughCapacity()
        {
            var robots = new RobotManager(2);

            robots.Add(new Robot("First", 100));
            robots.Add(new Robot("Second", 100));


            Assert.Throws<InvalidOperationException>(() => robots.Add(new Robot("Third", 100)));

        }

        [Test]
        public void RemoveShouldThrowsExNotExist()
        {
            var robots = new RobotManager(2);

            robots.Add(new Robot("First", 100));
            robots.Add(new Robot("Second", 100));

            Assert.Throws<InvalidOperationException>(() => robots.Remove("Third"));
        }

        [Test]
        public void RemoveShouldSucseed()
        {
            var robots = new RobotManager(42);

            robots.Add(new Robot("First", 100));
            robots.Add(new Robot("Second", 100));
            robots.Add(new Robot("Third", 100));
            robots.Remove("First");
            Assert.AreEqual(2, robots.Count);
            robots.Remove("Second");
            Assert.AreEqual(1, robots.Count);
            robots.Remove("Third");
            Assert.AreEqual(0, robots.Count);

        }

        [Test]
        public void WorkShouldSucceded()
        {
            var robots = new RobotManager(42);
            var robot = new Robot("First", 100);
            robots.Add(robot);

            robots.Work("First", "clean", 10);

            Assert.AreEqual(90, robot.Battery);
        }


        [Test]
        public void WorkShouldThrowExForName()
        {
            var robots = new RobotManager(42);
            var robot = new Robot("First", 100);
            Assert.Throws<InvalidOperationException>(() => robots.Work("Second", "clean", 10));
            
        }


        [Test]
        public void WorkShouldThrowExForLowBattery()
        {
            var robots = new RobotManager(42);
            var robot = new Robot("First", 100);
            //robots.Add(robot);

            Assert.Throws<InvalidOperationException>(() => robots.Work("First", "clean", 1000));
        }


        [Test]
        public void ChargeShouldSucceded()
        {
            var robots = new RobotManager(42);
            var robot = new Robot("First", 100);
            robots.Add(robot);
            robots.Work("First", "clean", 40);
            robots.Charge("First");

            Assert.AreEqual(100, robot.Battery);
        }


        [Test]
        public void ChargeShouldThrowExForName()
        {
            var robots = new RobotManager(42);
            var robot = new Robot("First", 10);

            Assert.Throws<InvalidOperationException>(() => robots.Charge("Second"));

        }
    }
}
