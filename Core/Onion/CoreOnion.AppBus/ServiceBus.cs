using CoreBase.Interfaces.ServiceBusInterfaces;
using MassTransit;

namespace CoreOnion.AppBus;

public class ServiceBus(IPublishEndpoint publishEndpoint,ISendEndpointProvider sendEndpointProvider) : IServiceBus
{
    public async Task PublishAsync<T>(T @event, CancellationToken cancellationToken = default) where T : IEventOrMessage
        => await publishEndpoint.Publish(@event, cancellationToken);

    public Task SendAsync<T>(T message, string queqeName, CancellationToken cancellationToken = default) where T : IEventOrMessage =>
        sendEndpointProvider.GetSendEndpoint(new Uri($"queue:{queqeName}"))
            .ContinueWith(task => task.Result.Send(message, cancellationToken));
}
