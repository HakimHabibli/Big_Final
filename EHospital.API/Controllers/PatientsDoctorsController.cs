using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.PatientDoctor;
using EHospital.Application.Exceptions;
using EHospital.Persistence.Concretes.Services;
using Microsoft.AspNetCore.Mvc;

namespace EHospital.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientsDoctorsController : ControllerBase
{
    private readonly IPatientDoctorService _patientDoctorService;

    public PatientsDoctorsController(IPatientDoctorService patientDoctorService)
    {
        _patientDoctorService = patientDoctorService;
    }

    //[HttpGet("patients/{doctorId}")]
    //public async Task<IActionResult> GetAllPatientsByDoctorId(int doctorId)
    //{
    //    var patients = await _patientDoctorService.GetAllPatientsByDoctorIdAsync(doctorId);
    //    if (patients == null || !patients.Any())
    //    {
    //        throw new NotFoundException($"No patients found for Doctor with ID {doctorId}");
    //    }
    //    return Ok(patients);
    //}

    [HttpPost("patients")]
    public async Task<IActionResult> AddPatientToDoctor([FromBody] PatientDoctorDto patientDoctorDto)
    {
        await _patientDoctorService.AddPatientDoctorAsync(patientDoctorDto);
        return NoContent();
    }


    [HttpDelete("patients")]
    public async Task<IActionResult> RemovePatientFromDoctor([FromBody] PatientDoctorDto patientDoctorDto)
    {
        await _patientDoctorService.RemovePatientDoctorAsync(patientDoctorDto);
        return NoContent();
    }


    //[HttpGet("patients/{patientId}/{doctorId}")]
    //public async Task<IActionResult> GetPatientDoctor(int patientId, int doctorId)
    //{
    //    var patientDoctor = await _patientDoctorService.Get(patientId, doctorId);
    //    if (patientDoctor == null)
    //    {
    //        throw new NotFoundException($"No association found between Patient ID {patientId} and Doctor ID {doctorId}");
    //    }
    //    return Ok(patientDoctor);
    //}

}
