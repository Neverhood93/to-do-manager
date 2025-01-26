using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoManager.Application.Features.ToDos.Commands.Create;
using ToDoManager.Application.Features.ToDos.Commands.Delete;

namespace ToDoManager.API.Controllers;

[ApiController]
[Route("api/todo")]
public class ToDosController : ControllerBase
{
    private readonly IMediator _mediator;

    public ToDosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<CreateToDoResponse>> Create(CreateToDoRequest request, CancellationToken cancellationToken = default)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }




    [HttpDelete("{id:Guid}")]
    public async Task<ActionResult<DeleteToDoResponse>> Delete(Guid id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new DeleteToDoRequest(id), cancellationToken);
        return Ok(response);
    }
}
