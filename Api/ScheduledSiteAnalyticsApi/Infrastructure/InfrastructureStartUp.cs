﻿using Domain.Interfaces;
using Hangfire;
using Hangfire.PostgreSql;
using Infrastructure;
using Infrastructure.Connection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ProfileConnectionLib;

public static class InfrastuctureStartUp
{
    public static IServiceCollection TryAddInfrastucture(this IServiceCollection serviceCollection, IConfigurationManager configurationManager)
    {
        serviceCollection.TryAddScoped<IScheduleTask, PositionConnection>();
        serviceCollection.TryAddPositionLib(configurationManager);
        
        var connectionString = configurationManager.GetConnectionString("DefaultConnection");
        serviceCollection.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString));

        
        connectionString = configurationManager.GetConnectionString("HangfireConnection");
        serviceCollection.AddHangfire(config =>
            config.UsePostgreSqlStorage(connectionString));

        serviceCollection.AddHangfireServer();
        
        return serviceCollection;
    }
}