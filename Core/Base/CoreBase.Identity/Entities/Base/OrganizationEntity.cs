﻿using CoreBase.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBase.Identity.Entities.Base
{
    public class OrganizationEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public long? ParentOrganizationId { get; set; }
        public virtual OrganizationEntity ParentOrganization { get; set; }
        public virtual List<OrganizationEntity> ChildOrganizations { get; set; }
        public virtual List<UserEntity> UserEntities { get; set; }

    }

}
