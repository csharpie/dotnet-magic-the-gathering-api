using Microsoft.OpenApi.Models;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddWebApiServices(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();

        services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "MagicTheGatheringApi",
                Version = "v1",
                Description = "Return Card information.",
                Contact = new OpenApiContact
                {
                    Name = "The Wizard",
                    Email = "TheWizard@OfTheCoast.com"
                }
            });
        });

        return services;
    }
}