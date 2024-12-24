using CoreBase.Domain;

namespace CoreBase.Identity.Entities.Auth;

public class AuthDefinitionEntity : CodeNameEntity
{
    public long AuthFormEntityId { get; set; }
    public virtual AuthFormEntity AuthFormEntity { get; set; }
    public virtual List<GroupAuthDefinitionEntity> GroupAuthDefinitionEntities { get; set; }

}
