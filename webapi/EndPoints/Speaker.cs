using Application.Speaker.Commands.CreateSpeaker;

using webapi.Infrastructure;

namespace webapi.EndPoints;

public class Speaker : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapPost(CreateSpeaker);
    }
    public async Task<string> CreateSpeaker(ISender sender, CreateSpeakerCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }
}