namespace Module_Task
{
    public class LoggerConfig
    {
        public LoggerConfig(string directoryPath, string backUpDirectoryPath, string fileName, string fileExtention, int n, int repeatCount, string message)
        {
            DirectoryPath = directoryPath;
            BackUpDirectoryPath = backUpDirectoryPath;
            FileName = fileName;
            FileExtention = fileExtention;
            N = n;
            RepeatCount = repeatCount;
            BackupMessage = message;
        }

        public string DirectoryPath { get; set; }

        public string BackUpDirectoryPath { get; set; }

        public string FileName { get; set; }

        public string FileExtention { get; set; }

        public int N { get; set; }

        public int RepeatCount { get; set; }
        public string BackupMessage { get; set; }
    }
}