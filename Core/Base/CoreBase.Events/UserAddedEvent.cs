using CoreBase.Interfaces.ServiceBusInterfaces;

namespace CoreBase.Events;

public record UserAddedEvent(string Email, string Password) : IEventOrMessage
{
    public Guid IdompotentId { get; set; } = Guid.NewGuid();

    public DateTime Time { get; set ; } = DateTime.Now;
}

