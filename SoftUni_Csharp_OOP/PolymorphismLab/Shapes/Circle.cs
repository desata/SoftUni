using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius { get; private set; }

        public override double CalculateArea()
        {
            return Math.PI*Radius*Radius;
        }

        public override double CalculatePerimeter()
        {
            return Math.PI* Radius * 2;
        }

        public override string Draw()
        {
            return "drowing circle";
        }
    }
}
