using EHospital.Application.Dtos.Entites.DoctorSchedules;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class DoctorSchedulesController : ControllerBase
{
    private readonly IMediator _mediator;

    public DoctorSchedulesController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpPost]
    public async Task<IActionResult> CreateDoctorSchedule([FromBody] DoctorSchedulesCreateDto createDto)
    {
        if (!ModelState.IsValid) { return BadRequest(ModelState); }
        var command = new DoctorScheduleCreateCommandRequest { DoctorSchedulesCreateDto = createDto };
        var result = await _mediator.Send(command);
        return StatusCode(int.Parse(result.StatusCode), result);
    }


    [HttpPut]
    public async Task<IActionResult> UpdateDoctorSchedule([FromBody] DoctorSchedulesUpdateDto updateDto)
    {
        var command = new DoctorScheduleUpdateCommandRequest { DoctorSchedulesUpdateDto = updateDto };
        var result = await _mediator.Send(command);
        return StatusCode(int.Parse(result.StatusCode), result);
    }


    [HttpDelete]
    public async Task<IActionResult> DeleteDoctorSchedule(DoctorScheduleDeleteCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return StatusCode(int.Parse(response.StatusCode), response);
        //Response daxilindeki Status code string olduguna gore stringi intə ceviririk 
    }


    [HttpGet("schedules/{doctorName}")]
    public async Task<IActionResult> GetDoctorScheduleByName(string doctorName)
    {
        var query = new GetDoctorSchedulesByDoctorNameQuery { DoctorName = doctorName };
        var result = await _mediator.Send(query);
        if (result.StatusCode == "200")
        {
            return Ok(result);
        }
        else
        {
            return StatusCode(int.Parse(result.StatusCode), result);
        }
    }


    [HttpGet("active")]
    public async Task<IActionResult> GetActiveSchedules()
    {
        var query = new GetAllActiveDoctorSchedulesRequest();
        var result = await _mediator.Send(query);
        return StatusCode(int.Parse(result.StatusCode), result);
    }
}
