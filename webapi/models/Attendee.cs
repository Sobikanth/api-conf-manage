using System.ComponentModel.DataAnnotations;

namespace webapi.models;

public class Attendee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ContactNumber { get; set; }
    public string Email { get; set; }
    public string Gender { get; set; }
}