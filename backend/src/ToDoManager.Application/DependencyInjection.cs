using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ToDoManager.Application.Common.Behaviors;
using ToDoManager.Application.Features.ToDoStatuses.Commands.Create;

namespace ToDoManager.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationConfig(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddMediatR(option =>
        {
            option.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
        });

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}
