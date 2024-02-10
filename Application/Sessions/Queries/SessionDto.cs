using AutoMapper;
using Domain.Entities;

namespace Application.Sessions.Queries;

public class SessionDto
{
    public Guid Id { get; init; }
    public string Topic { get; init; }
    public DateOnly ConfDate { get; init; }
    public TimeOnly StartTime { get; init; }
    public TimeOnly EndTime { get; init; }
    public SpeakerEntity Speaker { get; init; }
    public RoomEntity Room { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<SessionEntity, SessionDto>();
        }
    }
}