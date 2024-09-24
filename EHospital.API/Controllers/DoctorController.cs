using EHospital.Application.Dtos.Entites.Doctor;
using EHospital.Application.Futures.Commands.Doctor.Create;
using EHospital.Application.Futures.Commands.Doctor.Delete;
using EHospital.Application.Futures.Commands.Doctor.Update;
using EHospital.Application.Futures.Queries.Doctor.GetAllDoctors;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace EHospital.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DoctorController : ControllerBase
{
    private readonly IMediator _mediator;

    public DoctorController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // Create api/<DoctorController>
    [HttpPost]
    public async Task<IActionResult> CreateDoctorAsync([FromBody] DoctorCreateRequest request)
    {
        var response = await _mediator.Send(request);
        return StatusCode(200, "Succesfully");
    }

    [HttpGet]
    public async Task<IActionResult> GetAllDoctors()
    {
        var query = new GetAllDoctorQueryRequest();
        var response = await _mediator.Send(query);

        return Ok(response.DoctorReadDtos);
    }


    [HttpPut]
    public async Task<IActionResult> UpdateDoctor([FromBody] DoctorUpdateDto doctorUpdateDto)
    {
        if (doctorUpdateDto == null || doctorUpdateDto.Id <= 0)
        {
            return BadRequest("Doctor ID is invalid or missing.");
        }

        // MediatR vasitəsilə sorğunu göndəririk
        var request = new DoctorUpdateRequest { DoctorUpdateDto = doctorUpdateDto };
        var response = await _mediator.Send(request);

        // Əgər uğurlu olarsa, 204 (No Content) qaytarırıq
        if (response.StatusCode == "204")
        {
            return NoContent();
        }

        return StatusCode(500, "An error occurred while updating the doctor.");
    }



    // DELETE api/<DoctorController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(DoctorDeleteRequest request)
    {
        var response = await _mediator.Send(request);
        return StatusCode(204, "ChangeSuccesfully");
    }
}
