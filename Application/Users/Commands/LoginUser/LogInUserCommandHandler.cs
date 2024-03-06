using Application.Common.Interfaces;

namespace Application.Users.Commands.LoginUser;

public class LogInUserCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IIdentityService identityService) : IRequestHandler<LoginUserCommand, List<object>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;

    private readonly IIdentityService _identityService = identityService;

    public async Task<List<object>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var userId = await _identityService.GetUserIdAsync(request.UserName, request.Password) ?? throw new UnauthorizedAccessException();
        var roles = await _identityService.GetUserRolesAsync(userId);

        var tokenResponse = _jwtTokenGenerator.GenerateToken(new Guid(userId), request.UserName, roles);

        var user = await _identityService.GetUserAsync(userId);
        return [tokenResponse, user];
    }
}
