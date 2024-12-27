using CoreBase.Interfaces.BusinessInterfaces;
using CoreOnion.Application.Mediatr.Pipelines;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Identity.Application.ServiceRegistration;

public static class ServiceManagerExtensions
{
    public static void IdentityApplicationAddServices(this IServiceCollection services)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();

        services.AddAutoMapper(assembly);
        services.AddMediatR(conf =>
        {
            conf.RegisterServicesFromAssembly(assembly);
            conf.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
            conf.AddOpenBehavior(typeof(DataProtectionBehavior<,>));

        });

        services.AddBusinessRules(assembly);
        services.AddValidatorsFromAssembly(assembly);


    }

    private static void AddBusinessRules(this IServiceCollection services, Assembly assembly)
    {
        Type[]? types = assembly.GetTypes();

        IEnumerable<Type>? businessRuleTypes = types
            .Where(type => type.IsClass && !type.IsAbstract && typeof(IBaseBusinessRule).IsAssignableFrom(type));

        foreach (Type? type in businessRuleTypes)
        {
            Type? interfaceType = type.GetInterfaces()
                .FirstOrDefault(i => typeof(IBaseBusinessRule).IsAssignableFrom(i) && i != typeof(IBaseBusinessRule));

            if (interfaceType is not null)
                services.AddScoped(interfaceType, type);
        }
    }
}
