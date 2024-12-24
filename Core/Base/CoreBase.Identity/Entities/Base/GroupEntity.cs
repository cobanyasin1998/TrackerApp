using CoreBase.Domain;
using CoreBase.Identity.Entities.Auth;

namespace CoreBase.Identity.Entities.Base;

public class GroupEntity : CodeNameEntity
{
    public virtual List<UserGroupEntity> UserGroupEntities { get; set; }

    public virtual List<GroupAuthDefinitionEntity> GroupAuthDefinitionEntities { get; set; }

}
