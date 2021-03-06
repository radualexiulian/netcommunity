﻿using MassTransit;
using Microsoft.Extensions.Hosting;
using Notifications.Processor;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Notifications.Mappers;
using MediatR;
using Notifications.Application.Handler;
using Notifications.Application.Behaviors;
using Notifications.Dto.Settings;
using Notifications.Data;
using Notifications.Data.Abstractions;

namespace Notifications.ProcessorJob
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Host.CreateDefaultBuilder(args) 
                .ConfigureServices((hostBuilder, services) =>
                {
                    services.AddScoped<IUnitOfWork, UnitOfWork>();
                    services.AddScoped<NotificationDbContext>();

                    // automapper
                    services.AddAutoMapper(typeof(InternalProfile).Assembly);
                    services.AddMediatR(typeof(UserAddedCommandHandler).Assembly);

                    services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuditBehavior<,>));

                    services.Configure<DbSettings>(hostBuilder.Configuration.GetSection("ConnectionStrings"));

                    services.AddHostedService<MassTransitHostedService>();
                    services.AddScoped<NewUserAddedConsumer>();
                    services.AddMassTransit(configure =>
                    {
                        configure.SetKebabCaseEndpointNameFormatter();

                        configure.UsingAzureServiceBus((context, config) =>
                        {
                            config.Host("Endpoint=sb://netcommunity.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=KG9Sk9Qt3Fwf1/RRRqgW67BwvzmQ5cXLyO2iximi6aE=");
                            config.ConfigureEndpoints(context);
                            config.UseJsonSerializer();

                            config.ReceiveEndpoint("notification-queue", e =>
                            { 
                                e.Consumer(() => context.GetService<NewUserAddedConsumer>()); 
                            });
                        });
                    });

            }).RunConsoleAsync();
        }
    }
}
