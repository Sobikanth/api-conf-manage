using Application.Rooms.Commands.CreateRoom;
using Application.Rooms.Queries;

using Microsoft.AspNetCore.Mvc;

using webapi.Infrastructure;

namespace webapi.EndPoints;

public class Rooms : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetRooms)
            .MapPost(CreateRoom);
    }

    public async Task<List<RoomDto>> GetRooms(ISender sender, CancellationToken cancellationToken)
    {
        return await sender.Send(new GetRoomsQuery(), cancellationToken);
    }

    public async Task<Guid> CreateRoom(ISender sender, [FromBody] CreateRoomCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }
}