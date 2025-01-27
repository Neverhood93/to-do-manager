using Microsoft.Extensions.DependencyInjection;
using ToDoManager.Application.Interfaces.Services;
using ToDoManager.Application.Services;

namespace ToDoManager.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationConfig(this IServiceCollection services)
    {
        services.AddScoped<IToDoService, ToDoService>();

        return services;
    }
}
