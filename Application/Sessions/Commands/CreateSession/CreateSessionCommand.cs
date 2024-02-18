using Application.Common.Security;

using Domain.Constants;

namespace Application.Sessions.Commands.CreateSession;

[Authorize(Roles = Roles.ADMINISTRATOR)]

public record CreateSessionCommand : IRequest<string>
{
    public string Topic { get; init; } = null!;
    public DateOnly ConfDate { get; init; }
    public TimeOnly StartTime { get; init; }
    public TimeOnly EndTime { get; init; }
    public Guid SpeakerId { get; init; }
    public Guid RoomId { get; init; }
}
