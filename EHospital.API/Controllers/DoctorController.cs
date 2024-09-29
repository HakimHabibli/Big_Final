using EHospital.Application.Dtos.Entites.Doctor;
using EHospital.Application.Exceptions;
using EHospital.Application.Futures.Commands.Doctor.Create;
using EHospital.Application.Futures.Commands.Doctor.Delete;
using EHospital.Application.Futures.Commands.Doctor.Update;
using EHospital.Application.Futures.Queries.Doctor.GetAllDoctors;
using EHospital.Application.Futures.Queries.Doctor.GetAllPatientsByDoctorId;
using EHospital.Application.Futures.Queries.Doctor.GetDoctorById;
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



    // POST api/<DoctorController>
    [HttpPost]
    public async Task<IActionResult> CreateDoctor([FromBody] DoctorCreateDto doctorCreateDto)
    {
        var request = new DoctorCreateRequest { DoctorCreateDto = doctorCreateDto };
        var response = await _mediator.Send(request);
        return StatusCode(StatusCodes.Status201Created, "Successfully created doctor.");
    }


    [HttpGet]
    public async Task<IActionResult> GetAllDoctors()
    {
        var query = new GetAllDoctorQueryRequest();
        var response = await _mediator.Send(query);

        return Ok(response.DoctorReadDtos);
    }


    // PUT api/<DoctorController>
    [HttpPut]
    public async Task<IActionResult> UpdateDoctor([FromBody] DoctorUpdateDto doctorUpdateDto)
    {
        if (doctorUpdateDto == null || doctorUpdateDto.Id <= 0)
        {
            throw new ValidationException("Invalid Doctor Id");
        }
        var request = new DoctorUpdateRequest { DoctorUpdateDto = doctorUpdateDto };
        var response = await _mediator.Send(request);
        return NoContent();
    }
    // DELETE api/<DoctorController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(DoctorDeleteRequest request)
    {
        var response = await _mediator.Send(request);
        return StatusCode(204, "ChangeSuccesfully");
    }




    // GET api/<DoctorController>/patients/{doctorId}
    [HttpGet("patients/{doctorId}")]
    public async Task<IActionResult> GetAllPatientsByDoctorId(int doctorId)
    {
        var query = new GetAllPatientsByDoctorIdQueryRequest(doctorId);
        var response = await _mediator.Send(query);
        if (response.PatientDtos == null || !response.PatientDtos.Any())
        {
            throw new NotFoundException($"No patients found for Doctor with ID {doctorId}");
        }
        return Ok(response.PatientDtos);
    }


    // GET api/<DoctorController>/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetDoctorById(int id)
    {
        var query = new GetDoctorByIdQueryRequest { DoctorId = id };
        var response = await _mediator.Send(query);
        if (response.DoctorReadDto == null)
        {
            throw new NotFoundException($"Doctor with ID {id} not found");
        }
        return Ok(response.DoctorReadDto);
    }

}
