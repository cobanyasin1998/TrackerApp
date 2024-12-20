using CoreBase.Interfaces.DataInterfaces;

namespace CoreOnion.Persistence.SeedData;

public class SeedDataManager(IEnumerable<ISeedData> _seedDataServices)
{
    public async Task SeedAll(int count = 5_000)
    {
        foreach (ISeedData seedService in _seedDataServices)
            _ = await seedService.SeedEntityData(count);
    }
}
