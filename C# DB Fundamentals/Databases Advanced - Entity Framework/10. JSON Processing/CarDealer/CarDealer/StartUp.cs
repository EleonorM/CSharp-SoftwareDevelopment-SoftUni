namespace CarDealer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.DTO;
    using CarDealer.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var cars = File.ReadAllText(@"./../../../Datasets/cars.json");
            var customers = File.ReadAllText(@"./../../../Datasets/customers.json");
            var parts = File.ReadAllText(@"./../../../Datasets/parts.json");
            var sales = File.ReadAllText(@"./../../../Datasets/sales.json");
            var suppliers = File.ReadAllText(@"./../../../Datasets/suppliers.json");
            using (var context = new CarDealerContext())
            {
                //context.Database.EnsureCreated();
                //Console.WriteLine(ImportSuppliers(context, suppliers));
                //Console.WriteLine(ImportParts(context, parts));
                //Console.WriteLine(ImportCars(context, cars));
                //Console.WriteLine(ImportCustomers(context, customers));
                //Console.WriteLine(ImportSales(context, sales));

                Console.WriteLine(GetSalesWithAppliedDiscount(context));
            }
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var template = new[] {new
            {
                Name = String.Empty,
                Price = 0.0m,
                Quantity = 0,
                SupplierId = (int?)0
            }};
            var parts = JsonConvert.DeserializeAnonymousType(inputJson, template);

            var partsFiltered = parts
                .Where(x => x.SupplierId != 0 && x.SupplierId != null)
                .Where(x => x.SupplierId <= context.Suppliers.Count())
                .Select(p => new Part
                {
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    SupplierId = (int)p.SupplierId
                });
            context.Parts.AddRange(partsFiltered);
            context.SaveChanges();

            return $"Successfully imported {partsFiltered.Count()}.";

        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDto = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson);

            var cars = new List<Car>();
            var partCars = new List<PartCar>();

            foreach (var carDto in carsDto)
            {
                var car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                foreach (var part in carDto.PartsId.Distinct())
                {
                    var partCar = new PartCar()
                    {
                        PartId = part,
                        Car = car
                    };
                    partCars.Add(partCar);
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.PartCars.AddRange(partCars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var orderedCustomers = context
                .Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();

            var customers = JsonConvert.SerializeObject(orderedCustomers, Formatting.Indented);
            return customers;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var searchedCarMake = "Toyota";
            var carsToyota = context
                .Cars
                .Where(x => x.Make == searchedCarMake)
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToList();

            var cars = JsonConvert.SerializeObject(carsToyota, Formatting.Indented);
            return cars;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context
                .Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToList();

            var suppliers = JsonConvert.SerializeObject(localSuppliers, Formatting.Indented);
            return suppliers;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithPars = context
                .Cars
                .Select(c => new
                {
                    car =
                new
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                },
                    parts = c.PartCars.Select(p => new
                    {
                        Name = p.Part.Name,
                        Price = $"{p.Part.Price:f2}"
                    })
                })
                .ToList();

            var cars = JsonConvert.SerializeObject(carsWithPars, Formatting.Indented);
            return cars;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customersBySales = context
                .Customers
                .Where(c => c.Sales.Any())
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.Sum(x => x.Car.PartCars.Sum(y => y.Part.Price))
                })
                .OrderByDescending(x => x.SpentMoney)
                .ThenByDescending(x => x.BoughtCars)
                .ToList();

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var customers = JsonConvert.SerializeObject(customersBySales, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = contractResolver
            });
            return customers;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var filteredSales = context
                .Sales
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = $"{s.Discount:f2}",
                    price = $"{s.Car.PartCars.Sum(x => x.Part.Price):f2}",
                    priceWithDiscount = $"{s.Car.PartCars.Sum(x => x.Part.Price) * ((100m - s.Discount) / 100m):f2}"
                })
                .Take(10)
                .ToList();

            var sales = JsonConvert.SerializeObject(filteredSales, Formatting.Indented);
            return sales;
        }
    }
}