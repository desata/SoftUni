using AutoMapper;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.Text.Json.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
           ProductShopContext context = new ProductShopContext();

            string inputJson = File.ReadAllText(@"../../../Datasets/categories.json");
            //01
            //string result = ImportUsers(context, inputJson);

            //02
            //string result = ImportProducts(context, inputJson);


            //03
            string result = ImportCategories(context, inputJson);

            Console.WriteLine(result);
        }

        //01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportUserDto[] userDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson);

            ICollection<User> validUsers = new HashSet<User>();

            foreach (ImportUserDto dto in userDtos)
            {
                User user = mapper.Map<User>(dto);
                validUsers.Add(user);
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return $"Successfully imported {validUsers.Count}";
        }


        //02. Import Products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportProductDto[] productsDtos = JsonConvert.DeserializeObject<ImportProductDto[]>(inputJson);


            Product[] products = mapper.Map<Product[]>(productsDtos);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }


        //03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();
            ImportCategoriesDto[] categorieDtos = JsonConvert.DeserializeObject<ImportCategoriesDto[]>(inputJson);

            Category[] categories = mapper.Map<Category[]>(categorieDtos);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";


        }



        private static IMapper CreateMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));
        }
    }
}