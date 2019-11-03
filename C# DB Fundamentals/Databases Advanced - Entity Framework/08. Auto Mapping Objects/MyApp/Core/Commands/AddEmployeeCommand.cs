﻿namespace MyApp.Core.Commands
{
    using AutoMapper;
    using MyApp.Core.Commands.Contracts;
    using MyApp.Core.ViewModels;
    using MyApp.Data;
    using MyApp.Models;

    public class AddEmployeeCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public AddEmployeeCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] inputArgs)
        {
            var firstName = inputArgs[0];
            var lastName = inputArgs[1];
            var salary = decimal.Parse(inputArgs[2]);

            var employee = new Employee()
            {
                FirstName = firstName,
                LastName = lastName,
                Salary = salary
            };

            this.context.Add(employee);
            this.context.SaveChanges();

            var employeeDto = this.mapper.CreateMappedObject<EmployeeDto>(employee);

            var result = $"{employeeDto.FirstName} {employeeDto.LastName} - {employeeDto.Salary}";
            return result;
        }
    }
}
