using Application.Common.Interfaces;

using Domain.Constants;

using Infrastructure.SQL.Database;
using Infrastructure.SQL.Database.Interceptors;
using Infrastructure.SQL.Identity;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureSQLServices(this IServiceCollection services)
    {
        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();
        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ApplicationDbContextInitializer>();

        services.AddAuthentication()
            .AddBearerToken(IdentityConstants.BearerScheme);

        // services.AddAuthorizationBuilder();

        services
            .AddIdentityCore<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddApiEndpoints();

        services.AddSingleton(TimeProvider.System);
        services.AddTransient<IIdentityService, IdentityService>();

        services.AddAuthorizationBuilder()
            .AddPolicy(Policies.CANPURGE, policy => policy.RequireRole(Roles.ADMINISTRATOR))
            .AddPolicy(Policies.CANVIEW, policy => policy.RequireRole(Roles.ADMINISTRATOR))
            .AddPolicy(Policies.CANADD, policy => policy.RequireRole(Roles.ADMINISTRATOR))
            .AddPolicy(Policies.CANEDIT, policy => policy.RequireRole(Roles.ADMINISTRATOR))
            .AddPolicy(Policies.CANDELETE, policy => policy.RequireRole(Roles.ADMINISTRATOR));
        return services;
    }
}