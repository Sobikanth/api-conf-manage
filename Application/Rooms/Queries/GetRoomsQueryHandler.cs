using Application.Common.Interfaces;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace Application.Rooms.Queries;

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