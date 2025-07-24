using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartTripPlanner_Core.ServicesContracts.Authentication;


public static class CoreDIContainer
{
    public static void AddCoreServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ISignUpService, SignUpService>();
    }
}
