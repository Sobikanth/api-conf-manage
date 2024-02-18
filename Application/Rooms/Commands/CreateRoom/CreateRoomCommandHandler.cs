using Application.Common.Interfaces;

using Domain.Entities;

namespace Application.Rooms.Commands.CreateRoom;

public class CreateRoomCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateRoomCommand, Guid>
{

    private readonly IApplicationDbContext _context = context;

    public async Task<Guid> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        var entity = new RoomEntity
        {
            Capacity = request.Capacity,
            Available = request.Available
        };
        // entity.AddDomainEvent(new RoomCreatedEvent(entity));
        _context.Rooms.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}