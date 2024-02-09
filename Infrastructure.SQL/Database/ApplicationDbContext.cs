using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.SQL.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SQL.Database;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<AttendeeEntity> Attendees => Set<AttendeeEntity>();

    public DbSet<OrganizerEntity> Organizers => Set<OrganizerEntity>();

    public DbSet<RoomEntity> Rooms => Set<RoomEntity>();

    public DbSet<SessionAttendeeEntity> SessionAttendees => Set<SessionAttendeeEntity>();

    public DbSet<SessionEntity> Sessions => Set<SessionEntity>();

    public DbSet<SpeakerEntity> Speakers => Set<SpeakerEntity>();

    //Uncomment if there is any configuration for the entities
    /* protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    } */
}