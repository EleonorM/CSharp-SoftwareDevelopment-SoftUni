namespace _1.Logger.Models.Files
{
    using _1.Logger.Models.Contracts;
    using _1.Logger.Models.Enumerations;
    using _1.Logger.Models.IOMenagement;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    public class LogFile : IFile
    {
        private const string DateFormat = "M/dd/yyyy h:mm:ss tt";
        private const string CurrentDirectory = "\\logs\\";
        private const string CurrentFile = "log.txt";
        private string currentPath;
        private IIOManager IOManager;

        public LogFile()
        {
            this.IOManager = new IOManager(CurrentDirectory, CurrentFile);
            this.currentPath = this.IOManager.GetCurrentPath();
            this.IOManager.EnsureDirectoryAndFileExist();
            this.Path = this.currentPath + CurrentDirectory + CurrentFile;
        }

        public string Path { get; private set; }

        ulong IFile.Size => this.GetFileSize();

        public string Write(ILayout layout, IError error)
        {
            string format = layout.Format;
            var dateTime = error.DateTime;
            var message = error.Message;
            Level level = error.Level;

            string formatMessage = string.Format(format, dateTime.ToString(DateFormat, CultureInfo.InvariantCulture), level.ToString(), message.ToString());
            return formatMessage;
        }  

        private ulong GetFileSize()
        {
            var size = (ulong)File.ReadAllText(this.Path)
                .ToCharArray()
                .Where(c => char.IsLetter(c))
                .Sum(c => (int)c);
            return size;
        }
    }
}
