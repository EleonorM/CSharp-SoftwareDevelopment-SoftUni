namespace _1.Logger
{
    using _1.Logger.Core;
    using _1.Logger.Factory;
    using _1.Logger.Models.Contracts;
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var appendersCount = int.Parse(Console.ReadLine());
            ICollection<IAppender> appenders = new List<IAppender>();
            var appenderFactory = new AppenderFactory();
            ReadAppendersData(appendersCount, appenders, appenderFactory);

            ILogger logger = new Models.Logger(appenders);

            Engine engine = new Engine(logger);
            engine.Run();
        }

        private static void ReadAppendersData(int appendersCount, ICollection<IAppender> appenders, AppenderFactory appenderFactory)
        {
            for (int i = 0; i < appendersCount; i++)
            {
                var appenderInfo = Console.ReadLine().Split();

                var appenderType = appenderInfo[0];
                var layoutType = appenderInfo[1];
                var levelString = "INFO";

                if (appenderInfo.Length == 3)
                {
                    levelString = appenderInfo[2];
                }

                try
                {
                    IAppender appender = appenderFactory.GetAppender(appenderType, layoutType, levelString);
                    appenders.Add(appender);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
        }
    }
}
