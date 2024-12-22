namespace CoreBase.Interfaces.DataInterfaces;

public interface ISeedData
{
    Task<Int32> SeedEntityData(Int32 count);
}
