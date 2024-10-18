using EHospital.Application.Dtos.Entites.Allergy;
using EHospital.Application.Exceptions;
using EHospital.Application.Futures.Commands.Allergy.Create;
using EHospital.Application.Futures.Commands.Allergy.Update;
using EHospital.Application.Futures.Queries.Allergy.GetAllAllegiesByPatientId;
using EHospital.Application.Futures.Queries.Allergy.GetAllAllergies;
using EHospital.Application.Futures.Queries.Allergy.GetAllById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EHospital.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AllergyController : ControllerBase
{
    private readonly IMediator _mediator;

    public AllergyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
   // [Authorize(Policy = "DOCTOR")]
    public async Task<IActionResult> CreateAllergy([FromBody] AllergyCreateDto allergyCreateDto)
    {
        var request = new AllergyCreateCommandRequest { AllergyCreateDto = allergyCreateDto };
        var response = await _mediator.Send(request);
        return StatusCode(StatusCodes.Status201Created, response.StatusCode);
    }

    [HttpPut]
    //[Authorize(Policy = "DOCTOR")]
    public async Task<IActionResult> UpdateAllergy([FromBody] AllergyUpdateDto allergyUpdateDto)
    {
        if (allergyUpdateDto == null || allergyUpdateDto.Id <= 0)
        {
            throw new ValidationException("Invalid Allergy Id");
        }

        var request = new AllergyUpdateCommandRequest { AllergyUpdateDto = allergyUpdateDto };
        var response = await _mediator.Send(request);
        return StatusCode(StatusCodes.Status204NoContent, response.StatusCode);
    }

    [HttpDelete]
    //[Authorize(Policy = "DOCTOR")]
    public async Task<IActionResult> DeleteAllergy([FromBody] AllergyDeleteDto allergyDeleteDto)
    {
        if (allergyDeleteDto == null || allergyDeleteDto.Id <= 0)
        {
            throw new ValidationException("Invalid Allergy Id");
        }

        var request = new AllergyDeleteCommandRequest { AllergyDeleteDto = allergyDeleteDto };
        var response = await _mediator.Send(request);
        return StatusCode(StatusCodes.Status204NoContent, response.StatusCode);
    }

    [HttpGet("all")]
    //[Authorize(Policy = "DOCTOR")]
    public async Task<IActionResult> GetAllAllergies()
    {
        var query = new GetAllAllergiesQueryRequest();
        var response = await _mediator.Send(query);
        return Ok(response.Allergies);
    }

    [HttpGet("{id}")]
    //[Authorize(Policy = "DOCTOR")]
    public async Task<IActionResult> GetAllergyById(int id)
    {
        var query = new GetAllergyByIdQueryRequest { Id = id };
        var response = await _mediator.Send(query);
        return Ok(response.Allergy);
    }

    [HttpGet("patient/{patientId}")]
    //[Authorize(Policy = "DOCTOR")]
    public async Task<IActionResult> GetAllergiesByPatientId(int patientId)
    {
        var query = new GetAllergiesByPatientIdQueryRequest { PatientId = patientId };
        var response = await _mediator.Send(query);
        return Ok(response.Allergies);
    }
}

