using NUnit.Framework;
using System;
using System.Net.NetworkInformation;

namespace RepairShop.Tests
{
    public class Tests
    {
        [TestFixture]
        public class RepairsShopTests
        {
            [Test]
            public void GarageNameExName()
            {
                //var garage = new Garage(null, 5);

                Assert.Throws<ArgumentNullException>(() => new Garage(null, 5), "Invalid garage name.");
                Assert.Throws<ArgumentNullException>(() => new Garage(String.Empty, 5), "Invalid garage name.");
            }

            [Test]
            public void GarageNameProperlyName()
            {
                var garage = new Garage("TestName", 5);

                Assert.That(garage.Name, Is.EqualTo("TestName"));
            }

            [Test]
            public void MechanicCountShouldThrowEx()
            {

                Assert.Throws<ArgumentException>(() => new Garage("TestName", 0), "At least one mechanic must work in the garage.");
                Assert.Throws<ArgumentException>(() => new Garage("TestName", -1), "At least one mechanic must work in the garage.");
            }

            [Test]
            public void MechanicCountCorrect()
            {
                var garage = new Garage("TestName", 5);

                Assert.AreEqual(5, garage.MechanicsAvailable);
            }

            [Test]
            public void CarsInGarageCount()
            {
                var garage = new Garage("TestName", 5);
                var car = new Car("Fiat", 2);
                var car1 = new Car("Fiat1", 2);
                garage.AddCar(car);
                garage.AddCar(car1);

                Assert.AreEqual(2, garage.CarsInGarage);
            }

            [Test]
            public void AddCarThrowsExNoMechanicAvailable()
            {
               
                var garage = new Garage("TestName", 2);
                var car = new Car("Fiat", 2);
                var car1 = new Car("Fiat1", 2);
                var car2 = new Car("Fiat2", 2);
                garage.AddCar(car);
                garage.AddCar(car1);

                Assert.Throws<InvalidOperationException>(() => garage.AddCar(car2), "No mechanic available.");
            }

            [Test]
            public void FixCarThrowsExNoModel()
            {
                
                var garage = new Garage("TestName", 5);
                var car = new Car("Fiat", 2);
                var car1 = new Car("Audi", 2);
                garage.AddCar(car);
                garage.AddCar(car1);

                Assert.Throws<InvalidOperationException>(() => garage.FixCar("bmw"));
            }

            [Test]
            public void FixCarSuccsess()
            {

                var garage = new Garage("TestName", 5);
                var car = new Car("Fiat", 2);
                var car1 = new Car("Audi", 2);
                garage.AddCar(car);
                garage.AddCar(car1);

                garage.FixCar("Fiat");

                Assert.AreEqual(0, car.NumberOfIssues);
            }

            [Test]
            public void RemoveFixedCarSuccess()
            {
                var garage = new Garage("TestName", 5);
                var car = new Car("Fiat", 2);
                var car1 = new Car("Audi", 2);
                garage.AddCar(car);
                garage.AddCar(car1);

                garage.FixCar("Fiat");
                garage.RemoveFixedCar();
                Assert.AreEqual(1, garage.CarsInGarage);
            }


            [Test]
            public void RemoveFixedCarThrowsExAvailable()
            {
                var garage = new Garage("TestName", 5);
                var car = new Car("Fiat", 2);
                var car1 = new Car("Audi", 2);
                garage.AddCar(car);
                garage.AddCar(car1);

                //garage.FixCar("Fiat");
               // garage.RemoveFixedCar();
                Assert.Throws<InvalidOperationException>(() => garage.RemoveFixedCar());
            }

        }
    }
}