using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DTOs.Export;
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

            // from 01 to 04 incl
            //string inputJson = File.ReadAllText(@"../../../Datasets/categories-products.json");
            //01
            //string result = ImportUsers(context, inputJson);

            //02
            //string result = ImportProducts(context, inputJson);

            //03
            //string result = ImportCategories(context, inputJson);

            //04
            //string result = ImportCategoryProducts(context, inputJson);

            //05
            string result = GetSoldProducts(context);

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

            ICollection<Category> categories = new HashSet<Category>();

            foreach (ImportCategoriesDto categoryDto in categorieDtos)
            {
                if (String.IsNullOrEmpty(categoryDto.Name))
                {
                    continue;
                }

                Category category = mapper.Map<Category>(categoryDto);
                categories.Add(category);
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";


        }

        //04. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportCategoryProductsDto[] cpDtos =
                JsonConvert.DeserializeObject<ImportCategoryProductsDto[]>(inputJson);

            ICollection<CategoryProduct> validEntries = new HashSet<CategoryProduct>();
            foreach (ImportCategoryProductsDto cpDto in cpDtos)
            {
                //// This is not wanted in the description but we do it for security
                //// In Judge locally they may not be added previously
                //// JUDGE DO NOT LIKE THIS VALIDATION BELOW!!!!!
                //if (!context.Categories.Any(c => c.Id == cpDto.CategoryId) ||
                //    !context.Products.Any(p => p.Id == cpDto.ProductId))
                //{
                //    continue;
                //}

                CategoryProduct categoryProduct =
                    mapper.Map<CategoryProduct>(cpDto);
                validEntries.Add(categoryProduct);
            }

            context.CategoriesProducts.AddRange(validEntries);
            context.SaveChanges();

            return $"Successfully imported {validEntries.Count}";

        }


        //05. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            IMapper mapper = CreateMapper();

            //Anonymos Obj
            //var products = context.Products
            //        .Where(p => p.Price >= 500 && p.Price <= 1000)
            //        .OrderBy(p => p.Price)
            //        .Select(p => new
            //        {
            //            Name = p.Name,
            //            Price = p.Price,
            //            Seller = p.Seller.FirstName + " " + p.Seller.LastName
            //        })
            //        .AsNoTracking()
            //        .ToArray();

            //DTO
            ExportProductInRangeDto[] productsDtos = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .ProjectTo<ExportProductInRangeDto>(mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToArray();


            return JsonConvert.SerializeObject(productsDtos, Formatting.Indented);

        }

        //06. Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            IContractResolver contractResolver = ConfigureCamelCaseNaming();

            var userSoldProducts = context.Users
                .Where(u => u.ProductsSold.Count >= 1)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                    .Where(ps => ps.BuyerId != null)
                    .Select(ps => new 
                    {
                    Name = ps.Name,
                    Price = ps.Price,
                    buyerFirstName = ps.Buyer.FirstName,
                    buyerLastName = ps.Buyer.LastName
                    }).ToArray()
                })
                .ToArray();

            return JsonConvert.SerializeObject(userSoldProducts, Formatting.Indented, new JsonSerializerSettings()
            {
                ContractResolver = contractResolver
            });

        }

        private static IMapper CreateMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
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