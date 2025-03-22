using AutoMapper;
using TodoApi.Domain.Entity;

namespace TodoApi.Dtos.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Todo, CreateTodoDto>().ReverseMap();
        CreateMap<Todo, UpdateTodoDto>().ReverseMap();
    }
}
