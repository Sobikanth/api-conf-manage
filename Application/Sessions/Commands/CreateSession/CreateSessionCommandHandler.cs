using Application.Common.Interfaces;

using Domain.Entities;


namespace Application.Sessions.Commands.CreateSession;

public class CreateSessionCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateSessionCommand, string>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<string> Handle(CreateSessionCommand request, CancellationToken cancellationToken)
    {
#pragma warning disable CS8601 // Possible null reference assignment.
        var entity = new SessionEntity
        {
            Topic = request.Topic,
            ConfDate = request.ConfDate,
            StartTime = request.StartTime,
            EndTime = request.EndTime,
            SpeakerEntity = _context.Speakers.Find(request.SpeakerId),
            RoomEntity = _context.Rooms.Find(request.RoomId)
        };
#pragma warning restore CS8601 // Possible null reference assignment.
        // entity.AddDomainEvent(new SessionCreatedEvent(entity));
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Topic;
    }
}