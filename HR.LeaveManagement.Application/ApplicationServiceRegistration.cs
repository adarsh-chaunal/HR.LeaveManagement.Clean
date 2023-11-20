using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace HR.LeaveManagement.Application;
public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly()); // looks for automapper related class and automatically register it
                                                                 // AutoMapper can have multiple mapping profile
        // services.AddMediatR(Assembly.GetExecutingAssembly()); 
        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())); // All handler and request will be registered automatically
        return services;
    }
}
