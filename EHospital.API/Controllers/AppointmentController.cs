using EHospital.Application.Dtos.Entites.Appointment;
using EHospital.Application.Exceptions;
using EHospital.Application.Futures.Commands.Appointment.Create;
using EHospital.Application.Futures.Commands.Appointment.Delete;
using EHospital.Application.Futures.Commands.Appointment.Update;
using EHospital.Application.Futures.Queries.Appointment.GetAllAppointment;
using EHospital.Application.Futures.Queries.Appointment.GetAppointmentsByDoctorId;
using EHospital.Application.Futures.Queries.Appointment.GetAppointmentsByPatientId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EHospital.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppointmentController : ControllerBase
{
    private readonly IMediator _mediator;

    public AppointmentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    //[Authorize(Policy = "MODERATOR")]
    public async Task<IActionResult> CreateAppointment([FromBody] AppointmentCreateDto appointmentCreateDto)
    {
        var request = new AppointmentCreateRequest { AppointmentCreateDto = appointmentCreateDto };
        var response = await _mediator.Send(request);
        return StatusCode(StatusCodes.Status201Created, response.StatusCode);
    }

    [HttpPut]
    //[Authorize(Policy = "MODERATOR")]
    public async Task<IActionResult> UpdateAppointment([FromBody] AppointmentUpdateDto appointmentUpdateDto)
    {
        if (appointmentUpdateDto == null || appointmentUpdateDto.Id <= 0)
        {
            throw new ValidationException("Invalid Appointment Id");
        }

        var request = new AppointmentUpdateRequest { AppointmentUpdateDto = appointmentUpdateDto };
        var response = await _mediator.Send(request);
        return StatusCode(StatusCodes.Status204NoContent, response.StatusCode);
    }

    [HttpDelete]
    //[Authorize(Policy = "MODERATOR")]
    public async Task<IActionResult> DeleteAppointment([FromBody] AppointmentDeleteDto appointmentDeleteDto)
    {
        if (appointmentDeleteDto == null || appointmentDeleteDto.Id <= 0)
        {
            throw new ValidationException("Invalid Appointment Id");
        }

        var request = new AppointmentDeleteRequest { AppointmentDeleteDto = appointmentDeleteDto };
        var response = await _mediator.Send(request);
        return StatusCode(StatusCodes.Status204NoContent, response.StatusCode);
    }

    [HttpGet("all")]
    //[Authorize(Policy = "MODERATOR")]
    public async Task<IActionResult> GetAllAppointments()
    {
        var query = new GetAllAppointmentsQueryRequest();
        var response = await _mediator.Send(query);
        return Ok(response.Appointments);
    }



    [HttpGet("doctor/{doctorId}")]
    //[Authorize(Policy = "MODERATOR")]
    public async Task<IActionResult> GetAppointmentsByDoctorId(int doctorId)
    {
        var query = new GetAppointmentsByDoctorIdQueryRequest { DoctorId = doctorId };
        var response = await _mediator.Send(query);
        return Ok(response.Appointments);
    }

    [HttpGet("patient/{patientId}")]
    //[Authorize(Policy = "MODERATOR")]
    public async Task<IActionResult> GetAppointmentsByPatientId(int patientId)
    {
        var query = new GetAppointmentsByPatientIdQueryRequest { PatientId = patientId };
        var response = await _mediator.Send(query);
        return Ok(response.Appointments);
    }
}
