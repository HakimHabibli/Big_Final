using EHospital.Application.Dtos.Entites.MedicalHistory;
using EHospital.Application.Exceptions;
using EHospital.Application.Futures.Commands.MedicalHistory.Create;
using EHospital.Application.Futures.Commands.MedicalHistory.Delete;
using EHospital.Application.Futures.Commands.MedicalHistory.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EHospital.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MedicalHistoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public MedicalHistoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMedicalHistory([FromBody] MedicalHistoryCreateDto medicalHistoryCreateDto)
    {
        var request = new MedicalHistoryCreateCommandRequest { MedicalHistoryCreateDto = medicalHistoryCreateDto };
        var response = await _mediator.Send(request);
        return StatusCode(StatusCodes.Status201Created, response.StatusCode);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMedicalHistory(MedicalHistoryDeleteDto medical)
    {
        var request = new MedicalHistoryDeleteCommandRequest { MedicalHistoryDeleteDto = medical };
        var response = await _mediator.Send(request);
        return StatusCode(StatusCodes.Status204NoContent, response.StatusCode);
    }
    [HttpPut]
    public async Task<IActionResult> UpdateMedicalHistory([FromBody] MedicalHistoryUpdateDto medicalHistoryUpdateDto)
    {
        if (medicalHistoryUpdateDto == null || medicalHistoryUpdateDto.Id <= 0)
        {
            throw new ValidationException("Invalid Medical History Id");
        }

        var request = new MedicalHistoryUpdateCommandRequest { MedicalHistoryUpdateDto = medicalHistoryUpdateDto };
        var response = await _mediator.Send(request);

        return StatusCode(StatusCodes.Status204NoContent, response.StatusCode);
    }
    [HttpGet]
    public async Task<IActionResult> GetAllMedicalHistories()
    {
        var query = new GetAllMedicalHistoriesQueryRequest();
        var response = await _mediator.Send(query);
        if (response.MedicalHistoryReadDtos == null || !response.MedicalHistoryReadDtos.Any())
        {
            return NoContent();
        }
        return Ok(response.MedicalHistoryReadDtos);
    }
    [HttpGet("bySerialNumber/{serialNumber}")]
    public async Task<IActionResult> GetMedicalHistoryBySerialNumber(string serialNumber)
    {
        var query = new GetMedicalHistoryBySerialNumberQueryRequest { SerialNumber = serialNumber };
        var response = await _mediator.Send(query);

        if (response.MedicalHistoryReadDto == null)
        {
            return NotFound($"Medical history for patient with serial number {serialNumber} not found");
        }

        return Ok(response.MedicalHistoryReadDto);
    }

}
