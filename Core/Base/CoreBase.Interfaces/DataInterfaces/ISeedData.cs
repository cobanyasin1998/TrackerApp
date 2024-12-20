namespace CoreBase.Interfaces.DataInterfaces;

public interface ISeedData
{
    Task<int> SeedEntityData(int count);
}
