namespace ProductShop
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using ProductShop.Data;
    using ProductShop.Dtos;
    using ProductShop.Models;
    using System;
    using System.IO;
    using System.Linq;

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


                Console.WriteLine(GetUsersWithProducts(context));
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
               .Where(p => p.Name != null && p.Name.Length > 2 && p.Price != 0);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<Category[]>(inputJson)
               .Where(u => u.Name != null && u.Name.Length >= 3 && u.Name.Length <= 15);

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
                     Seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                 })
                .OrderBy(p => p.Price)
                .ToList();

            var products = JsonConvert.SerializeObject(productsInRange, Formatting.Indented);
            return products;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var usersWithsoldProducts = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                .Select(u => new
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                    .Where(sp => sp.Buyer != null)
                    .Select(sp => new
                    {
                        Name = sp.Name,
                        Price = sp.Price,
                        BuyerFirstName = sp.Buyer.FirstName,
                        BuyerLastName = sp.Buyer.LastName
                    })
                })
                .OrderBy(u => u.FirstName)
                .OrderBy(u => u.LastName)
                .ToList();

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var products = JsonConvert.SerializeObject(usersWithsoldProducts, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver
            });
            return products;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categoriesByProductCount = context
                .Categories
                .OrderByDescending(c => c.CategoryProducts.Count)
                .Select(c => new
                {
                    Category = c.Name,
                    ProductsCount = c.CategoryProducts.Count(),
                    AveragePrice = Math.Round(c.CategoryProducts.Average(cp => cp.Product.Price), 2).ToString(),
                    TotalRevenue = Math.Round(c.CategoryProducts.Sum(cp => cp.Product.Price), 2).ToString()
                })
                .ToList();

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var categories = JsonConvert.SerializeObject(categoriesByProductCount, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver
            });
            return categories;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersFiltered = context
                .Users
                .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                .OrderByDescending(u => u.ProductsSold.Count(ps => ps.Buyer != null))
                .Select(u => new
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new
                    {
                        Count = u.ProductsSold.Count(p => p.Buyer != null),
                        Products = u.ProductsSold
                        .Where(ps => ps.Buyer != null).Select(p => new
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                    }
                })
                .ToList();

            var result = new
            {
                UsersCount = usersFiltered.Count,
                Users = usersFiltered
            };

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var users = JsonConvert.SerializeObject(result, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver,
                NullValueHandling = NullValueHandling.Ignore
            });
            return users;
        }
    }
}