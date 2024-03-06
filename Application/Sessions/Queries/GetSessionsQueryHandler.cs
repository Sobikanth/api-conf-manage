using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using Application.Common.Security;

using Domain.Constants;

namespace Application.Sessions.Queries;

[Authorize(Roles = Roles.ADMINISTRATOR)]
[Authorize(Roles = Roles.SPEAKER)]

public record GetSessionsQuery : IRequest<PaginatedList<SessionVmDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
};

public class GetSessionsQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetSessionsQuery, PaginatedList<SessionVmDto>>
{
    private readonly IApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<PaginatedList<SessionVmDto>> Handle(GetSessionsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Sessions
            .ProjectTo<SessionVmDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
    }
}