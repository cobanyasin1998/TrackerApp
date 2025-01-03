namespace CoreBase.Interfaces.ServiceBusInterfaces;
public interface IEventOrMessage : IEvent, IMessage
{
    Guid IdompotentId { get; }
    public DateTime Time { get; set; }
}