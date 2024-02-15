namespace Domain.Entities;
public class SessionEntity : BaseAuditableEntity
{
    public string Topic { get; set; }
    public DateOnly ConfDate { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public ICollection<SessionAttendeeEntity> SessionAttendeeEntities { get; set; }
    public RoomEntity RoomEntity { get; set; }
    public SpeakerEntity SpeakerEntity { get; set; }
}