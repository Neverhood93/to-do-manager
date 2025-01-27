using Microsoft.AspNetCore.Mvc;

namespace ToDoManager.API.Controllers;

[ApiController]
[Route("api/todo-statuses")]
public class ToDoStatusesController : ControllerBase
{
    public ToDoStatusesController()
    {
    }

    //[HttpPost]
    //public async Task<ActionResult<CreateToDoStatusResponse>> Create(CreateToDoStatusRequest request, CancellationToken cancellationToken = default)
    //{
    //    var response = await _mediator.Send(request, cancellationToken);
    //    return Ok(response);
    //}
}
