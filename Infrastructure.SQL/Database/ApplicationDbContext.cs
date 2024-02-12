using Application.Common.Interfaces;

using Domain.Entities;

using Infrastructure.SQL.Identity;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SQL.Database;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options), IApplicationDbContext
{
    public DbSet<RoomEntity> Rooms
    {
        get
        {
            return Set<RoomEntity>();
        }
    }

    public DbSet<SessionAttendeeEntity> SessionAttendees
    {
        get
        {
            return Set<SessionAttendeeEntity>();
        }
    }

    public DbSet<SessionEntity> Sessions
    {
        get
        {
            return Set<SessionEntity>();
        }
    }

    public DbSet<SpeakerEntity> Speakers
    {
        get
        {
            return Set<SpeakerEntity>();
        }
    }

    //Uncomment if there is any configuration for the entities
    /* protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    } */
}