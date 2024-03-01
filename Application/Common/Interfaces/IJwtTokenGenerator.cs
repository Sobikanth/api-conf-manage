using Application.Common.Models;

namespace Application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    JwtTokenResponse GenerateToken(
        Guid userId,
        string userName,
        List<string> roles
    );
}