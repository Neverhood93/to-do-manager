using AutoMapper;
using ToDoManager.Domain.Entities;

namespace ToDoManager.Application.Features.ToDos.Queries.GetAll;

public class UpdateToDoMapper : Profile
{
    public UpdateToDoMapper()
    {
        CreateMap<GetAllToDoRequest, ToDo>();
        CreateMap<ToDo, GetAllToDoResponse>();
    }
}
