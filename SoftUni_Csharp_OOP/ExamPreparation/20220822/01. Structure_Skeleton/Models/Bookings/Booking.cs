using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Bookings
{
    public class Booking : IBooking
    {
        private int residenceDuration;
        private int adultsCount;
        private int childrenCount;
        private int bookingNumber;

        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
        {
            this.Room = room;
            this.ResidenceDuration = residenceDuration;
            this.AdultsCount = adultsCount;
            this.ChildrenCount = childrenCount;
            this.bookingNumber = bookingNumber;

        }

        public IRoom Room { get; private set; }

        public int ResidenceDuration
        {
            get => this.residenceDuration;

            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.DurationZeroOrLess);
                }
                this.residenceDuration = value;
            }
        }

        public int AdultsCount
        {
            get => this.adultsCount;

            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.AdultsZeroOrLess);
                }
                this.adultsCount = value;
            }
        }
        public int ChildrenCount
        {
            get => this.childrenCount;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.ChildrenNegative);
                }
                this.childrenCount = value;
            }
        }

        public int BookingNumber => this.bookingNumber;

        public string BookingSummary()
        {
            StringBuilder sb = new StringBuilder();


            sb.AppendLine($"Booking number: {BookingNumber}");
            sb.AppendLine($"Room type: {Room.GetType().Name}");
            sb.AppendLine($"Adults: {AdultsCount} Children: {ChildrenCount}");
            sb.Append($"Total amount paid: {TotalPaid():F2} $");

            return sb.ToString();
        }

        private double TotalPaid() => Math.Round(this.ResidenceDuration * this.Room.PricePerNight, 2);
    }
}
