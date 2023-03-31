namespace CarDealer;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.Utilities;

using Data;
using Microsoft.EntityFrameworkCore;

public class StartUp
{
    public static void Main()
    {
        CarDealerContext carDealerContext = new CarDealerContext();


        ////// Problem 9
        //string inputXml = File.ReadAllText(@"../../../Datasets/suppliers.xml");
        //string result = ImportSuppliers(carDealerContext, inputXml);


        ////Problem 10
        //string inputXml = File.ReadAllText(@"../../../Datasets/parts.xml");
        //string result = ImportParts(carDealerContext, inputXml);

        ////Problem 11

        //string inputXml = File.ReadAllText(@"../../../Datasets/cars.xml");
        //string result = ImportCars(carDealerContext, inputXml);

        ////Problem 12

        //string inputXml = File.ReadAllText(@"../../../Datasets/customers.xml");
        //string result = ImportCustomers(carDealerContext, inputXml);

        ////Problem 13

        //string inputXml = File.ReadAllText(@"../../../Datasets/sales.xml");
        //string result = ImportSales(carDealerContext, inputXml);

        ////Problem 14

        //string result = GetCarsWithDistance(carDealerContext);

        ////Problem 15

        //string result = GetCarsFromMakeBmw(carDealerContext);

        ////Problem 16
        //string result = GetLocalSuppliers(carDealerContext);

        ////Problem 17
        //string result = GetCarsWithTheirListOfParts(carDealerContext);

        //Problem 18

        //string result = GetTotalSalesByCustomer(carDealerContext);
        
        ////Problem 19

        string result = GetSalesWithAppliedDiscount(carDealerContext);

        Console.WriteLine(result);
    }

    //Problem 9
    public static string ImportSuppliers(CarDealerContext context, string inputXml)
    {

        IMapper mapper = CreateMapper();
        //Serialize + Deserialize
        XmlHelper xmlhelper = new XmlHelper();
        ImportSupplierDto[] supplierDtos = xmlhelper.Deserialize<ImportSupplierDto[]>(inputXml, "Suppliers");

        ICollection<Supplier> validSuppliers = new HashSet<Supplier>();

        foreach (var supplierDto in supplierDtos)
        {
            if (string.IsNullOrEmpty(supplierDto.Name))
            {
                continue;
            }

            //Manual mapping without automapper

            //Supplier supplier = new Supplier()
            //{
            //    Name = supplierDto.Name,
            //    IsImporter = supplierDto.IsImporter
            //};
            //validSuppliers.Add(supplier);

            Supplier supplier = mapper.Map<Supplier>(supplierDto);
            validSuppliers.Add(supplier);
        }

        context.Suppliers.AddRange(validSuppliers);
        context.SaveChanges();

        return $"Successfully imported {validSuppliers.Count}";
    }

    //Problem 10

    public static string ImportParts(CarDealerContext context, string inputXml)
    {
        IMapper mapper = CreateMapper();

        XmlHelper xmlhelper = new XmlHelper();
        ImportPartDto[] partsDtos = xmlhelper.Deserialize<ImportPartDto[]>(inputXml, "Parts");

        ICollection<Part> validParts = new HashSet<Part>();

        foreach (var partDto in partsDtos)
        {

            if (string.IsNullOrEmpty(partDto.Name))
            {
                continue;
            }

            if (!context.Suppliers.Any(s => s.Id == partDto.SupplierId) || !partDto.SupplierId.HasValue)
            {
                continue;
            }

            Part part = mapper.Map<Part>(partDto);
            validParts.Add(part);
        }

        context.Parts.AddRange(validParts);
        context.SaveChanges();

        return $"Successfully imported {validParts.Count}";
    }

    //Problem 11

   public static string ImportCars(CarDealerContext context, string inputXml)
    {
        IMapper mapper = CreateMapper();
        XmlHelper xmlhelper = new XmlHelper();

        ImportCarDto[] carDtos = xmlhelper.Deserialize<ImportCarDto[]>(inputXml,"Cars");

        ICollection<Car> validCars = new HashSet<Car>();
        

        foreach(var carDto in carDtos) 
        {
            if(string.IsNullOrEmpty(carDto.Make) || string.IsNullOrEmpty(carDto.Model))
            {
                continue;
            }


            Car car = mapper.Map<Car>(carDto);
           
            foreach (var partDto in carDto.PartIds.DistinctBy(p=>p.PartId))
            {
                if (!context.Parts.Any(p => p.Id == partDto.PartId))
                {
                    continue;
                }

                PartCar partId = new PartCar()
                {
                    
                    PartId = partDto.PartId
                    
                };

                car.PartsCars.Add(partId);
            }

            validCars.Add(car);
        }

        context.Cars.AddRange(validCars);
        context.SaveChanges();

        return $"Successfully imported {validCars.Count}";
    }

    //Problem 12
    public static string ImportCustomers(CarDealerContext context, string inputXml)
    {
        IMapper mapper = CreateMapper();
        XmlHelper xmlHelper = new XmlHelper();

        ImportCustomerDto[] customerDtos = xmlHelper.Deserialize<ImportCustomerDto[]>(inputXml, "Customers");

        ICollection<Customer> validCustomers = new HashSet<Customer>();

        foreach(var customDto  in customerDtos)
        {
            if(string.IsNullOrEmpty(customDto.Name)) 
            {
                continue; 
            }
            Customer customer = mapper.Map<Customer>(customDto);
            validCustomers.Add(customer);
        }

        context.Customers.AddRange(validCustomers);
        context.SaveChanges();

        return $"Successfully imported {validCustomers.Count}";
    }

    //Problem 13
    public static string ImportSales(CarDealerContext context, string inputXml)
    {
        IMapper mapper = CreateMapper();

        XmlHelper xmlHelper = new XmlHelper();

        ImportSaleDto[] saleDtos = xmlHelper.Deserialize<ImportSaleDto[]>(inputXml, "Sales");

        ICollection<Sale> validSales = new HashSet<Sale>();

        foreach (var saleDto in saleDtos)
        {
            if (!context.Cars.Any(c => c.Id == saleDto.CarId))
            {
                continue;
            }

            Sale sale = mapper.Map<Sale>(saleDto);
            validSales.Add(sale);
        }

        context.Sales.AddRange(validSales);
        context.SaveChanges();

        return $"Successfully imported {validSales.Count}";
    }

    //Problem 14

    public static string GetCarsWithDistance(CarDealerContext context)
    {
        IMapper mapper = CreateMapper();
        XmlHelper helper = new XmlHelper();
       

        ExportCarDto[] cars = context.Cars
                            .Where(c=>c.TraveledDistance>2000000)
                            .OrderBy(c => c.Make)
                            .ThenBy(c=>c.Model)
                            .Take(10)
                            .ProjectTo<ExportCarDto>(mapper.ConfigurationProvider)
                            .ToArray();

        //// We make method Serialize() in class XmlHelper

        //XmlRootAttribute xmlRoot = new XmlRootAttribute("cars");

        //XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarDto[]),xmlRoot);

        //XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(); // with this we remove the namespaces in root

        //namespaces.Add(string.Empty, string.Empty); //i.e adding preffix empty string and namespace empty string

        //StringBuilder result = new StringBuilder();

        //using StringWriter writer = new StringWriter(result);// this writer will be write in result instead(вместо) us

        //xmlSerializer.Serialize(writer, cars, namespaces);

        //return result.ToString().TrimEnd();



        return helper.Serialize<ExportCarDto>(cars, "cars");

    }

    //Problem 15

    public static string GetCarsFromMakeBmw(CarDealerContext context)     
    {
        IMapper mapper = CreateMapper();
        XmlHelper helper = new XmlHelper();

        ExportCarMakeByBWDtos[] exportCarDtos = context.Cars
                                                .Where(c=>c.Make == "BMW")
                                                .OrderBy(c=>c.Model)
                                                .ThenByDescending(c=>c.TraveledDistance)
                                                .ProjectTo<ExportCarMakeByBWDtos> (mapper.ConfigurationProvider)
                                                .ToArray();



        return helper.Serialize<ExportCarMakeByBWDtos>(exportCarDtos,"cars");


    }

    //Problem 16

    public static string GetLocalSuppliers(CarDealerContext context)
    {
        IMapper mapper = CreateMapper();
        XmlHelper helper = new XmlHelper();
        
        ExportSupplierNotImportDto[] supplierNotImortDtos = context.Suppliers
                                                                    .Where(s => s.IsImporter == false) 
                                                                    .ProjectTo<ExportSupplierNotImportDto>(mapper.ConfigurationProvider)
                                                                    .ToArray();

        return helper.Serialize<ExportSupplierNotImportDto>(supplierNotImortDtos, "suppliers");

    }

    //Problem 17

    public static string GetCarsWithTheirListOfParts(CarDealerContext context)
    {
        IMapper mapper = CreateMapper();
        XmlHelper xmlHelper = new XmlHelper();

        ExportCarWithPartsDto[] carWithPartsDtos = context.Cars
                                                        .OrderByDescending(c => c.TraveledDistance)
                                                        .ThenBy(c => c.Model)
                                                        .Take(5)                                                         
                                                        .ProjectTo<ExportCarWithPartsDto>(mapper.ConfigurationProvider)   
                                                        .ToArray();

       

        return xmlHelper.Serialize<ExportCarWithPartsDto>(carWithPartsDtos, "cars");
    }

    //Problem 18

    public static string GetTotalSalesByCustomer(CarDealerContext context)
    {
        IMapper mapper = CreateMapper();
        XmlHelper xmlHelper = new XmlHelper();

        ExportSaleDto[] customerDtos = context.Customers
                                                   .Where(c => c.Sales.Count > 0)
                                                   .ProjectTo<ExportSaleDto>(mapper.ConfigurationProvider)
                                                   .ToArray();

        List<ExportCustomerDto> sortedCustomersDtos = mapper.Map<ExportCustomerDto[]>(customerDtos)
                                                  .OrderByDescending(c=>c.SpentMoney)
                                                  .ToList();

        return xmlHelper.Serialize<List<ExportCustomerDto>>(sortedCustomersDtos, "customers");
    }

    //Problem 19

    public static string GetSalesWithAppliedDiscount(CarDealerContext context)
    {
        IMapper mapper = CreateMapper();
        XmlHelper xmlHelper = new XmlHelper();

        ExportSalesWithDiscount[] salesWithDiscount = context.Sales
                                                  .ProjectTo<ExportSalesWithDiscount>(mapper.ConfigurationProvider)
                                                  .ToArray();

        return xmlHelper.Serialize<ExportSalesWithDiscount>(salesWithDiscount, "sales");
    }

    public static IMapper CreateMapper()
    {
        return new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        }));
    }
}