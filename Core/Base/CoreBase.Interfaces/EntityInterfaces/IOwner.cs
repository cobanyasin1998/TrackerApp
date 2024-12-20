namespace CoreBase.Interfaces.EntityInterfaces;

public interface IOwner
{
    long CreatedUserId { get; set; }
    long? UpdatedUserId { get; set; }

}
