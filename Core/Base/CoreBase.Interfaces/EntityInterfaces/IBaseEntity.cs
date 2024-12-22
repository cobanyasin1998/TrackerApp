namespace CoreBase.Interfaces.EntityInterfaces;

public interface IBaseEntity : IStatus, ITimeStamp,IOwner
{
    Int64 Id { get; set; }
}
