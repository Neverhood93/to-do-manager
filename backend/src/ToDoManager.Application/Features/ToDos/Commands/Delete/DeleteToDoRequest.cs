using MediatR;

namespace ToDoManager.Application.Features.ToDos.Commands.Delete;

public record DeleteToDoRequest(Guid Id) : IRequest<DeleteToDoResponse>;