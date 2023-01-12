using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {
        
        [Test]
        public void BookingConstructorCorrect()
        {
            Room room = new Room(5, 100);
            Booking booking = new Booking(5, room, 10);

            Assert.AreEqual(5, booking.BookingNumber);
            Assert.AreEqual(10, booking.ResidenceDuration);
            Assert.AreEqual(5, booking.Room.BedCapacity);
        }

   
    }
}