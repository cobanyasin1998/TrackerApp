namespace CoreBase.Interfaces.ServiceBusInterfaces;

public interface IServiceBus
{
    Task PublishAsync<T>(T @event, CancellationToken cancellationToken = default) where T : IEventOrMessage;
    Task SendAsync<T>(T message, string queqeName, CancellationToken cancellationToken = default) where T : IEventOrMessage;
}
