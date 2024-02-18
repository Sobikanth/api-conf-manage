using Domain.Entities;

namespace Application.Sessions.Queries;

public class SessionDto
{
    public Guid Id { get; init; }
    public string Topic { get; init; } = null!;
    public DateOnly ConfDate { get; init; }
    public TimeOnly StartTime { get; init; }
    public TimeOnly EndTime { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<SessionEntity, SessionDto>();
        }
    }
}