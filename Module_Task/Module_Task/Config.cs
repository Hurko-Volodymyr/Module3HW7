namespace Module_Task
{
    internal class Config
    {
        public Config(LoggerConfig logger)
        {
            Logger = logger;
        }

        public LoggerConfig Logger { get; set; }
    }
}