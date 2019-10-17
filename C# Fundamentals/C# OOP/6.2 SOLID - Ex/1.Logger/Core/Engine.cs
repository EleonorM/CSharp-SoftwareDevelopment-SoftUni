namespace _1.Logger.Core
{
    using _1.Logger.Factory;
    using _1.Logger.Models.Contracts;
    using System;

    public class Engine
    {
        private ILogger logger;
        private ErrorFactory errorFactory;

        public Engine(ILogger logger) : this()
        {
            this.logger = logger;
        }

        private Engine()
        {
            this.errorFactory = new ErrorFactory();
        }

        public void Run()
        {
            while (true)
            {
                var errorArgs = Console.ReadLine().Split("|");
                if (errorArgs[0] == "END")
                {
                    break;
                }

                var level = errorArgs[0];
                var date = errorArgs[1];
                var message = errorArgs[2];

                IError error;
                try
                {
                    error = this.errorFactory.GetError(date, level, message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

                this.logger.Log(error);
            }

            Console.WriteLine(this.logger.ToString());
        }
    }
}
