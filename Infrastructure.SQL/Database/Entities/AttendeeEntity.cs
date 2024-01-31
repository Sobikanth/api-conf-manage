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
    //Navigation properties
    // public Session_AttendeeEntity Session_AttendeeEntity { get; set; }
    public ICollection<Session_AttendeeEntity> Session_AttendeeEntities { get; set; }

}
