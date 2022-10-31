using System.Reflection;
using Newtonsoft.Json;

namespace Module_Task
{
    internal class Logger
    {
        private static readonly Config _config = JsonConvert.DeserializeObject<Config>(File.ReadAllText($@"{Directory.GetParent(Assembly.GetExecutingAssembly().Location) !.Parent!.Parent!.Parent}\config.json")) !;
        private static readonly string _message = _config.Logger.BackupMessage;
        private static readonly int _n = _config.Logger.N;
        private static Logger? _instance;
        private int _counter;
        static Logger()
        {
        }

        private Logger()
        {
        }

        public event Action<string>? BackUpNotify;

        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Logger();
                }

                return _instance;
            }
        }

        public void Notify(string message)
        {
            Console.WriteLine(message);
        }

        public async Task WriteToFileAsync(string path, string fileName, string message)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            await File.AppendAllTextAsync(path + fileName, Environment.NewLine + message);

            _counter++;
            if (_counter % _n == 0)
            {
                BackUpNotify?.Invoke(Environment.NewLine + _message);
                CreateBackup(path + fileName);
            }
        }

        private void CreateBackup(string pathOfLogs)
        {
            var fileName = $"\\{DateTime.Now:hh.mm.ss.FFFFFF.dd.MM.yyyy}.txt";
            var path = Directory.GetCurrentDirectory() + $"\\Backup";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            File.Copy(pathOfLogs, path + fileName);
        }
    }
}
