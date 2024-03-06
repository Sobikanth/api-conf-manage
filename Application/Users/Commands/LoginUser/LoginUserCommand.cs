namespace Application.Users.Commands.LoginUser;

public record LoginUserCommand : IRequest<List<object>>
{
    public string UserName { get; init; }
    public string Password { get; init; }
}