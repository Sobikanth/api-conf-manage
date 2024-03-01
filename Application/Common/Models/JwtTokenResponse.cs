namespace Application.Common.Models;


public class JwtTokenResponse
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
    public string Type { get; set; }
}
