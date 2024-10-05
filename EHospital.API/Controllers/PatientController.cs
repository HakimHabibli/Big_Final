using EHospital.Application.Dtos.Entites.Patient;
using EHospital.Application.Exceptions;
using EHospital.Application.Features.Commands.Patient.Create;
using EHospital.Application.Features.Queries.Patient.GetAll;
using EHospital.Application.Features.Queries.Patient.GetBySerialNumber;
using EHospital.Application.Futures.Commands.Patient.Delete;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EHospital.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientController : ControllerBase
{
    private readonly IMediator _mediator;

    public PatientController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePatient([FromBody] PatientDto patientCreateDto)
    {
        var request = new PatientCreateCommandRequest { PatientCreateDto = patientCreateDto };
        var response = await _mediator.Send(request);
        return StatusCode(StatusCodes.Status201Created, "Successfully created patient.");
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPatients()
    {
        var query = new PatientGetAllQueryRequest();
        var response = await _mediator.Send(query);
        return Ok(response.Patients);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPatientById(int id)
    {
        var query = new PatientGetByIdQueryRequest { Id = id };
        var response = await _mediator.Send(query);
        if (response.PatientReadDto == null)
        {
            throw new NotFoundException($"Patient with ID {id} not found");
        }
        return Ok(response.PatientReadDto);
    }

    // GET api/<PatientController>/serial/{serialNumber}
    [HttpGet("serial/{serialNumber}")]
    public async Task<IActionResult> GetPatientBySerialNumber(string serialNumber)
    {
        var query = new PatientGetBySerialNumberQueryRequest { SerialNumber = serialNumber };
        var response = await _mediator.Send(query);
        if (response.PatientReadDto == null)
        {
            throw new NotFoundException($"Patient with Serial Number {serialNumber} not found");
        }
        return Ok(response.PatientReadDto);
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePatient([FromBody] PatientDto patientUpdateDto)
    {
        if (patientUpdateDto == null || patientUpdateDto.Id <= 0)
        {
            throw new ValidationException("Invalid Patient Id");
        }
        var request = new PatientUpdateCommandRequest { PatientUpdateDto = patientUpdateDto };
        var response = await _mediator.Send(request);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePatient(int id)
    {
        var request = new PatientDeleteCommandRequest { Id = id };
        var response = await _mediator.Send(request);
        return StatusCode(204, "Successfully deleted patient.");
    }
}
