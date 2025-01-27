namespace HotelServiceSystem.Infrastructure.Database;

/// <summary>
/// Represents a connection string.
/// </summary>
public sealed class ConnectionString
{
    /// <summary>
    /// The connection strings key.
    /// </summary>
    public const string SettingsMigrationKey = "HotelSystemConnectionStringMigration";

    public const string SettingsKey = "HotelSystemConnectionString";
}
