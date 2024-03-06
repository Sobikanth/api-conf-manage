using Domain.Entities;

namespace Application.Sessions.Queries;

public class SessionVmDto
{
    public Guid Id { get; init; }
    public string Topic { get; init; } = null!;
    public DateOnly ConfDate { get; init; }
    public TimeOnly StartTime { get; init; }
    public TimeOnly EndTime { get; init; }
    public SpeakerEntity SpeakerEntity { get; init; } = null!;
    public RoomEntity RoomEntity { get; init; } = null!;

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<SessionEntity, SessionVmDto>();
        }
    }
}