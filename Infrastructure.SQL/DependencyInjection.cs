using Application.Common.Interfaces;
using Domain.Constants;
using Infrastructure.SQL.Database;
using Infrastructure.SQL.Database.Interceptors;
using Infrastructure.SQL.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureSQLServices(this IServiceCollection services, IConfiguration configuration)
    {
        // var connectionString = "Server=localhost;Database=clean_api_2;User Id=sa;Password=Docker@123;TrustServerCertificate=True;";
        // Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");
        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        // services.AddDbContext<ApplicationDbContext>((sp, options) =>
        // {
        //     options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

        //     options.UseSqlServer(connectionString);
        // });
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

        services.AddAuthorization(options =>
        {
            options.AddPolicy(Policies.CanPurge, policy => policy.RequireRole(Roles.Administrator));
            options.AddPolicy(Policies.CanView, policy => policy.RequireRole(Roles.Administrator));
            options.AddPolicy(Policies.CanAdd, policy => policy.RequireRole(Roles.Administrator));
            options.AddPolicy(Policies.CanEdit, policy => policy.RequireRole(Roles.Administrator));
            options.AddPolicy(Policies.CanDelete, policy => policy.RequireRole(Roles.Administrator));
        });
        return services;
    }
}