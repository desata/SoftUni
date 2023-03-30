﻿using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using ProductShop.Utilities;
using System.Text;
using System.Xml;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            string inputXml = File.ReadAllText(@"../../../Datasets/categories-products.xml");
                        
            string result = GetSoldProducts(context);
            Console.WriteLine(result);
        }

        private static XmlHelper xmlHelper;

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            xmlHelper = new XmlHelper();

            ImportUsersDto[] usersDto = xmlHelper.Deserialize<ImportUsersDto[]>(inputXml, "Users");

            ICollection<User> validusers = new HashSet<User>();

            foreach (ImportUsersDto userDto in usersDto)
            {
                User user = new User()
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Age = userDto.Age,
                };

                validusers.Add(user);

            }

            context.Users.AddRange(validusers);
            context.SaveChanges();

            return $"Successfully imported {validusers.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            xmlHelper = new XmlHelper();

            ImportProductsDto[] productsDtos = xmlHelper.Deserialize<ImportProductsDto[]>(inputXml, "Products");

            ICollection<Product> validProducts = new HashSet<Product>();

            foreach (ImportProductsDto productsDto in productsDtos)
            {
                Product product = new Product()
                {
                    Name = productsDto.Name,
                    Price = productsDto.Price,
                    SellerId = productsDto.SellerId,
                    BuyerId = productsDto.BuyerId
                };

                validProducts.Add(product);
            }

            context.Products.AddRange(validProducts);
            context.SaveChanges();

            return $"Successfully imported {validProducts.Count}";

        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {         
            xmlHelper = new XmlHelper();

            ImportCategoryDto[] categoryDtos = xmlHelper.Deserialize<ImportCategoryDto[]>(inputXml, "Categories");

            ICollection<Category> validCategories = new HashSet<Category>();

            foreach (ImportCategoryDto categoryDto in categoryDtos)
            {
                Category category = new Category()
                { 
                Name =categoryDto.Name
                };

                validCategories.Add(category);
            }

            context.Categories.AddRange(validCategories);
            context.SaveChanges();

            return $"Successfully imported {validCategories.Count}";

        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        { 
            xmlHelper = new XmlHelper();

            ImportCategoryProductsDto[] categoryProductsDtos = xmlHelper.Deserialize<ImportCategoryProductsDto[]>(inputXml, "CategoryProducts");

            ICollection<CategoryProduct> validCategoryProducts = new HashSet<CategoryProduct>();

            foreach (ImportCategoryProductsDto categoryProductsDto in categoryProductsDtos)
            {
                CategoryProduct categoryProduct = new CategoryProduct()
                { 
                CategoryId = categoryProductsDto.CategoryId,
                ProductId = categoryProductsDto.ProductId
                };
                validCategoryProducts.Add(categoryProduct);
            }
            context.CategoryProducts.AddRange(validCategoryProducts);
            context.SaveChanges();

            return $"Successfully imported {validCategoryProducts.Count}"; 
        }


        public static string GetProductsInRange(ProductShopContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();

            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .Select(p => new ExportProductsInRangeDto
                { 
                    Name = p.Name,
                    Price = p.Price,
                   // Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                   Buyer = $"{p.Buyer.FirstName} {p.Buyer.LastName}"
                })
                .ToArray();

            return xmlHelper.Serialize(products, "Products");

            
        }


        public static string GetSoldProducts(ProductShopContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();

            var users = context.Users
                .Where(sp => sp.ProductsSold.Any())
                .OrderBy(u => u.LastName)
                .Take(5)
                .Select(u => new ExportSoldProducts
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                        .Select(ps => new ExportProductsDto
                        {
                            Name = ps.Name,
                            Price = ps.Price,
                        }).ToArray()
                })
                .ToArray();

            return xmlHelper.Serialize(users, "Users");
        }
    }
}