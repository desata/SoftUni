using FrontDeskApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookigApp.Tests
{
    [TestFixture]
    public class RoomTest
    {
        [Test]
        [TestCase(1, 200)]
        [TestCase(10, 20)]
        [TestCase(10, 20.34)]
        [TestCase(10, 2000.54)]
        public void RoomConstructorCorrect(int bedCapacity, double pricePerNight)
        {
            Room room = new Room(bedCapacity, pricePerNight);
            Assert.AreEqual(room.BedCapacity, bedCapacity);
            Assert.AreEqual(room.PricePerNight, pricePerNight);
        }

        [Test]
        public void RoomConstructorNOTCorrectBedThrowsEx()
        {

            Assert.Throws<ArgumentException>(() => new Room(0, 23));
            Assert.Throws<ArgumentException>(() => new Room(-1, 23));
            Assert.Throws<ArgumentException>(() => new Room(int.MinValue, 23));
            Assert.Throws<ArgumentException>(() => new Room(5, 0));
            Assert.Throws<ArgumentException>(() => new Room(5, -23));
            Assert.Throws<ArgumentException>(() => new Room(5, double.MinValue));

        }
    }
}
