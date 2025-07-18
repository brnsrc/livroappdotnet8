using Microsoft.Data.SqlClient; // SqlConnectionStringBuilder
using Microsoft.EntityFrameworkCore; // DbContext

namespace Northwind.EntityModels;
public partial class NorthwindContext : DbContext
{
    private static readonly SetLastRefreshedInterceptor setLastRefreshedInterceptor = new();
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            SqlConnectionStringBuilder builder = new();
            builder.DataSource = ".\\SQLEXPRESS";
            builder.InitialCatalog = "Northwind";
            builder.TrustServerCertificate = true;
            builder.MultipleActiveResultSets = true;

            //Because we want to fail. Default is 15 seconds.
            builder.ConnectTimeout = 3;

            //If using SQL Server authentication.
            builder.UserID = "sa";
            builder.Password = "bruno123";
            optionsBuilder.UseSqlServer(builder.ConnectionString);
        }
        optionsBuilder.AddInterceptors(setLastRefreshedInterceptor);
    }
}

