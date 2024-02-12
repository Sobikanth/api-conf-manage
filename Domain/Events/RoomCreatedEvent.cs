namespace Domain.Events;

public class RoomCreatedEvent(RoomEntity room) : BaseEvent
{
    public RoomEntity Room { get; } = room;
}