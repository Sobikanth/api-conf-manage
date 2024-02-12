using Application.Common.Interfaces;
using Application.Common.Security;
using Domain.Constants;
using Domain.Entities;
using Domain.Events;
using MediatR;

namespace Application.Rooms.Commands.CreateRoom;

[Authorize(Roles = Roles.Administrator)]
[Authorize(Policy = Policies.CanAdd)]
public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, Guid>
{

    private readonly IApplicationDbContext _context;

    public CreateRoomCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
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