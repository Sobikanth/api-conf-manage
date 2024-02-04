using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SQL.Database;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        SeedRoles(builder);
    }
    private static void SeedRoles(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "1"
            },
            new IdentityRole
            {
                Name = "RoomCoordinator",
                NormalizedName = "ROOMCOORDINATOR",
                ConcurrencyStamp = "2"
            },
            new IdentityRole
            {
                Name = "Speaker",
                NormalizedName = "SPEAKER",
                ConcurrencyStamp = "3"
            },
            new IdentityRole
            {
                Name = "Attendee",
                NormalizedName = "ATTENDEE",
                ConcurrencyStamp = "4"
            }
        );
    }
}