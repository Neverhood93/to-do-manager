using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ToDoManager.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using ToDoManager.Application.Interfaces.Repositories;

namespace ToDoManager.Infrastructure;

public static class DependencyInjection
{
public static IServiceCollection AddInfrastructureConfig(this IServiceCollection services, IConfiguration configuration)
{
    var connectionString = configuration.GetConnectionString("DefaultConnection");

    services.AddDbContext<DatabaseContext>(options =>
        options.UseSqlServer(connectionString));

    services.AddScoped<IToDoRepository, ToDoRepository>();
    services.AddScoped<IToDoStatusRepository, ToDoStatusRepository>();
    services.AddScoped<IToDoFileRepository, ToDoFileRepository>();

    return services;
}
}