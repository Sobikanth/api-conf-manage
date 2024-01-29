using System.ComponentModel.DataAnnotations;

namespace Infrastructure.SQL.Database.Entities;

public class AttendeeEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string ContactNumber { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Gender { get; set; }
    public ICollection<Session_Attendee> Session_Attendees { get; set; }

}
