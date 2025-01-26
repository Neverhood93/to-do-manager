namespace ToDoManager.Application.Features.ToDos.Commands.Create;

public record CreateToDoResponse(Guid Id, string Name, Guid StatusId);