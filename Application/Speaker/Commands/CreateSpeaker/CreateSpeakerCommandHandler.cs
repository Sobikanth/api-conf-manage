using Application.Common.Interfaces;
using Application.Common.Security;

using Domain.Constants;
using Domain.Entities;

using MediatR;

namespace Application.Speaker.Commands.CreateSpeaker;

[Authorize(Roles = Roles.ADMINISTRATOR)]
public record CreateSpeakerCommand : IRequest<string>
{
    public Guid Id { get; init; }
    public string University { get; init; }
    public string JobTitle { get; init; }

}

public class CreateSpeakerCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateSpeakerCommand, string>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<string> Handle(CreateSpeakerCommand request, CancellationToken cancellationToken)
    {
        var entity = new SpeakerEntity
        {
            Id = request.Id,
            University = request.University,
            JobTitle = request.JobTitle
        };
        _context.Speakers.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.University;
    }
}