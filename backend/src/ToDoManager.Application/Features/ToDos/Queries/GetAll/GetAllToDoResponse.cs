namespace ToDoManager.Application.Features.ToDos.Queries.GetAll;

public record GetAllToDoResponse(Guid Id, string Name, Guid StatusId);
