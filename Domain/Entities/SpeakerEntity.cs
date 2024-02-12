namespace Domain.Entities;
public class SpeakerEntity : BaseAuditableEntity
{
    // public string FirstName { get; set; }
    // public string LastName { get; set; }
    // public string ContactNumber { get; set; }
    // public string Email { get; set; }
    // public string Gender { get; set; }
    public string University { get; set; }
    public string JobTitle { get; set; }
    public ICollection<SessionEntity> Sessions { get; set; }
}