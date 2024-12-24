namespace CoreBase.Interfaces.EntityInterfaces;

public interface ICodeNameEntity : IBaseEntity
{
    String Name { get; set; }
    String Code { get; set; }
}

