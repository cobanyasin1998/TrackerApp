namespace CoreBase.Interfaces.EntityInterfaces;

public interface ITimeStamp
{
    DateTime CreatedTime { get; set; }
    DateTime? UpdatedTime { get; set; }

}
