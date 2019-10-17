namespace _1.Logger
{
    using _1.Logger.Models.Contracts;
    using _1.Logger.Models.Enumerations;
    using System;
    using System.Globalization;

    public class FileAppender : IAppender
    {
        private int messagesAppended;

        public FileAppender(ILayout layout, Level level, IFile file)
        {
            this.Layout = layout;
            this.Level = level;
            this.File = file;
        }

        public ILayout Layout { get; private set; }

        public Level Level { get; private set; }

        public string Format { get; }

        public IFile File { get; private set; }

        public void Append(IError error)
        {
            var dateFomrat = "M/dd/yyyy h:mm:ss tt";
            var format = this.Layout.Format;
            var dateTime = error.DateTime;
            var message = error.Message;
            var level = error.Level;

            string formatMessage = string.Format(format, dateTime.ToString(dateFomrat, CultureInfo.InvariantCulture), level.ToString(), message.ToString());
            var formatedMessage = this.File.Write(this.Layout, error) + Environment.NewLine;
            System.IO.File.AppendAllText(this.File.Path, formatedMessage);
            this.messagesAppended++;
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.Level.ToString()}, Messages appended: {this.messagesAppended}, File size {this.File.Size}";
        }
    }
}
