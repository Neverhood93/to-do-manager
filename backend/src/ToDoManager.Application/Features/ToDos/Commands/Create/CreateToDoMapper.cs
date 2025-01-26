using AutoMapper;
using ToDoManager.Domain.Entities;

namespace ToDoManager.Application.Features.ToDos.Commands.Create;

public class CreateToDoMapper : Profile
{
    public CreateToDoMapper()
    {
        CreateMap<CreateToDoRequest, ToDo>();
        CreateMap<ToDo, CreateToDoResponse>();
    }
}
