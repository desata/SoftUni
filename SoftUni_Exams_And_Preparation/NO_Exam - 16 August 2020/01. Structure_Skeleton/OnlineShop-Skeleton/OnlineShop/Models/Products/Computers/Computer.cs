using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components;
        private List<IPeripheral> peripherals;
        private double overallPerformance;
        private decimal price;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
            this.OverallPerformance = overallPerformance;
            this.Price = price;
        }

        public IReadOnlyCollection<IComponent> Components => this.components;

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals;

        public new double OverallPerformance
        {
            get { return overallPerformance; }
            private set 
            {
                double sumOveralPerf = overallPerformance;
                //>> if components.Count == 0;

                foreach (var component in this.components) 
                {
                    sumOveralPerf += component.OverallPerformance;
                }
                overallPerformance = sumOveralPerf;
            }
        }

        public new decimal Price
        {
            get { return price;  }
            private set
            { 
                decimal sumOfPrices = price;
                decimal sumOfComponentPrices = 0;
                decimal sumOfPeripheralPrices = 0;

                foreach (var component in this.components)                
                {
                    sumOfPeripheralPrices += component.Price;
                }
                foreach (var peripheral in peripherals)
                {
                    sumOfPeripheralPrices += peripheral.Price;
                }

                price = sumOfPrices + sumOfComponentPrices + sumOfPeripheralPrices;
            }
        }


        public void AddComponent(IComponent component)
        {
            throw new NotImplementedException();
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            throw new NotImplementedException();
        }

        public IComponent RemoveComponent(string componentType)
        {
            throw new NotImplementedException();
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Overall Performance: {this.OverallPerformance}. Price: {this.Price} - {this.GetType().Name}: {this.Manufacturer} {this.Model} (Id: {this.Id})");


            sb.AppendLine($" Components ({this.components.Count}):");
            foreach (var component in components)
            {
                sb.AppendLine($"  {component}");
            }

            double overallPerf = 0;

            foreach (var peripheral in peripherals)
            {
                overallPerf += peripheral.OverallPerformance;
            }

            sb.AppendLine($" Peripherals ({peripherals.Count}); Average Overall Performance ({overallPerf/peripherals.Count}):");
            foreach (var peripheral in peripherals)
            {
                sb.AppendLine($"  {peripheral}");
            }




            return sb.ToString().TrimEnd();
        }
    }
}
