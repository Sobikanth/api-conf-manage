using Application.Common.Interfaces;

using AutoMapper;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace Application.Sessions.Queries;

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