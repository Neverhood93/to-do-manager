using Microsoft.AspNetCore.Http.Features;
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

        services.Configure<FormOptions>(options =>
        {
            options.MultipartBodyLengthLimit = 200 * 1024 * 1024;
        });

        return services;
    }
}

