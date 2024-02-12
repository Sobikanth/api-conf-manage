using MediatR;

namespace Application.Sessions.Commands.CreateSession;

public record CreateSessionCommand : IRequest<string>
{
    public string Topic { get; init; }
    public DateOnly ConfDate { get; init; }
    public TimeOnly StartTime { get; init; }
    public TimeOnly EndTime { get; init; }
    public Guid SpeakerId { get; init; }
    public Guid RoomId { get; init; }
}
