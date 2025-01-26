using AutoMapper;
using ToDoManager.Domain.Entities;

namespace ToDoManager.Application.Features.ToDos.Commands.Delete;

public class DeleteToDoMapper : Profile
{
    public DeleteToDoMapper()
    {
        CreateMap<DeleteToDoRequest, ToDo>();
        CreateMap<ToDo, DeleteToDoResponse>();
    }
}
