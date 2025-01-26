using AutoMapper;
using ToDoManager.Domain.Entities;

namespace ToDoManager.Application.Features.ToDoStatuses.Commands.Create;

public class CreateToDoStatusMapper : Profile
{
    public CreateToDoStatusMapper()
    {
        CreateMap<CreateToDoStatusRequest, ToDoStatus>();
        CreateMap<ToDoStatus, CreateToDoStatusResponse>();
    }
}
