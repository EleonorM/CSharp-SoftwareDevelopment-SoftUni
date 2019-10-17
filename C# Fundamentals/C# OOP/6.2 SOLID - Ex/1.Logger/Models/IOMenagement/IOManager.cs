namespace _1.Logger.Models.IOMenagement
{
    using _1.Logger.Models.Contracts;
    using System.IO;

   public class IOManager : IIOManager
    {
        private string currentPath;
        private string currentDirectory;
        private string currentFile;

        public IOManager(string currentDirectory, string currentFile) : this()
        {
            this.currentDirectory = currentDirectory;
            this.currentFile = currentFile;
        }

        private IOManager()
        {
            this.currentPath = this.GetCurrentPath();
        }

        public string CurrentDirectoryPath => this.currentPath + this.currentDirectory;

        public string CurrentFilePath => this.CurrentDirectoryPath + this.currentFile;

        public string GetCurrentPath()
        {
            return Directory.GetCurrentDirectory();
        }

        public void EnsureDirectoryAndFileExist()
        {
            if (!Directory.Exists(this.CurrentDirectoryPath))
            {
                Directory.CreateDirectory(this.CurrentDirectoryPath);
            }

            File.WriteAllText(this.CurrentFilePath, string.Empty);
        }
    }
}
