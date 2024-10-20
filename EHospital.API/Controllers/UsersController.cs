using Azure.Core;
using EHospital.Application.Dtos.Auth.User;
using EHospital.Application.Exceptions;
using EHospital.Application.Futures.Commands.AppUser.Create;
using EHospital.Application.Futures.Commands.AppUser.Login;
using EHospital.Application.Futures.Queries.AppUser.GetAllUserQuery;
using EHospital.Application.Futures.Queries.AppUser.GetByIdUserQuery;
using EHospital.Application.Futures.Queries.AppUser.GetSerialNumberUserQuery;
using EHospital.Domain.Entities.Auth;
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
        try
        {
            var response = await _mediator.Send(userCreateRequest);
            return Ok(response);
        }
        catch (BusinessRuleException ex)
        {
            return Conflict(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }   

    [HttpPost("Login")]
    public async Task<IActionResult> Login(UserLoginRequest userLoginRequest) 
    {
        var response = await _mediator.Send(userLoginRequest);
        return Ok(response);
    }
    [HttpGet("GetAll")]
    public async Task<IEnumerable<GetUserDto>> GetAllUser() 
    {
        var getAllUserQueryRequest = new GetAllUserQueryRequest();
        var response = await _mediator.Send(getAllUserQueryRequest);
        return response.Users;
    }
    [HttpGet("GetById")]
    public async Task<GetUserDto> GetByIdUser(int userId ) 
    {
        var request = new GetUserByIdQueryRequest { UserId = userId };
        var response = await _mediator.Send(request);
        return response.User;
    }
    [HttpGet("GetBySerialNumber/{serialNumber}")]
    public async Task<GetUserDto> GetBySerialNumberUser(string serialNumber)
    {
        var request = new GetUserBySerialNumberQueryRequest { SerialNumber = serialNumber };
        var response = await _mediator.Send(request);

        return response.User;
    }

}
