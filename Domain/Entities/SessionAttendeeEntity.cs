using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;
public class SessionAttendeeEntity : BaseAuditableEntity
{
    [ForeignKey("AttendeeId")]
    public Guid UserId { get; set; }
    // public AttendeeEntity AttendeeEntity { get; set; }
    public SessionEntity SessionEntity { get; set; }
}