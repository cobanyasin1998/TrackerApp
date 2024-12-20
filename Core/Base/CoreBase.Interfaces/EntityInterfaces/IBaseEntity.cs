namespace CoreBase.Interfaces.EntityInterfaces;

public interface IBaseEntity : IStatus, ITimeStamp,IOwner
{
    long Id { get; set; }
}
