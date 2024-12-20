using CoreBase.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBase.Identity.Entities.Auth
{
    public class AuthDefinitionEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public long AuthFormEntityId { get; set; }
        public virtual AuthFormEntity AuthFormEntity { get; set; }
        public virtual List<GroupAuthDefinitionEntity> GroupAuthDefinitionEntities { get; set; }

    }
}
