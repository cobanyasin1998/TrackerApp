namespace CoreBase.Interfaces.EntityInterfaces;

public interface IOwner
{
    Int64 CreatedUserId { get; set; }
    Int64? UpdatedUserId { get; set; }

}
