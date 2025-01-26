using MediatR;

namespace ToDoManager.Application.Features.ToDoStatuses.Commands.Create;

public record CreateToDoStatusRequest(string Name) : IRequest<CreateToDoStatusResponse>;
