using AutoMapper;
using MediatR;
using ToDoManager.Application.Features.ToDos.Commands.Create;
using ToDoManager.Application.Repositories;
using ToDoManager.Domain.Entities;

public class CreateToDoHandler : IRequestHandler<CreateToDoRequest, CreateToDoResponse>
{
    private readonly IToDoRepository _repository;
    private readonly IMapper _mapper;

    public CreateToDoHandler(IToDoRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CreateToDoResponse> Handle(CreateToDoRequest request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<ToDo>(request);
        entity.CreatedOn = DateTime.UtcNow;

        await _repository.CreateAsync(entity);
        return _mapper.Map<CreateToDoResponse>(entity);
    }
}