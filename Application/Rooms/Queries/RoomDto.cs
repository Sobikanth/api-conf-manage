using AutoMapper;

using Domain.Entities;

namespace Application.Rooms.Queries;

public class RoomDto
{
    public Guid Id { get; set; }
    public int Capacity { get; set; }
    public string? Available { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<RoomEntity, RoomDto>();
        }
    }
}