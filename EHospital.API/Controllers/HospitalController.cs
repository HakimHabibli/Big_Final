﻿using EHospital.Application.Dtos.Entites.Hospital;
using EHospital.Application.Exceptions;
using EHospital.Application.Futures.Commands.Hospital.Create;
using EHospital.Application.Futures.Commands.Hospital.Delete;
using EHospital.Application.Futures.Commands.Hospital.Update;
using EHospital.Application.Futures.Queries.Hospital.GetAllHospitals;
using EHospital.Application.Futures.Queries.Hospital.GetHospitalById;
using EHospital.Application.Futures.Queries.Hospital.GetHospitalDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EHospital.API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class HospitalController : ControllerBase
{
    private readonly IMediator _mediator;

    public HospitalController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    // [Authorize(Policy = "SuperAdmin")]
    public async Task<IActionResult> CreateHospitalAsync([FromForm] HospitalCreateCommandRequest request)
    {
        var response = await _mediator.Send(request);
        //return StatusCode(200, "Successfully created hospital.");
        //Daha yaxşı eləmək üçün daha dəqiq Status kod qaytarmaq üçün
        return StatusCode(StatusCodes.Status201Created, "Successfully created hospital.");

    }

    [HttpGet]
    public async Task<IActionResult> GetAllHospitals()
    {
        var query = new GetAllHospitalQueryRequest();
        var response = await _mediator.Send(query);

        return Ok(response.HospitalReadDtos);
    }

    [HttpGet("details/{id}")]
    //[Authorize(Policy = "SuperAdmin")]
    public async Task<IActionResult> GetHospitalDetails(int id)
    {
        var query = new GetHospitalDetailsQueryRequest { HospitalId = id };
        var response = await _mediator.Send(query);

        if (response.HospitalDto == null)
        {
            throw new NotFoundException($"Hospital with ID{id} not found");
        }
        return Ok(response.HospitalDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetHospitalById(int id)
    {
        var query = new GetHospitalByIdQueryRequest { Id = id };
        var response = await _mediator.Send(query);

        if (response.HospitalReadDto == null)
        {
            throw new NotFoundException($"Hospital with ID {id} not found");
        }

        return Ok(response.HospitalReadDto);
    }

    [HttpPut]
    // [Authorize(Policy = "SuperAdmin")]
    public async Task<IActionResult> UpdateHospital([FromForm] HospitalUpdateDto hospitalUpdateDto)
    {
        if (hospitalUpdateDto == null || hospitalUpdateDto.Id <= 0)
        {
            throw new ValidationException("Invalid Hospital Id");
        }

        var request = new HospitalUpdateCommandRequest { HospitalUpdateDto = hospitalUpdateDto };
        var response = await _mediator.Send(request);

        if (response.StatusCode == "204")
        {
            return NoContent();
        }
        return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the hospital.");
    }

    [HttpDelete("{id}")]
    //[Authorize(Policy = "SuperAdmin")]
    public async Task<IActionResult> Delete(HospitalDeleteCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return StatusCode(204, "Successfully deleted hospital.");
    }
}
