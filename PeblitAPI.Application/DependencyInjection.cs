using System.Reflection;
using CleanArchitecture.Application.Common.Behaviours;
using CleanArchitecture.Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {

        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
       //     cfg.addbehavior(typeof(ipipelinebehavior<,>), typeof(unhandledexceptionbehaviour<,>));
       //     cfg.addbehavior(typeof(ipipelinebehavior<,>), typeof(authorizationbehaviour<,>));
        //    cfg.addbehavior(typeof(ipipelinebehavior<,>), typeof(validationbehaviour<,>));
        //    cfg.addbehavior(typeof(ipipelinebehavior<,>), typeof(performancebehaviour<,>));
        });

        return services;
    }
}
