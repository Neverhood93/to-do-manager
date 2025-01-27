using AutoMapper;
using ToDoManager.Domain.Entities;

namespace ToDoManager.Application.Features.ToDos.Commands.Update;

public class UpdateToDoMapper : Profile
{
    public UpdateToDoMapper()
    {
        CreateMap<UpdateToDoInternalRequest, ToDo>();
        CreateMap<ToDo, UpdateToDoResponse>();
    }
}
