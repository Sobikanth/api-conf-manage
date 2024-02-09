namespace Domain.Entities;
public class RoomEntity : BaseAuditableEntity
{
    public int Capacity { get; set; }
    public string Available { get; set; }
    public ICollection<SessionEntity> Sessions { get; set; }
}