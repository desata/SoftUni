using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _08.CarSalesman
{
    public class Car
    {
        public Car(string model, string engine,string enginePower, 
            string dispacement, string efficiency
            ,string weight, string color)
        {
            Model = model;
            Engine = engine;
            EnginePower = enginePower;
            Displacement = dispacement;
            Efficiency = efficiency;
            Weight = weight;
            Color = color;
        }

        public string Model { get; set; }
        public string Weight { get; set; }
        public string Color { get; set; }

        public string Engine { get; set; }
        public string EnginePower { get; set; }
        public string Displacement { get; set; }
        public string Efficiency { get; set; }
    }
}
