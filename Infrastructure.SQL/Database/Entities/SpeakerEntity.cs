using System.ComponentModel.DataAnnotations;

namespace Infrastructure.SQL.Database.Entities;

public class SpeakerEntity
{
    // public int Id { get; set; }
    [Key]
    public Guid SpeakerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ContactNumber { get; set; }
    public string Email { get; set; }
    public string Gender { get; set; }
    public string University { get; set; }
    public string JobTitle { get; set; }

    //Navigation properties
    public ICollection<SessionEntity> Sessions { get; set; }
}