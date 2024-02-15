using Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<RoomEntity> Rooms { get; }
    DbSet<SessionAttendeeEntity> SessionAttendees { get; }
    DbSet<SessionEntity> Sessions { get; }
    DbSet<SpeakerEntity> Speakers { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}