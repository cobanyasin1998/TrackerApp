using CoreBase.Consts.DataProtection;
using CoreBase.Interfaces.DataProtectInterfaces;
using CoreOnion.Application.DataProtection;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;

namespace CoreOnion.Application.ServiceRegistration;

public static class CoreApplicationServiceRegistration
{
    public static void AddCoreApplicationServices(this IServiceCollection services) 
        => AddDataProtection(services);

    private static void AddDataProtection(IServiceCollection services)
    {
        IDataProtectionProvider dataProtectionProvider = DataProtectionProvider.Create(new DirectoryInfo(DataProtectionConsts.DirectoryKeyPath));
        services.AddSingleton(dataProtectionProvider);

        services.AddSingleton(sp =>
        {
            IDataProtectionProvider provider = sp.GetRequiredService<IDataProtectionProvider>();
            return provider.CreateProtector(DataProtectionConsts.MyPurpose);
        });

        services.AddSingleton<IDataProtect, DataProtect>();
    }
}
