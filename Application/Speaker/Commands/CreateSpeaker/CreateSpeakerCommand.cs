using Application.Common.Security;

using Domain.Constants;

namespace Application.Speaker.Commands.CreateSpeaker;

[Authorize(Roles = Roles.ADMINISTRATOR)]

public class CreateSpeakerCommand : IRequest<string>
{
    public Guid Id { get; init; }
    public string? University { get; init; }
    public string? JobTitle { get; init; }
}