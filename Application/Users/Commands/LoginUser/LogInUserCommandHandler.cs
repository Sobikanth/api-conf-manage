using Application.Common.Interfaces;
using Application.Common.Models;
using MediatR;

namespace Application.Users.Commands.LoginUser;

public class LogInUserCommandHandler : IRequestHandler<LoginUserCommand, string>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    private readonly IIdentityService _identityService;

    public LogInUserCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IIdentityService identityService)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _identityService = identityService;
    }
    public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var userId = await _identityService.GetUserIdAsync(request.UserName, request.Password);

        if (userId == null)
        {
            throw new UnauthorizedAccessException();
        }

        var roles = await _identityService.GetUserRolesAsync(userId);

        string token = _jwtTokenGenerator.GenerateToken(new Guid(userId), request.UserName, roles);
        return token;
    }
}
