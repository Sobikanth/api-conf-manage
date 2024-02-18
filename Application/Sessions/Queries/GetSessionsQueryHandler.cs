using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using Application.Common.Security;

using Domain.Constants;

namespace Application.Sessions.Queries;

[Authorize(Roles = Roles.ADMINISTRATOR)]
[Authorize(Roles = Roles.SPEAKER)]

public record GetSessionsQuery : IRequest<PaginatedList<SessionDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
};

public class GetSessionsQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetSessionsQuery, PaginatedList<SessionDto>>
{
    private readonly IApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<PaginatedList<SessionDto>> Handle(GetSessionsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Sessions
            .ProjectTo<SessionDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}