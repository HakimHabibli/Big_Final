using EHospital.Application.Futures.Commands.UserRole.AddRole;
using EHospital.Application.Futures.Commands.UserRole.DeleteRole;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
//[Authorize(Policy ="ADMIN")]
public class RolesController : ControllerBase
{
    private readonly IMediator _mediator;

    public RolesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("AddRoleToUser")]
    public async Task<IActionResult> AddRoleToUser([FromBody] AddRoleToUserCommandRequest request)
    {
        var result = await _mediator.Send(request);
        if (result.Success)
        {
            return Ok(new { message = "Rol istifadəçiyə uğurla əlavə edildi." });
        }
        throw new Exception();
    }

    [HttpPost("RemoveRoleFromUser")]
    public async Task<IActionResult> RemoveRoleFromUser([FromBody] RemoveRoleFromUserCommandRequest request)
    {
        var response = await _mediator.Send(request);
        if (response.Success)
        {
            return Ok(new { message = response.Message });
        }
        return BadRequest(new { message = response.Message });
    }
}
