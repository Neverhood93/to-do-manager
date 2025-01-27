using Microsoft.Extensions.DependencyInjection;

namespace ToDoManager.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationConfig(this IServiceCollection services)
    {
        return services;
    }
}
