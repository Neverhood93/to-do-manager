using Microsoft.AspNetCore.Mvc;

namespace ToDoManager.API.Controllers;

[ApiController]
[Route("api/todo")]
public class ToDosController : ControllerBase
{
    public ToDosController()
    {
    }

    //[HttpPost]
    //public async Task<ActionResult<CreateToDoResponse>> Create(CreateToDoRequest request, CancellationToken cancellationToken = default)
    //{

    //    return Ok(response);
    //}

    //[HttpPost("{id:Guid}")]
    //public async Task<ActionResult<UpdateToDoResponse>> Update(Guid id, UpdateToDoInternalRequest request, CancellationToken cancellationToken)
    //{
    //    var response = await _mediator.Send(new UpdateToDoInternalRequest(id, request.Name, request.StatusId), cancellationToken);
    //    return Ok(response);
    //}

    //[HttpDelete("{id:Guid}")]
    //public async Task<ActionResult<DeleteToDoResponse>> Delete(Guid id, CancellationToken cancellationToken)
    //{
    //    var response = await _mediator.Send(new DeleteToDoRequest(id), cancellationToken);
    //    return Ok(response);
    //}
}
