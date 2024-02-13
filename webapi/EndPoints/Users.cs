using Application.Users.Commands.LoginUser;
using Application.Users.Commands.RegisterUser;

using webapi.Infrastructure;

namespace webapi.EndPoints;

public class Users : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(RegisterUser, "register")
            .MapPost(LoginUser, "login");
    }

    public async Task<Guid> RegisterUser(ISender sender, RegisterUserCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }

    public async Task<string> LoginUser(ISender sender, LoginUserCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }
}