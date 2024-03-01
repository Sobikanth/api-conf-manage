using Application.Common.Models;

namespace Application.Users.Commands.LoginUser;

public record LoginUserCommand : IRequest<JwtTokenResponse>
{
    public string UserName { get; init; }
    public string Password { get; init; }
}