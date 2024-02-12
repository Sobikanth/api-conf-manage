using MediatR;

namespace Application.Rooms.Commands.CreateRoom;

public record CreateRoomCommand : IRequest<Guid>
{
    public int Capacity { get; init; }
    public string Available { get; init; }
}