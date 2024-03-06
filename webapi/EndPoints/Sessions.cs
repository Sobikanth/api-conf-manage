using Application.Common.Models;
using Application.Sessions.Commands.CreateSession;
using Application.Sessions.Commands.DeleteSession;
using Application.Sessions.Queries;

using webapi.Infrastructure;

namespace webapi.EndPoints;

public class Sessions : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetSessions)
            .MapPost(CreateSession)
        // .MapPut(UpdateSession, "{id}")
        // .MapPut(UpdateSessionDetail, "{UpdateDetail/{id}")
            .MapDelete(DeleteSession, "{id}");
    }

    public async Task<PaginatedList<SessionVmDto>> GetSessions(ISender sender, CancellationToken cancellationToken)
    {
        return await sender.Send(new GetSessionsQuery(), cancellationToken);
    }

    public async Task<string> CreateSession(ISender sender, CreateSessionCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }

    public async Task<IResult> DeleteSession(ISender sender, Guid id)
    {
        await sender.Send(new DeleteSessionCommand(id));
        return Results.NoContent();
    }
}