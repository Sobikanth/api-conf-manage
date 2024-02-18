using Application.Common.Interfaces;

namespace Application.Users.Commands.LoginUser;

public class LogInUserCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IIdentityService identityService) : IRequestHandler<LoginUserCommand, string>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;

    private readonly IIdentityService _identityService = identityService;

    public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var userId = await _identityService.GetUserIdAsync(request.UserName, request.Password) ?? throw new UnauthorizedAccessException();
        var roles = await _identityService.GetUserRolesAsync(userId);

        var token = _jwtTokenGenerator.GenerateToken(new Guid(userId), request.UserName, roles);
        return token;
    }
}
