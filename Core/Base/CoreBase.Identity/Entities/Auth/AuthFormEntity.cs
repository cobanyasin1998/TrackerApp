using CoreBase.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBase.Identity.Entities.Auth
{
    public class AuthFormEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public long AuthModuleEntityId { get; set; }
        public virtual AuthModuleEntity AuthModuleEntity { get; set; }
        public virtual List<AuthDefinitionEntity> AuthDefinitionEntities { get; set; }
    }

}
