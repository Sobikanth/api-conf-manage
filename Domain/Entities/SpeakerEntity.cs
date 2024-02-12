namespace Domain.Entities;
public class SpeakerEntity : BaseAuditableEntity
{
    public string University { get; set; }
    public string JobTitle { get; set; }
    public ICollection<SessionEntity> Sessions { get; set; }
}