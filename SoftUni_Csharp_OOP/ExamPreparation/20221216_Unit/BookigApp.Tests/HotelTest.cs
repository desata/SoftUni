using FrontDeskApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookigApp.Tests
{
    [TestFixture]
    public class HotelTest
    {
        [Test]
        [TestCase("Hotel", 1)]
        [TestCase("HotelAsdf", 2)]
        [TestCase("Hotel123", 3)]
        [TestCase("HotelssA", 4)]
        [TestCase("Hotelghjk", 5)]
        public void HotelConstructorCorrect(string fullName, int category)
        {
            Hotel hotel = new Hotel(fullName, category);
            Assert.AreEqual(fullName, hotel.FullName);
            Assert.AreEqual(category, hotel.Category);
        }

        [Test]
        public void HotelConstructorNOTCorrect()
        {
            Assert.Throws<ArgumentNullException>(() => new Hotel(null, 2));
            Assert.Throws<ArgumentNullException>(() => new Hotel("", 2));
            Assert.Throws<ArgumentNullException>(() => new Hotel(String.Empty, 2));
            Assert.Throws<ArgumentException>(() => new Hotel("Hotel", 0));
            Assert.Throws<ArgumentException>(() => new Hotel("Hotel", -2));
            Assert.Throws<ArgumentException>(() => new Hotel("Hotel", 6));
            Assert.Throws<ArgumentException>(() => new Hotel("Hotel", 10));
        }

        [Test]
        public void AddRoomShouldWorkCorrect()
        {
            Room room = new Room(3, 100);
            Hotel hotel = new Hotel("Hotelghjk", 5);

            hotel.AddRoom(room);

            Assert.AreEqual(1, hotel.Rooms.Count);
        }

        [Test]
        public void BookRoomCorrect()
        {
            Room room = new Room(5, 100);
            Hotel hotel = new Hotel("Hotelghjk", 5);
            hotel.AddRoom(room);
            hotel.BookRoom(1, 2, 5, 20000);                       
            hotel.BookRoom(2, 0, 5, 20000);

            Assert.AreEqual(2, hotel.Bookings.Count);
            Assert.AreEqual(1000, hotel.Turnover);
        }

        [Test]
        public void BookRoomInCorrect()
        {
            Room room = new Room(5, 100);
            Hotel hotel = new Hotel("Hotelghjk", 5);
            hotel.AddRoom(room);

            Assert.Throws<ArgumentException>(() => hotel.BookRoom(0, 1, 5, 20000));
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(-1, 1, 5, 20000));
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(-10, 1, 5, 20000));
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(2, -1, 5, 20000));
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(2, -11, 5, 20000));
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(2, 2, 0, 20000));
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(2, 2, -5, 20000));
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(2, 2, -15, 20000));

        }


    }
}
