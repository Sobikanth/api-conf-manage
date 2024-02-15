using MediatR;

namespace Application.Speaker.Commands.CreateSpeaker;

public class CreateSpeakerCommand : IRequest<string>
{
    public Guid Id { get; init; }
    public string? University { get; init; }
    public string? JobTitle { get; init; }
}