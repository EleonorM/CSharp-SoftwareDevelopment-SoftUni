namespace ProductShop
{
    using AutoMapper;
    using ProductShop.Data;
    using ProductShop.Dtos.Import;
    using ProductShop.Dtos.Export;
    using ProductShop.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using System.Text;
    using System.Xml;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(x => x.AddProfile<ProductShopProfile>());

            var inputUsers = File.ReadAllText("../../../Datasets/users.xml");
            var inputProducts = File.ReadAllText("../../../Datasets/products.xml");
            var inputCategories = File.ReadAllText("../../../Datasets/categories.xml");
            var inputCategoriesProducts = File.ReadAllText("../../../Datasets/categories-products.xml");
            using (var context = new ProductShopContext())
            {
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();
                //Console.WriteLine(ImportUsers(context, inputUsers));
                //Console.WriteLine(ImportProducts(context, inputProducts));
                //Console.WriteLine(ImportCategories(context, inputCategories));
                //Console.WriteLine(ImportCategoryProducts(context, inputCategoriesProducts));
                //Console.WriteLine(GetProductsInRange(context));
                //Console.WriteLine(GetCategoriesByProductsCount(context));
                Console.WriteLine(GetUsersWithProducts(context));
            }
        }

        //01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportUserDto[]), new XmlRootAttribute("Users"));

            var usersDto = (ImportUserDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var users = new List<User>();

            foreach (var userDto in usersDto)
            {
                var user = Mapper.Map<User>(userDto);
                users.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        //02. Import Products
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProductDto[]), new XmlRootAttribute("Products"));

            var productsDto = (ImportProductDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var products = new List<Product>();

            foreach (var productDto in productsDto)
            {
                var product = Mapper.Map<Product>(productDto);
                products.Add(product);
            }

            context.Products.AddRange(products);
            context.SaveChanges();
            return $"Successfully imported {products.Count}";
        }

        //03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoriesDto[]), new XmlRootAttribute("Categories"));

            var categoriesDto = (ImportCategoriesDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var categories = new List<Category>();

            foreach (var categoryDto in categoriesDto)
            {
                if (categoryDto.Name != null)
                {
                    var category = Mapper.Map<Category>(categoryDto);
                    categories.Add(category);
                }
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();
            return $"Successfully imported {categories.Count}";
        }

        //04. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoryProductDto[]), new XmlRootAttribute("CategoryProducts"));

            var categoriesProductsDto = (ImportCategoryProductDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var categoriesProducts = new List<CategoryProduct>();

            foreach (var categoryProductDto in categoriesProductsDto)
            {
                var category = context.Categories.Find(categoryProductDto.CategoryId);
                var product = context.Products.Find(categoryProductDto.ProductId);
                if (category == null || product == null)
                {
                    continue;
                }
                var categoryProduct = Mapper.Map<CategoryProduct>(categoryProductDto);
                categoriesProducts.Add(categoryProduct);
            }

            context.CategoryProducts.AddRange(categoriesProducts);
            context.SaveChanges();
            return $"Successfully imported {categoriesProducts.Count}";
        }

        //05. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new ExportProductInRangeDto()
                {
                    Name = x.Name,
                    Price = x.Price,
                    Buyer = x.Buyer.FirstName + " " + x.Buyer.LastName
                })
                .OrderBy(x => x.Price)
                .Take(10)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportProductInRangeDto[]), new XmlRootAttribute("Products"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            xmlSerializer.Serialize(new StringWriter(sb), products, namespaces);

            return sb.ToString().TrimEnd();

        }

        //06. Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(u => u.ProductsSold.Any())
                .Select(u => new ExportUserSoldProductsDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold.Select(x => new ProductDto
                    {
                        Name = x.Name,
                        Price = x.Price
                    })
                    .ToArray()
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportUserSoldProductsDto[]), new XmlRootAttribute("Users"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            xmlSerializer.Serialize(new StringWriter(sb), users, namespaces);

            return sb.ToString().TrimEnd();
        }

        //07. Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var cat = Mapper.Map<ExportCategoriesByProductsCountDto[]>(context.Categories);
            var categories = context
                .Categories
                .Select(c => new ExportCategoriesByProductsCountDto
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price),
                    AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCategoriesByProductsCountDto[]), new XmlRootAttribute("Categories"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            xmlSerializer.Serialize(new StringWriter(sb), categories, namespaces);

            return sb.ToString().TrimEnd();
        }

        //08. Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(u => u.ProductsSold.Any())
                .Select(u => new ExportUserAndProductDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProductDto = new SoldProductDto
                    {
                        Count = u.ProductsSold.Count,
                        ProductDto = u.ProductsSold.Select(p => new ProductDto
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                    }
                })
                .ToArray()
                .OrderByDescending(u => u.SoldProductDto.Count)
                .Take(10)
                .ToArray();

            var export = new ExportCustomUserProductDto
            {
                Count = context
                .Users
                .Count(u => u.ProductsSold.Any()),
                Users = users
            };
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCustomUserProductDto), new XmlRootAttribute("Users"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            xmlSerializer.Serialize(new StringWriter(sb), export, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}