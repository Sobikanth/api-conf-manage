using Application.Speaker.Commands.CreateSpeaker;

using webapi.Infrastructure;

namespace webapi.EndPoints;

public class Speaker : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            // .MapGet(GetSpeakers)
            // .MapGet(GetSpeaker, "{id}");
            .MapPost(CreateSpeaker);
    }

    // public async Task<List<SpeakerDto>> GetSpeakers(ISender sender, CancellationToken cancellationToken)
    // {
    //     return await sender.Send(new GetSpeakersQuery());
    // }

    // public async Task<SpeakerDto> GetSpeaker(ISender sender, GetSpeakerQuery query, CancellationToken cancellationToken)
    // {
    //     return await sender.Send(query, cancellationToken);
    // }

    public async Task<string> CreateSpeaker(ISender sender, CreateSpeakerCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }
}