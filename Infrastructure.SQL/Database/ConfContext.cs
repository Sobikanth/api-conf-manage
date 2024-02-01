using Infrastructure.SQL.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SQL.Database;

public class ConfContext : DbContext
{
    public ConfContext(DbContextOptions<ConfContext> options) : base(options)
    {
    }

    public DbSet<AttendeeEntity> Attendees { get; set; }
    public DbSet<RoomEntity> Rooms { get; set; }
    public DbSet<Session_AttendeeEntity> Session_AttendeeEntities { get; set; }
    public DbSet<SessionEntity> Sessions { get; set; }
    public DbSet<SpeakerEntity> Speakers { get; set; }
    public DbSet<OrganizerEntity> Organizers { get; set; }

}