namespace Robots.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class RobotsTests
    {
        [Test]
        public void ConstructorWorkProperly()
        {
            var robot = new RobotManager(4);
            Assert.AreEqual(4, robot.Capacity);
        }

        [Test]
        public void ConstructorThrowExMessageBelowZero()
        {

            Assert.Throws<ArgumentException>(() => new RobotManager(-9));
        }

        [Test]
        public void CountWorksProperlyZero()
        {
            var robots = new RobotManager(4);
            Assert.AreEqual(0, robots.Count);

        }

        [Test]
        public void CountWorksProperly()
        {
            var robot = new Robot("r1", 200);
            var robot2 = new Robot("r2", 200);
            var robots = new RobotManager(4);

            robots.Add(robot);
            robots.Add(robot2);

            Assert.AreEqual(2, robots.Count);

        }

        [Test]
        public void AddThrowsEXMForRobotSameName()
        {
            var robot = new Robot("r1", 200);
            var robot2 = new Robot("r1", 100);
            var robots = new RobotManager(4);

            robots.Add(robot);
            Assert.Throws<InvalidOperationException>(() => robots.Add(robot2));

        }

        [Test]
        public void AddThrowsExMForCapacity()
        {
            var robots = new RobotManager(2);

            robots.Add(new Robot("r1", 100));
            robots.Add(new Robot("r2", 400));

            Assert.Throws<InvalidOperationException>(() => robots.Add(new Robot("r5", 800)));
        }

        [Test]
        public void RemoveWorks()
        {
            var robots = new RobotManager(2);
            robots.Add(new Robot("r1", 100));
            robots.Add(new Robot("r2", 400));

            robots.Remove("r2");
            Assert.AreEqual(1, robots.Count); 
            robots.Remove("r1");
            Assert.AreEqual(0, robots.Count);
        }

        [Test]
        public void RemoveThrowsExMWrongName()
        {
            var robots = new RobotManager(2);
            robots.Add(new Robot("r1", 100));
            robots.Add(new Robot("r2", 400));

            Assert.Throws<InvalidOperationException>(() => robots.Remove("r4"));
     
        }

        [Test]
        public void WorkWorksProperly()
        {
            var robots = new RobotManager(2);
            var robot = new Robot("r1", 100);
            robots.Add(robot);

            robots.Work("r1", "f", 30);
            Assert.AreEqual(70, robot.Battery);
        }

        [Test]
        public void WorkThrowsExMForSameName()
        {
            var robots = new RobotManager(2);
            var robot = new Robot("r1", 100);
            robots.Add(robot);

            Assert.Throws<InvalidOperationException>(() => robots.Work("r5", "f", 30));
        }

        [Test]
        public void WorkThrowsExMForNotEnoughBattery()
        {
            var robots = new RobotManager(2);
            var robot = new Robot("r1", 10);
            robots.Add(robot);

            Assert.Throws<InvalidOperationException>(() => robots.Work("r1", "f", 30));
        }

        [Test]
        public void ChargeWorksProperly()
        {
            var robots = new RobotManager(2);
            var robot = new Robot("r1", 100);
            robots.Add(robot);

            robots.Work("r1", "jjj", 45);
            robots.Charge("r1");
            Assert.AreEqual(100, robot.Battery);
        }

        [Test]
        public void ChargeThrowsExMForName()
        {
            var robots = new RobotManager(2);
            var robot = new Robot("r1", 100);
            robots.Add(robot);

            Assert.Throws<InvalidOperationException>(() => robots.Charge("r9"));
        }

    }
}
