using CoreBase.Domain;
using CoreBase.Identity.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBase.Identity.Entities.Base
{
    public class GroupEntity : BaseEntity
    {
        public string Name { get; set; }

        public virtual List<UserGroupEntity> UserGroupEntities { get; set; }

        public virtual List<GroupAuthDefinitionEntity> GroupAuthDefinitionEntities { get; set; }

    }

}
