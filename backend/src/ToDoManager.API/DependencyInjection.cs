using ToDoManager.API.Interfaces;
using ToDoManager.API.Services;

namespace ToDoManager.API;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentationConfig(this IServiceCollection services)
    {
        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        });

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddScoped<IFileService, FileService>();

        return services;
    }
}

