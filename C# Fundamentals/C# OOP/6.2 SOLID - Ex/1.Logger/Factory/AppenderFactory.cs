namespace _1.Logger.Factory
{
    using _1.Logger.Exceptions;
    using _1.Logger.Models.Appenders;
    using _1.Logger.Models.Contracts;
    using _1.Logger.Models.Enumerations;
    using _1.Logger.Models.Files;
    using System;

    public class AppenderFactory
    {
        private LayoutFactory layoutFactory;

        public AppenderFactory()
        {
            this.layoutFactory = new LayoutFactory();
        }

        public IAppender GetAppender(string appenderType, string layoutType, string levelStr)
        {
            Level level;
            bool hasParsed = Enum.TryParse<Level>(levelStr, out level);
            if (!hasParsed)
            {
                throw new InvalidLevelTypeException();
            }

            ILayout layout = this.layoutFactory.GetLayout(layoutType);

            IAppender appender;
            if (appenderType == "ConsoleAppender")
            {
                appender = new ConsoleAppender(layout, level);
            }
            else if (appenderType == "FileAppender")
            {
                IFile file = new LogFile();
                appender = new FileAppender(layout, level, file);
            }
            else
            {
                throw new InvalidAppenderTypeException();
            }

            return appender;
        }
    }
}
