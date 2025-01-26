using MediatR;

namespace ToDoManager.Application.Features.ToDos.Commands.Create;

public record CreateToDoRequest(string Name, Guid StatusId) : IRequest<CreateToDoResponse>;