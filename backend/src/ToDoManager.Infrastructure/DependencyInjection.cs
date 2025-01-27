using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ToDoManager.Application.Repositories;
using ToDoManager.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

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