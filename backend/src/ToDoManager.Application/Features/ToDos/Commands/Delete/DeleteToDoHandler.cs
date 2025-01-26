using AutoMapper;
using MediatR;
using ToDoManager.Application.Features.ToDos.Commands.Delete;
using ToDoManager.Application.Repositories;

public class DeleteToDoHandler : IRequestHandler<DeleteToDoRequest, DeleteToDoResponse>
{
    private readonly IToDoRepository _repository;
    private readonly IMapper _mapper;

    public DeleteToDoHandler(IToDoRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<DeleteToDoResponse> Handle(DeleteToDoRequest request, CancellationToken cancellationToken)
    {
        var todo = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (todo == null)
        {
            throw new Exception("Not found");
        }

        todo.IsDeleted = true;
        todo.ModifiedOn = DateTime.UtcNow;

        await _repository.UpdateAsync(todo);

        return _mapper.Map<DeleteToDoResponse>(todo);
    }
}