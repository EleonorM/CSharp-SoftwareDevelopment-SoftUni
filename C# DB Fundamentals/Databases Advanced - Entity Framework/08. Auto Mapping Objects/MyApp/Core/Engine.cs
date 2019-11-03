namespace MyApp.Core
{
    using MyApp.Core.Contracts;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Linq;

    public class Engine : IEngine
    {
        private readonly IServiceProvider serviceProvider;

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Run()
        {
            while (true)
            {
                var inputArgs = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .ToArray();

                var commandInterpreter = this.serviceProvider.GetService<ICommandInterpreter>();

                var result = commandInterpreter.Read(inputArgs);
                Console.WriteLine(result);
            }
        }
    }
}
