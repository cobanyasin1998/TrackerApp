using CoreBase.Enums.Entities;
using CoreBase.Interfaces.EntityInterfaces;

namespace CoreBase.Domain;

public class BaseEntity : IBaseEntity
{
    public long Id { get; set; }
    public EEntityStatus Status { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime? UpdatedTime { get; set; }
    public long CreatedUserId { get; set; }
    public long? UpdatedUserId { get; set; }
}
