using Microsoft.AspNetCore.HttpLogging; // To use HttpLoggingFields

namespace Packt.Extensions;
public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddCustomHttpLogging(this IServiceCollection services)
    {
        services.AddHttpLogging(options =>
        {
            //Add the origin header so it will not be redacted.
            options.RequestHeaders.Add("Origin");

            //By default, the reponse body is not included.
            options.LoggingFields = HttpLoggingFields.All;

        });
        return services;
    }
}
