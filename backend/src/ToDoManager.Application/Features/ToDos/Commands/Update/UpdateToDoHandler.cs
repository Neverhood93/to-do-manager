using AutoMapper;
using MediatR;
using ToDoManager.Application.Features.ToDos.Commands.Update;
using ToDoManager.Application.Repositories;

public class UpdateToDoHandler : IRequestHandler<UpdateToDoInternalRequest, UpdateToDoResponse>
{
    private readonly IToDoRepository _repository;
    private readonly IMapper _mapper;

    public UpdateToDoHandler(IToDoRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UpdateToDoResponse> Handle(UpdateToDoInternalRequest request, CancellationToken cancellationToken)
    {
        var todo = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (todo == null)
        {
            throw new Exception("Not found");
        }

        todo.Name = request.Name;
        todo.StatusId = request.StatusId;
        todo.ModifiedOn = DateTime.UtcNow;

        await _repository.UpdateAsync(todo);

        return _mapper.Map<UpdateToDoResponse>(todo);
    }
}