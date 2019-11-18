namespace CarDealer
{
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.Dtos.Import;
    using CarDealer.Dtos.Export;
    using CarDealer.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(x => x.AddProfile<CarDealerProfile>());

            var inputCars = File.ReadAllText(@"../../../Datasets/cars.xml");
            var inputCustomers = File.ReadAllText(@"../../../Datasets/customers.xml");
            var inputParts = File.ReadAllText(@"../../../Datasets/parts.xml");
            var inputSales = File.ReadAllText(@"../../../Datasets/sales.xml");
            var inputsuppliers = File.ReadAllText(@"../../../Datasets/suppliers.xml");

            using (var context = new CarDealerContext())
            {
                //    context.Database.EnsureDeleted();
                //    context.Database.EnsureCreated();
                //Console.WriteLine(ImportSuppliers(context, inputsuppliers));
                //Console.WriteLine(ImportParts(context, inputParts));
                Console.WriteLine(ImportCars(context, inputCars));
                //Console.WriteLine(ImportCustomers(context, inputCustomers));
                //Console.WriteLine(ImportSales(context, inputSales));
                //Console.WriteLine(GetLocalSuppliers(context));
            }
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSuppliersDto[]), new XmlRootAttribute("Suppliers"));

            var suppliersDto = (ImportSuppliersDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var suppliers = new List<Supplier>();

            foreach (var supplierDto in suppliersDto)
            {
                var supplier = Mapper.Map<Supplier>(supplierDto);
                suppliers.Add(supplier);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPartsDto[]), new XmlRootAttribute("Parts"));

            var partsDto = (ImportPartsDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var parts = new List<Part>();

            var partsFilteredDto = partsDto
               .Where(x => x.SupplierId != 0 && x.SupplierId != null)
               .Where(x => x.SupplierId <= context.Suppliers.Count());

            foreach (var partDto in partsFilteredDto)
            {
                var part = Mapper.Map<Part>(partDto);
                parts.Add(part);
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCarsDto[]), new XmlRootAttribute("Cars"));

            var carsDto = (ImportCarsDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var cars = new List<Car>();
            var partCars = new List<PartCar>();

            foreach (var carDto in carsDto)
            {
                var car = Mapper.Map<Car>(carDto);

                foreach (var part in carDto.CarParts)
                {
                    var partCar = Mapper.Map<PartCar>(part);
                    partCars.Add(partCar);
                }
                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.PartCars.AddRange(partCars);
            context.SaveChanges();

            Console.WriteLine($"Successfully imported {partCars.Count}");
            return $"Successfully imported {cars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCustomersDto[]), new XmlRootAttribute("Customers"));

            var customersDto = (ImportCustomersDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var customers = new List<Customer>();

            foreach (var customerDto in customersDto)
            {
                var customer = Mapper.Map<Customer>(customerDto);
                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSalesDto[]), new XmlRootAttribute("Sales"));

            var salesDto = (ImportSalesDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var sales = new List<Sale>();

            var salesFiltered = salesDto
              .Where(x => x.CarId != 0)
               .Where(x => x.CarId <= context.Cars.Count()); ;

            foreach (var saleDto in salesFiltered)
            {
                var sale = Mapper.Map<Sale>(saleDto);
                sales.Add(sale);
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context
               .Cars
               .Select(c => new ExportCarsWithDistanceDto
               {
                   Make = c.Make,
                   Model = c.Model,
                   TravelledDistance = c.TravelledDistance
               })
               .Where(c => c.TravelledDistance > 2000000)
               .OrderBy(c => c.Make)
               .ThenBy(c => c.Model)
               .Take(10)
               .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarsWithDistanceDto[]), new XmlRootAttribute("cars"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            xmlSerializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var searchedCarMake = "BMW";
            var cars = context
               .Cars
               .Where(c => c.Make == searchedCarMake)
               .Select(c => new ExportCarsBMWDto
               {
                   Id = c.Id,
                   Model = c.Model,
                   TravelledDistance = c.TravelledDistance
               })
               .OrderBy(c => c.Model)
               .ThenByDescending(c => c.TravelledDistance)
               .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarsBMWDto[]), new XmlRootAttribute("cars"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            xmlSerializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context
              .Suppliers
              .Where(s=>!s.IsImporter)
              .Select(c => new ExportLocalSuppliersDto
              {
                  Id = c.Id,
                  Name = c.Name,
                  PartsCount = c.Parts.Count
              })
              .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportLocalSuppliersDto[]), new XmlRootAttribute("suppliers"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            xmlSerializer.Serialize(new StringWriter(sb), suppliers, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context
              .Cars
              .Select(c => new ExportCarsWithDistanceDto
              {
                  Make = c.Make,
                  Model = c.Model,
                  TravelledDistance = c.TravelledDistance
              })
              .Where(c => c.TravelledDistance > 2000000)
              .OrderBy(c => c.Make)
              .ThenBy(c => c.Model)
              .Take(10)
              .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarsWithDistanceDto[]), new XmlRootAttribute("cars"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            xmlSerializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}