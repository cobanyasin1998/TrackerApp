using Identity.Application.Features.User.Rules.Abstractions;
using Identity.Application.Features.User.Rules.Concretes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Identity.Application.ServiceRegistration;

public static class ServiceManagerExtensions
{
    public static void IdentityApplicationAddServices(this IServiceCollection services)
    {

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(conf =>
        {
            conf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            
        });

        services.AddScoped<IUserBusinessRule,UserBusinessRule>();


    }
}
