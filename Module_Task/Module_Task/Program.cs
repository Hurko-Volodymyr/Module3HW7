namespace Module_Task
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var starter = new Starter();
            await starter.RunAsync();
        }
    }
}