using MediatR;

namespace ToDoManager.Application.Features.ToDos.Queries.GetAll;

public record GetAllToDoRequest() : IRequest<IEnumerable<GetAllToDoResponse>>;
