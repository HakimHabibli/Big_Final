using EHospital.Application.Futures.Commands.AppUser.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EHospital.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> CreateUser(UserCreateRequest userCreateRequest) 
    {
        UserCreateResponse response = await _mediator.Send(userCreateRequest);
        return Ok(response);
    }
}
