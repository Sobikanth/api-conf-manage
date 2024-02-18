using Application.Common.Interfaces;
using Application.Common.Security;

using Domain.Constants;

namespace Application.Sessions.Queries;

[Authorize(Roles = Roles.ADMINISTRATOR)]
[Authorize(Roles = Roles.SPEAKER)]

public record GetSessionsQuery : IRequest<SessionDto>;

public class GetSessionsQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetSessionsQuery, SessionDto>
{
    private readonly IApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<SessionDto> Handle(GetSessionsQuery request, CancellationToken cancellationToken)
    {
        var session = await _context.Sessions
            .Include(s => s.SpeakerEntity)
            .Include(s => s.RoomEntity)
            .FirstOrDefaultAsync(cancellationToken);
        return _mapper.Map<SessionDto>(session);
    }
}