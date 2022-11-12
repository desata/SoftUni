using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Shapes
{
    public abstract class Shape
    {
        public abstract double CalculatePerimeter();


        public abstract double CalculateArea();

        public abstract void Draw();
    }
}
