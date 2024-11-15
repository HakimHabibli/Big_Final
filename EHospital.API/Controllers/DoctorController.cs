﻿using EHospital.Application.Dtos.Entites.Doctor;
using EHospital.Application.Exceptions;
using EHospital.Application.Futures.Commands.Doctor.Create;
using EHospital.Application.Futures.Commands.Doctor.Delete;
using EHospital.Application.Futures.Commands.Doctor.Update;
using EHospital.Application.Futures.Queries.Doctor.GetAllDoctors;
using EHospital.Application.Futures.Queries.Doctor.GetAllPatientsByDoctorId;
using EHospital.Application.Futures.Queries.Doctor.GetDoctorById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

    [HttpPost]
    //[Authorize(Policy = "ADMIN")]
    public async Task<IActionResult> CreateDoctor([FromForm] DoctorCreateDto doctorCreateDto)
    {
        try
        {
            var request = new DoctorCreateRequest { DoctorCreateDto = doctorCreateDto };
            var response = await _mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created, "Successfully created doctor.");
        }
        catch (Exception ex)
        {

            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllDoctors()
    {
        var query = new GetAllDoctorQueryRequest();
        var response = await _mediator.Send(query);

        return Ok(response.DoctorReadDtos);
    }

    [HttpPut]
    //[Authorize(Policy = "ADMIN")]
    public async Task<IActionResult> UpdateDoctor([FromForm] DoctorUpdateDto doctorUpdateDto)
    {
        if (doctorUpdateDto == null || doctorUpdateDto.Id <= 0)
        {
            throw new ValidationException("Invalid Doctor Id");
        }
        var request = new DoctorUpdateRequest { DoctorUpdateDto = doctorUpdateDto };
        var response = await _mediator.Send(request);
        return NoContent();
    }

    [HttpDelete("{id}")]
    //[Authorize(Policy = "ADMIN")]
    public async Task<IActionResult> Delete(DoctorDeleteRequest request)
    {
        var response = await _mediator.Send(request);
        return StatusCode(204, "ChangeSuccesfully");
    }

    [HttpGet("patients/{doctorId}")]
    //[Authorize(Policy = "ADMIN")]
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

    [HttpGet("{id}")]
    // [Authorize(Policy = "ADMIN")]
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
