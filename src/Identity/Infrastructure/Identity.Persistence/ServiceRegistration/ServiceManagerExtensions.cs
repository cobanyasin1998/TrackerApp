using Identity.Application.Abstractions.UnitOfWork;
using Identity.Persistence.DbContexts;
using Identity.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Persistence.ServiceRegistration;

public static class ServiceManagerExtensions
{
    public static void IdentityPersistenceAddServices(this IServiceCollection services, IConfiguration configuration)
    {
        DatabaseConnection(services, configuration);
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    private static void DatabaseConnection(IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("IdentityDatabase")!;

        services.AddDbContext<IdentityDbContext>(opt =>
        {
            opt.UseSqlServer(connectionString);
        });
    }
}
