using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Dtos;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new ProductShopContext())
            {
                //  context.Database.EnsureCreated();
                var pathUsers = Path.Combine(Environment.CurrentDirectory, "Datasets\\users.json");
                var users = File.ReadAllText(pathUsers);
                var pathProducts = Path.Combine(Environment.CurrentDirectory, "Datasets\\products.json");
                var products = File.ReadAllText(pathProducts);
                var pathCategoriesProducts = Path.Combine(Environment.CurrentDirectory, "Datasets\\categories-products.json");
                var categoriesProducts = File.ReadAllText(pathCategoriesProducts);
                var pathCategories = Path.Combine(Environment.CurrentDirectory, "Datasets\\categories.json");
                var categories = File.ReadAllText(pathCategories);


                Console.WriteLine(ImportUsers(context, users));
            }
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson)
                .Where(u => u.LastName != null && u.LastName.Length > 2);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<Product[]>(inputJson)
               .Where(u => u.Name != null && u.Name.Length > 2 && u.Price != 0);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<Category[]>(inputJson)
               .Where(u => u.Name.Length >= 3 && u.Name.Length <= 15);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count()}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsInRange = context
                 .Products
                 .Where(p => p.Price >= 500 && p.Price <= 1000)
                 .Select(p => new ProductDto
                 {
                     Name = p.Name,
                     Price = p.Price,
                     Seller = $"{p.Seller.FirstName} {p.Seller.LastName}".Trim()
                 })
                .OrderBy(p=>p.Price)
                .ToList();

            var products = JsonConvert.SerializeObject(productsInRange, Formatting.Indented);
            return products;
        }
    }
}