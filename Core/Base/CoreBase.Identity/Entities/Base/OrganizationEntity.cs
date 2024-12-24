using CoreBase.Domain;

namespace CoreBase.Identity.Entities.Base;

public class OrganizationEntity : CodeNameEntity
{
    public String Description { get; set; }
    public long? ParentOrganizationId { get; set; }
    public virtual OrganizationEntity ParentOrganization { get; set; }
    public virtual List<OrganizationEntity> ChildOrganizations { get; set; }
    public virtual List<UserEntity> UserEntities { get; set; }

}
