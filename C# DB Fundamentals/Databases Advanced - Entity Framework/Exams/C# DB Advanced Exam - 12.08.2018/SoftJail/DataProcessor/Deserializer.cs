namespace SoftJail.DataProcessor
{
    using AutoMapper;
    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var departmentDtos = JsonConvert.DeserializeObject<ImportDepartmentDto[]>(jsonString);
            var departments = new List<Department>();
            var sb = new StringBuilder();
            foreach (var departmentDto in departmentDtos)
            {
                if (!IsValid(departmentDto) || !departmentDto.Cells.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                //with AutoMapper
                //Department department = Mapper.Map<Department>(departmentDto);

                var department = new Department
                {
                    Name = departmentDto.Name,
                    Cells = departmentDto.Cells.Select(c => new Cell
                    {
                        CellNumber = c.CellNumber,
                        HasWindow = c.HasWindow,
                    })
                    .ToArray()
                };
                departments.Add(department);

                sb.AppendLine($"Imported {departmentDto.Name} with {departmentDto.Cells.Count} cells");
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisionersMailsDtos = JsonConvert.DeserializeObject<ImportPrisionersMailsDto[]>(jsonString);
            var prisoners = new List<Prisoner>();
            var sb = new StringBuilder();
            foreach (var prisionersMailsDto in prisionersMailsDtos)
            {
                if (!IsValid(prisionersMailsDto) || !prisionersMailsDto.Mails.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var prisoner = new Prisoner
                {
                    FullName = prisionersMailsDto.FullName,
                    Nickname = prisionersMailsDto.Nickname,
                    Age = prisionersMailsDto.Age,
                    Bail = prisionersMailsDto.Bail,
                    CellId = prisionersMailsDto.CellId,
                    IncarcerationDate = DateTime.ParseExact(prisionersMailsDto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    ReleaseDate = prisionersMailsDto.ReleaseDate != null ? DateTime.ParseExact(prisionersMailsDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null,
                    Mails = prisionersMailsDto.Mails.Select(m => new Mail
                    {
                        Description = m.Description,
                        Sender = m.Sender,
                        Address = m.Address
                    })
                    .ToArray()
                };
                prisoners.Add(prisoner);

                sb.AppendLine($"Imported {prisionersMailsDto.FullName} {prisionersMailsDto.Age} years old");
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportOfficersPrisionersDto[]), new XmlRootAttribute("Officers"));

            var officerPrisionerDtos = (ImportOfficersPrisionersDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var officers = new List<Officer>();

            foreach (var officersPrisionersDto in officerPrisionerDtos)
            {
                if (!IsValid(officersPrisionersDto) || !officersPrisionersDto.Prisoners.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                if (!Enum.TryParse<Weapon>(officersPrisionersDto.Weapon, out Weapon weapon) || !Enum.TryParse<Position>(officersPrisionersDto.Position, out Position position))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                var officer = new Officer
                {
                    FullName = officersPrisionersDto.Name,
                    Weapon = weapon,
                    Position = position,
                    Salary = officersPrisionersDto.Money,
                    DepartmentId = officersPrisionersDto.DepartmentId,
                    Department = context.Departments.FirstOrDefault(x=>x.Id == officersPrisionersDto.DepartmentId),
                    OfficerPrisoners = officersPrisionersDto.Prisoners.Select(x => new OfficerPrisoner
                    {
                        PrisonerId = x.Id
                    })
                    .ToArray()
                };

              //  officer.OfficerPrisoners = officersPrisionersDto.Prisoners.Select(x => new OfficerPrisoner { Officer = officer, PrisonerId = x.Id }).ToArray();
                officers.Add(officer);
                sb.AppendLine($"Imported {officersPrisionersDto.Name} ({officersPrisionersDto.Prisoners.Count()} prisoners)");
            }

            context.Officers.AddRange(officers);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(entity, validationContext, validationResult, true);

            return isValid;
        }
    }
}