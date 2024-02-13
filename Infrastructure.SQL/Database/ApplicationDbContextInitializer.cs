using Domain.Constants;

using Infrastructure.SQL.Identity;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infrastructure.SQL.Database;

public static class InitializerExtensions
{
    public static async Task InitializeDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initializer = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitializer>();

        await initializer.InitializeAsync();

        await initializer.SeedAsync();
    }
}

public class ApplicationDbContextInitializer(
    ApplicationDbContext context,
    UserManager<ApplicationUser> userManager,
    RoleManager<IdentityRole> roleManager,
    ILogger<ApplicationDbContextInitializer> logger)
{
    private readonly ILogger<ApplicationDbContextInitializer> _logger = logger;
    private readonly ApplicationDbContext _context = context;
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly RoleManager<IdentityRole> _roleManager = roleManager;

    public async Task InitializeAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initializing the database.");
            throw;
        }
    }
    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }
    public async Task TrySeedAsync()
    {
        // Default roles
        var administratorRole = new IdentityRole(Roles.ADMINISTRATOR);
        var speakerRole = new IdentityRole(Roles.SPEAKER);
        var attendeeRole = new IdentityRole(Roles.ATTENDEE);

        if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await _roleManager.CreateAsync(administratorRole);
        }
        if (_roleManager.Roles.All(r => r.Name != speakerRole.Name))
        {
            await _roleManager.CreateAsync(speakerRole);
        }
        if (_roleManager.Roles.All(r => r.Name != attendeeRole.Name))
        {
            await _roleManager.CreateAsync(attendeeRole);
        }

        // Default users
        var administrator = new ApplicationUser { UserName = "administrator@gmail.com", Email = "administrator@gmail.com", FirstName = "Admin", LastName = "Admin", PhoneNumber = "123456789", Gender = "Female" };

        if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await _userManager.CreateAsync(administrator, "Administrator@123");
            if (!string.IsNullOrWhiteSpace(administratorRole.Name))
            {
                await _userManager.AddToRolesAsync(administrator, [administratorRole.Name]);
            }
        }
    }
}