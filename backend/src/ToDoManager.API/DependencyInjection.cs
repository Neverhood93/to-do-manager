﻿namespace ToDoManager.API;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentationConfig(this IServiceCollection services)
    {
        services.AddControllers();

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen();

        return services;
    }
}

