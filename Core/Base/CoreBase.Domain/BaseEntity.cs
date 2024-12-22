using CoreBase.Enums.Entities;
using CoreBase.Interfaces.EntityInterfaces;

namespace CoreBase.Domain;

public class BaseEntity : IBaseEntity
{
    public Int64 Id { get; set; }
    public EEntityStatus Status { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime? UpdatedTime { get; set; }
    public Int64 CreatedUserId { get; set; }
    public Int64? UpdatedUserId { get; set; }
}
