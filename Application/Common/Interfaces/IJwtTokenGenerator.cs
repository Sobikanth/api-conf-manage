namespace Application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(
        Guid userId,
        string userName,
        List<string> roles
    );
}