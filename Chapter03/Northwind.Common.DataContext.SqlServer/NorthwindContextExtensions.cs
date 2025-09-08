using Microsoft.Data.SqlClient; // SqlConnectionStringBuilder
using Microsoft.EntityFrameworkCore; // UseSqlServer
using Microsoft.Extensions.DependencyInjection; //IServiceCollection

namespace Northwind.EntityModels;

public static class NorthwindContextExtensions
{
    /// <summary>
    /// Na prática, isso faz com que o contexto do banco de dados (NorthwindContext) seja   registrado nos serviços da aplicação, permitindo que outras partes do código possam utilizá-lo sem precisar criar instâncias manualmente.
    /// </summary>
    /// <param name="services">The service collection </param>
    /// <param name="connectionString">Set to override the default</param>
    /// <returns>Um  IServiceCollection que pode ser usado para adicionar mais serviços.</returns>

    public static IServiceCollection AddNorthwindContext(this IServiceCollection services, string? connectionString = null)
    {
        if (connectionString == null)
        {
            SqlConnectionStringBuilder builder = new();
            builder.DataSource = ".\\SQLEXPRESS";
            builder.InitialCatalog = "Northwind";
            builder.TrustServerCertificate = true;
            builder.MultipleActiveResultSets = true;

            //If using Azure SqlEdge.            
            // builder.DataSource = "tcp:127.0.0.1,1433";
            // builder.IntegratedSecurity = true;

            // If using SQL Server authentication.
            // builder.UserID = Environment.GetEnvironmentVariable("MY_SQL_USR");
            // builder.Password = Environment.GetEnvironmentVariable("MY_SQL_PWD");
            builder.UserID = "sa";
            builder.Password = "bruno123";
            connectionString = builder.ConnectionString;
        }

        services.AddDbContext<NorthwindContext>(options =>
        {
            options.UseSqlServer(connectionString);

            //Log to console when executing EF Core commands.
            options.LogTo(Console.WriteLine, new[] { Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.CommandExecuting });
        },
        // Register with a transient lifetime to avoid concurrency
        //issues with blazor Server projects
        contextLifetime: ServiceLifetime.Transient,
        optionsLifetime: ServiceLifetime.Transient);
        return services;
    }
}