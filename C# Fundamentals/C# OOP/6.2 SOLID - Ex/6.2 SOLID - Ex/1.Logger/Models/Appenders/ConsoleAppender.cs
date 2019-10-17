namespace _1.Logger.Models.Appenders
{
    using _1.Logger.Models.Contracts;
    using _1.Logger.Models.Enumerations;
    using System.Globalization;

    public class ConsoleAppender : IAppender
    {
        private int messagesAppended;

        public ConsoleAppender(ILayout layout, Level level)
        {
            this.Layout = layout;
            this.Level = level;
        }

        public ILayout Layout { get; }

        public Level Level { get; }

        public string Format { get; }

        public void Append(IError error)
        {
            var dateFomrat = "M/dd/yyyy h:mm:ss tt";
            var format = this.Layout.Format;
            var dateTime = error.DateTime;
            var message = error.Message;
            var level = error.Level;

            string formatMessage = string.Format(format, dateTime.ToString(dateFomrat, CultureInfo.InvariantCulture), level.ToString(), message.ToString());
            System.Console.WriteLine(formatMessage);
            this.messagesAppended++;
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.Level.ToString()}, Messages appended: {this.messagesAppended}";
        }
    }
}