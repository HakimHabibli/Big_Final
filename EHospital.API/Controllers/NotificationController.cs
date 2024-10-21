using EHospital.Application.Dtos.Entites.DoctorSchedules;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EHospital.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotificationController : ControllerBase
{
    private readonly IMediator _mediator;

    public NotificationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("active-doctor-schedules")]
    public async Task<IActionResult> GetActiveDoctorSchedules()
    {
        var query = new GetActiveDoctorSchedulesQuery();
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpGet("user-deactivated-schedules/{userId}")]
    public async Task<IActionResult> GetUserDeactivatedSchedules(int userId)
    {
        var query = new GetUserDeactivatedSchedulesQueryRequest { UserId = userId };
        var response = await _mediator.Send(query);
        return Ok(response.userDeactivatedScheduleReadDtos);
    }

    [HttpPost("deactivate-doctor-schedule")]
    public async Task<IActionResult> DeactivateDoctorSchedule([FromBody] UserScheduleDeactivateDto dto)
    {
        var request = new DeactivateDoctorScheduleCommandRequest
        {
            UserScheduleDeactivateDto = dto
        };
        var response = await _mediator.Send(request);
        return StatusCode(int.Parse(response.StatusCode), "Doctor schedule deactivated successfully.");
    }

    [HttpPost("reactivate-doctor-schedule")]
    public async Task<IActionResult> ReactivateDoctorSchedule([FromBody] UserScheduleReactivateDto dto)
    {
        var request = new ReactivateDoctorScheduleCommand { ReactivateDto =  dto };
        var response = await _mediator.Send(request);
        return StatusCode(int.Parse(response.StatusCode), "Doctor schedule reactivated successfully.");
    }
}
