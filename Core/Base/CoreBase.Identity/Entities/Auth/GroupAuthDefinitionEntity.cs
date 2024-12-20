using CoreBase.Domain;
using CoreBase.Identity.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBase.Identity.Entities.Auth
{
    public class GroupAuthDefinitionEntity : BaseEntity
    {
        public long GroupEntityId { get; set; }
        public long AuthDefinitionEntityId { get; set; }

        public virtual GroupEntity GroupEntity { get; set; }
        public virtual AuthDefinitionEntity AuthDefinitionEntity { get; set; }
    }

}
