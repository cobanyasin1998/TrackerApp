using CoreBase.Enums.Entities;

namespace CoreBase.Interfaces.EntityInterfaces;

public interface IStatus
{
    EEntityStatus Status { get; set; }
}
