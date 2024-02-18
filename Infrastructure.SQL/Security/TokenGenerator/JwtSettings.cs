namespace Infrastructure.SQL.Security.TokenGenerator;

public class JwtSettings
{
    public const string SECTION = "JwtSettings";

    public string Audience { get; set; } = null!;
    public string Issuer { get; set; } = null!;
    public string Secret { get; set; } = null!;
    public int TokenExpirationInMinutes { get; set; }
}