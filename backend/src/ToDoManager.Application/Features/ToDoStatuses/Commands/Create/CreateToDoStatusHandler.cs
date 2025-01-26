using AutoMapper;
using MediatR;
using ToDoManager.Application.Repositories;
using ToDoManager.Domain.Entities;

namespace ToDoManager.Application.Features.ToDoStatuses.Commands.Create;

public class CreateToDoStatusHandler : IRequestHandler<CreateToDoStatusRequest, CreateToDoStatusResponse>
{
    private readonly IToDoStatusRepository _repository;
    private readonly IMapper _mapper;

    public CreateToDoStatusHandler(IToDoStatusRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CreateToDoStatusResponse> Handle(CreateToDoStatusRequest request, CancellationToken cancellationToken)
    {
        var status = _mapper.Map<ToDoStatus>(request);
        status.CreatedOn = DateTime.UtcNow;

        await _repository.CreateAsync(status);

        return _mapper.Map<CreateToDoStatusResponse>(status);
    }
}
