using CoreBase.Domain;
using CoreBase.Identity.Entities.Base;

namespace CoreBase.Identity.Entities.Auth;

public class GroupAuthDefinitionEntity : BaseEntity
{
    public long GroupEntityId { get; set; }
    public long AuthDefinitionEntityId { get; set; }

    public virtual GroupEntity GroupEntity { get; set; }
    public virtual AuthDefinitionEntity AuthDefinitionEntity { get; set; }
}
