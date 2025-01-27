using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace HotelServiceSystem.Infrastructure.Database;

public class HotelServiceSystemDbContextFactory : IDesignTimeDbContextFactory<HotelServiceSystemDbContext>
{
    public HotelServiceSystemDbContext CreateDbContext(string[] args)
    {
        string basePath = Directory.GetCurrentDirectory();
        string appSettingsPath = Path.Combine(basePath, "..", "HotelServiceSystem.Api");

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(appSettingsPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();


        string connectionString = configuration.GetConnectionString(ConnectionString.SettingsKey)
            ?? throw new Exception("Connection string not defined!");

        var optionsBuilder = new DbContextOptionsBuilder<HotelServiceSystemDbContext>();

        optionsBuilder.UseSqlite(connectionString);

        // Pass null for IMediator (since it's only needed at runtime, not design-time)
        return new HotelServiceSystemDbContext(optionsBuilder.Options, null);
    }
}
