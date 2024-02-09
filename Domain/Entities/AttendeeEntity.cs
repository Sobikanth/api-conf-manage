namespace Domain.Entities;
public class AttendeeEntity : BaseAuditableEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ContactNumber { get; set; }
    public string Email { get; set; }
    public string Gender { get; set; }
    public ICollection<SessionAttendeeEntity> SessionAttendeeEntities { get; set; }
}
