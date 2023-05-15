
using Microsoft.EntityFrameworkCore;
using WebAPICRUD.Settings;

namespace WebAPICRUD.Entities;

public partial class DBContext
{
    public readonly string _connection;
    public DBContext(AppSettings appSettings)
    {
        _connection = appSettings.ConnectionStr;
    }

    protected override void OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(_connection);
        }
    }
}
