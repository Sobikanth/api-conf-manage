using Microsoft.AspNetCore.Identity;

namespace Infrastructure.SQL.Identity;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }

}