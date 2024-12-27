using CoreBase.Interfaces.ServiceBusInterfaces;

namespace CoreBase.Events;

public record UserAddedEvent(string Email, string Password) : IEventOrMessage;

