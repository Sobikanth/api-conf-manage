using Application.Common.Security;

using Domain.Constants;

namespace Application.Rooms.Commands.CreateRoom;

[Authorize(Roles = Roles.ADMINISTRATOR)]


public record CreateRoomCommand : IRequest<Guid>
{
    public int Capacity { get; init; }
    public string Available { get; init; } = null!;
}