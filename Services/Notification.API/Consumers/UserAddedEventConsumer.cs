using CoreBase.Events;
using MassTransit;

namespace Notification.API.Consumers;

public class UserAddedEventConsumer : IConsumer<UserAddedEvent>
{
    public Task Consume(ConsumeContext<UserAddedEvent> context)
    {
        string? email = context.Message.Email;
        string? password = context.Message.Password;

        Console.WriteLine($"User Added: {email}, Password: {password}");
        return Task.CompletedTask;
    }
}
