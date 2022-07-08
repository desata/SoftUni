using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBox
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get { return this.length; }
            private set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Length cannot be zero or negative.");
                }
                this.length = value; 
            }
        }

        public double Width
        {
            get { return this.width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Width cannot be zero or negative.");
                }
                this.width = value;
            }
        }

        public double Height
        {
            get { return this.height; }
            private set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Height cannot be zero or negative.");
                }
                this.height = value; 
            }
        }

        //Behavior

        public double SurfaceArea()
        {
            //Calculate and return the surface area of the Box.
            double surfaceArea = 2 * (this.length * this.width) + 2 * (this.width * this.height) + 2 * (this.height * this.length); ;
            return surfaceArea;
                
        }
        public double LateralSurfaceArea()
        {
            //Calculate and return the lateral surface area of the Box.
            double lateralSurfaceArea = 2 * (this.width * this.height) + 2 * (this.height * this.length);
            return lateralSurfaceArea;
        }
        public double Volume()
        {
            double volume = this.length * this.width * this.height;
            return volume;
            //Calculate and return the volume of the Box.
        }

    }
}
