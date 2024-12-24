using CoreBase.Domain;

namespace CoreBase.Identity.Entities.Auth;

public class AuthFormEntity : CodeNameEntity
{
    public long AuthModuleEntityId { get; set; }
    public virtual AuthModuleEntity AuthModuleEntity { get; set; }
    public virtual List<AuthDefinitionEntity> AuthDefinitionEntities { get; set; }

}
