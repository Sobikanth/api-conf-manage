using Application.Sessions.Commands.CreateSession;
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
            .MapPost(CreateSession);
        // .MapPut(UpdateSession, "{id}")
        // .MapPut(UpdateSessionDetail, "{UpdateDetail/{id}");
    }

    public async Task<SessionDto> GetSessions(ISender sender, CancellationToken cancellationToken)
    {
        return await sender.Send(new GetSessionsQuery(), cancellationToken);
    }

    public async Task<string> CreateSession(ISender sender, CreateSessionCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }
}