using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            // from 01 to 04 incl
            string inputJson = File.ReadAllText(@"../../../Datasets/suppliers.json");

            string result = ImportSuppliers(context, inputJson);
            Console.WriteLine(result);
        }

        //09. Import Suppliers
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