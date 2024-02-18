using Application.Common.Interfaces;

using Domain.Constants;
using Domain.Entities;

namespace Application.Speaker.Commands.CreateSpeaker;

public class CreateSpeakerCommandHandler(IApplicationDbContext context, IIdentityService identityService) : IRequestHandler<CreateSpeakerCommand, string>
{
    private readonly IApplicationDbContext _context = context;
    private readonly IIdentityService _identityService = identityService;

    public async Task<string> Handle(CreateSpeakerCommand request, CancellationToken cancellationToken)
    {
        var entity = new SpeakerEntity
        {
            Id = request.Id,
            University = request.University!,
            JobTitle = request.JobTitle!
        };
        _context.Speakers.Add(entity);
        await _identityService.AddToRoleAsync(request.Id.ToString(), Roles.SPEAKER);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.University!;
    }
}