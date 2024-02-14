using MediatR;

namespace Application.Users.Commands.LoginUser;

public record LoginUserCommand : IRequest<string>
{
    public string UserName { get; init; }
    public string Password { get; init; }
}