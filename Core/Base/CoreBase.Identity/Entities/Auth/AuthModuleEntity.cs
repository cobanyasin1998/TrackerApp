using CoreBase.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBase.Identity.Entities.Auth
{
    public class AuthModuleEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public virtual List<AuthFormEntity> AuthFormEntities { get; set; }
    }

}
