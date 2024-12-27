using CoreBase.Interfaces.ServiceBusInterfaces;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace CoreOnion.AppBus.Extensions;

public static class BusExtensions
{
    public static void AddBusExt(this IServiceCollection services)
    {
        services.AddScoped<IServiceBus, ServiceBus>();

        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(new Uri("amqps://foomgkgi:3XRQbC1RsE3dIcZj7FuusV3PZTdkvoCH@rattlesnake.rmq.cloudamqp.com/foomgkgi"));
            });
        });
    }
}
