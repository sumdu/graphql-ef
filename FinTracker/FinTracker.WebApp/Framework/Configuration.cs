namespace FinTracker.WebApp.Framework
{
    public static class Configuration
    {
        public static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var config = builder.Build();
            return config.GetConnectionString("FinTracker");
        }
    }
}
