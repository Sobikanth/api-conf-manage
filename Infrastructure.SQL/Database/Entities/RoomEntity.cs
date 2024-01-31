namespace Infrastructure.SQL.Database.Entities;

public class RoomEntity
{
    public int Id { get; set; }
    public int Capacity { get; set; }
    public string Available { get; set; }
    
    //Navigation properties
    public ICollection<SessionEntity> Sessions { get; set; }
}