using Application.Common.Interfaces;
using Application.Common.Security;

using Domain.Constants;

namespace Application.Rooms.Queries;

[Authorize(Roles = Roles.ADMINISTRATOR)]
[Authorize(Roles = Roles.SPEAKER)]

public record GetRoomsQuery : IRequest<List<RoomDto>>;

public class GetRoomsQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetRoomsQuery, List<RoomDto>>
{
    private readonly IApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<List<RoomDto>> Handle(GetRoomsQuery request, CancellationToken cancellationToken)
    {
        var rooms = await _context.Rooms
            .ProjectTo<RoomDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken: cancellationToken);
        return rooms;
    }
}