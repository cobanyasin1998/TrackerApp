﻿using CoreBase.Interfaces.EntityInterfaces;

namespace CoreBase.Domain;

public class CodeNameEntity : BaseEntity, ICodeNameEntity
{
    public String Name { get; set; }
    public String Code { get; set; }
}
