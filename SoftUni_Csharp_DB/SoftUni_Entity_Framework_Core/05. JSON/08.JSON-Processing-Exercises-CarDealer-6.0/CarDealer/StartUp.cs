using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Globalization;
using System.Linq;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            //from 01 to 04 incl
            //string inputJson = File.ReadAllText(@"../../../Datasets/sales.json");

            //09
            //string result = ImportSuppliers(context, inputJson);

            //10
            //string result = ImportParts(context, inputJson);

            //11
            //string result = ImportCars(context, inputJson);

            //12
            //string result = ImportCustomers(context, inputJson);

            //13
            //string result = ImportSales(context, inputJson);

            //14
            //string result = GetOrderedCustomers(context);

            //15
            //string result = GetCarsFromMakeToyota(context);
            //string jsonOutput = GetCarsFromMakeToyota(context);
            //string outputFilePath = @"../../../Results/toyota-cars.json";
            //File.WriteAllText(outputFilePath, jsonOutput);

            //16 
            //string result = GetLocalSuppliers(context);

            //17
            //string result = GetCarsWithTheirListOfParts(context);

            //18
            //string result = GetTotalSalesByCustomer(context);
            //19
            string result = GetSalesWithAppliedDiscount(context);

            Console.WriteLine(result);
        }

        ////09. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportSuppliersDto[] suppliersDtos = JsonConvert.DeserializeObject<ImportSuppliersDto[]>(inputJson);

            ICollection<Supplier> validSuppliers = new HashSet<Supplier>();

            foreach (ImportSuppliersDto dto in suppliersDtos)
            {
                Supplier suppliers = mapper.Map<Supplier>(dto);
                validSuppliers.Add(suppliers);
            }

            context.Suppliers.AddRange(validSuppliers);
            context.SaveChanges();

            return $"Successfully imported {validSuppliers.Count}.";
        }

        //////10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            //If the supplierId doesn't exist in the Suppliers table, skip the record.

            IMapper mapper = CreateMapper();

            ImportPartsDto[] partsDtos = JsonConvert.DeserializeObject<ImportPartsDto[]>(inputJson);

            ICollection<Part> validParts = new HashSet<Part>();


            foreach (var dto in partsDtos)
            {
                if (!context.Suppliers.Any(p => p.Id == dto.SupplierId))
                {
                    continue;
                }

                Part parts = mapper.Map<Part>(dto);
                validParts.Add(parts);
            }

            context.Parts.AddRange(validParts);
            context.SaveChanges();

            return $"Successfully imported {validParts.Count}.";
        }

        //////11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsAndPartsDTO = JsonConvert.DeserializeObject<List<ImportCarsDto>>(inputJson);

            List<PartCar> parts = new List<PartCar>();
            List<Car> cars = new List<Car>();

            foreach (var dto in carsAndPartsDTO)
            {
                Car car = new Car()
                {
                    Make = dto.Make,
                    Model = dto.Model,
                    TraveledDistance = dto.TraveledDistance
                };
                cars.Add(car);

                foreach (var part in dto.PartsId.Distinct())
                {
                    PartCar partCar = new PartCar()
                    {
                        Car = car,
                        PartId = part,
                    };
                    parts.Add(partCar);
                }
            }

            context.Cars.AddRange(cars);
            context.PartsCars.AddRange(parts);
            context.SaveChanges();
            return $"Successfully imported {cars.Count}.";

        }

        ////12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            var customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        //13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            var sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();
            return $"Successfully imported {sales.Count}.";
        }

        ////14. Export Ordered Customers
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            IMapper mapper = CreateMapper();
            //Get all customers ordered by their birth date ascending.
            //If two customers are born on the same date first print those who are not young drivers (e.g., print experienced drivers first).
            //Export the list of customers to JSON in the format provided below.

            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString(@"dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IsYoungDriver = c.IsYoungDriver
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        ////15. Export Cars From Make Toyota
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            //Get all cars with Toyota make and order them by model alphabetically and by traveled distance descending.
            //Export the list of cars to JSON in the format provided below.

            var carsToyota = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .Select(c => new
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .ToArray();

            return JsonConvert.SerializeObject(carsToyota, Formatting.Indented);
        }

        //16 Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            //Get all suppliers that do not import parts from abroad.
            //Get their id, name and the number of parts they can offer to supply.
            //Export the list of suppliers to JSON in the format provided below.

            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            return JsonConvert.SerializeObject(suppliers, Formatting.Indented);

        }

        //17. Export Cars With Their List Of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            //Get all cars along with their list of parts.
            //For the car get only make, model and traveled distance and for the parts get only name and price (formatted to 2nd digit after the decimal point). 

            var carsAndParts = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TraveledDistance
                    },
                    parts = c.PartsCars
                        .Select(p => new
                        {
                            p.Part.Name,
                            Price = $"{p.Part.Price:f2}"
                        })
                })
                .ToArray();

            return JsonConvert.SerializeObject(carsAndParts, Formatting.Indented);
        }

        //18. Export Total Sales By Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customerSales = context.Customers
                           .Where(c => c.Sales.Any())
                           .Select(c => new
                           {
                               fullName = c.Name,
                               boughtCars = c.Sales.Count(),
                               salePrices = c.Sales.SelectMany(x => x.Car.PartsCars.Select(x => x.Part.Price))
                           })
                           .ToArray();

            var totalSalesByCustomer = customerSales.Select(t => new
            {
                t.fullName,
                t.boughtCars,
                spentMoney = t.salePrices.Sum()
            })
            .OrderByDescending(t => t.spentMoney)
            .ThenByDescending(t => t.boughtCars)
            .ToArray();

            return JsonConvert.SerializeObject(totalSalesByCustomer, Formatting.Indented);

        }

        //19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var salesWithDiscount = context.Sales
                .Take(10)
                .Select(s => new
                {
                    car = new
                    {
                        s.Car.Make,
                        s.Car.Model,
                        s.Car.TraveledDistance
                    },
                    customerName = s.Customer.Name,
                    discount = $"{s.Discount:f2}",
                    price = $"{s.Car.PartsCars.Sum(p => p.Part.Price):f2}",
                    priceWithDiscount = $"{s.Car.PartsCars.Sum(p => p.Part.Price) * (1 - s.Discount / 100):f2}"
                })
                .ToArray();

            return JsonConvert.SerializeObject(salesWithDiscount, Formatting.Indented);
        }

        private static IMapper CreateMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));
        }

        private static IContractResolver ConfigureCamelCaseNaming()
        {
            return new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy(false, true)
            };
        }
    }
}