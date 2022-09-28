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
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get
            {
                return this.length;
            }
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
            get
            {
                return this.width;
            }
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
            get
            {
                return this.height;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Height cannot be zero or negative.");
                }
                this.height = value;
            }
        }


        public double SurfaceArea()
        {
            return 2 * length * width + 2 * length * height + 2 * width * height;

        }
        //Calculate and return the surface area of the Box.

        public double LateralSurfaceArea()
        {
            return 2 * length * height + 2 * width * height;
        }
        //Calculate and return the lateral surface area of the Box.

        public double Volume()
        {
            return length * width * height;
        }
        //Calculate and return the volume of the Box.



    }
}
