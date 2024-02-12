using Application.Common.Interfaces;
using Application.Common.Security;

using Domain.Constants;
using Domain.Entities;

using MediatR;

namespace Application.Sessions.Commands.CreateSession;

[Authorize(Roles = Roles.ADMINISTRATOR)]
public class CreateSessionCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateSessionCommand, string>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<string> Handle(CreateSessionCommand request, CancellationToken cancellationToken)
    {
        var entity = new SessionEntity
        {
            Topic = request.Topic,
            ConfDate = request.ConfDate,
            StartTime = request.StartTime,
            EndTime = request.EndTime,
            SpeakerEntity = _context.Speakers.Find(request.SpeakerId),
            RoomEntity = _context.Rooms.Find(request.RoomId)
        };
        // entity.AddDomainEvent(new SessionCreatedEvent(entity));
        _context.Sessions.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Topic;
    }
}