using System.Reflection;
using Newtonsoft.Json;

namespace Module_Task
{
    internal class Starter
    {
        public async Task RunAsync()
        {
            var workDirectory = Directory.GetParent(Assembly.GetExecutingAssembly().Location) !.Parent!.Parent!.Parent;
            var configFile = File.ReadAllText($@"{workDirectory}\config.json");
            var config = JsonConvert.DeserializeObject<Config>(configFile);
            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) !;
            var path = $@"{assemblyPath}\{config!.Logger.DirectoryPath}";
            var file = $"{config.Logger.FileName}.{config.Logger.FileExtention}";
            var counter = 0;
            var repeatCount = config.Logger.RepeatCount;
            var errorCount = 0;
            var notErrorCount = 0;

            Logger.Instance.BackUpNotify += Logger.Instance.Notify;

            while (counter < repeatCount)
            {
                await Logger.Instance.WriteToFileAsync(path, file, $"error: {errorCount}");
                errorCount++;
                await Logger.Instance.WriteToFileAsync(path, file, $"not error: {notErrorCount}");
                notErrorCount++;
                counter++;
                Console.WriteLine("Error count: " + errorCount);
                Console.WriteLine("Not Error count: " + notErrorCount);
            }

            Console.WriteLine("Done");
        }
    }
}