using MediatR;

namespace ToDoManager.Application.Features.ToDos.Commands.Update;

public record UpdateToDoRequest(string Name, Guid StatusId);

public sealed record UpdateToDoInternalRequest(Guid Id, string Name, Guid StatusId) : IRequest<UpdateToDoResponse>;