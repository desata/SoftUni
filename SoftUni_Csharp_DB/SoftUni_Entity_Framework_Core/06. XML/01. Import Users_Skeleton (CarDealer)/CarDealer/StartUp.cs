using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext context = new CarDealerContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            string inputXml = File.ReadAllText("../../../Datasets/suppliers.xml");


            string result = ImportSuppliers(context, inputXml);

            Console.WriteLine(result);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper helper = new XmlHelper();

            SuppliersDTO[] suppliersDtos = helper.Deserialize<SuppliersDTO[]>(inputXml, "Suppliers");

            ICollection<Supplier> validSuppliers = new HashSet<Supplier>();

            foreach (var s in suppliersDtos)
            {
                if (String.IsNullOrEmpty(s.Name))
                {
                    continue;
                }
                Supplier supplier = mapper.Map<Supplier>(suppliersDtos);

                validSuppliers.Add(supplier);

            }

            context.Suppliers.AddRange(validSuppliers);
           // context.SaveChanges();

            return $"Successfully imported {validSuppliers.Count}";
        }


        private static IMapper InitializeAutoMapper()
            => new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));
    }
}