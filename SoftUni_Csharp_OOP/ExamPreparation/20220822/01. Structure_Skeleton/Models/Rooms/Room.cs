﻿using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Rooms
{
    public abstract class Room : IRoom
    {
        private double pricePerNight = 0;
        private int bedCapacity;

        protected Room(int bedCapacity)
        {

            this.bedCapacity = bedCapacity;
        }

        public int BedCapacity => this.bedCapacity;

        

        public double PricePerNight
        {
            get => this.pricePerNight; 
            

            private set 
            {
                if (value < 0)
                { 
                throw new ArgumentException(ExceptionMessages.PricePerNightNegative);
                }

                this.pricePerNight = value;
            }
        }


        public void SetPrice(double price)
        {
            this.PricePerNight = price;
        }
    }
}
