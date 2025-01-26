using MediatR;
using ToDoManager.Application.Features.ToDoStatuses.Commands.Create;
using Microsoft.AspNetCore.Mvc;

namespace ToDoManager.API.Controllers;

[ApiController]
[Route("api/todo-statuses")]
public class ToDoStatusesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ToDoStatusesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<CreateToDoStatusResponse>> Create(CreateToDoStatusRequest request, CancellationToken cancellationToken = default)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
