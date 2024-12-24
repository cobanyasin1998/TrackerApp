using CoreBase.Domain;

namespace CoreBase.Identity.Entities.Auth;

public class AuthModuleEntity : CodeNameEntity
{
    public virtual List<AuthFormEntity> AuthFormEntities { get; set; }
}
