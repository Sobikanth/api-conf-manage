using Application.Common.Interfaces;

using Domain.Constants;

using Infrastructure.SQL.Database;
using Infrastructure.SQL.Database.Interceptors;
using Infrastructure.SQL.Identity;
using Infrastructure.SQL.Security.TokenGenerator;
using Infrastructure.SQL.Security.TokenValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;



namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureSQLServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

            options.UseSqlite("Data Source=Conf_Manage.sqlite");
        });


        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();
        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ApplicationDbContextInitializer>();

        services.AddAuthentication(configuration);
        // .AddBearerToken(IdentityConstants.BearerScheme);

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
    private static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.Section));

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services
            .ConfigureOptions<JwtBearerTokenValidationConfiguration>()
            .AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer();

        return services;
    }
}