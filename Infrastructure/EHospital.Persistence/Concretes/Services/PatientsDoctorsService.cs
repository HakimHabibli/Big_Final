using AutoMapper;
using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.PatientDoctor;
using EHospital.Application.Exceptions;
using EHospital.Domain.Entities;
using EHospital.Persistence.DAL;
using Microsoft.EntityFrameworkCore;

namespace EHospital.Persistence.Concretes.Services;

public class PatientsDoctorsService: IPatientDoctorService
{
    private readonly IMapper _mapper;
    private readonly AppDbContext _appDbContext;



    public PatientsDoctorsService(IMapper mapper, AppDbContext appDbContext)
    {
        _mapper = mapper;
        _appDbContext = appDbContext;
    }
    public async Task AddPatientDoctorAsync(PatientDoctorDto patientDoctorDto)
    {
        var patient = await _appDbContext.Patients.FindAsync(patientDoctorDto.PatientId);
        if (patient == null)
        {
            throw new NotFoundException($"Patient with Id {patientDoctorDto.PatientId} not found.");
        }

        var doctor = await _appDbContext.Doctors.FindAsync(patientDoctorDto.DoctorId);
        if (doctor == null)
        {
            throw new NotFoundException($"Doctor with Id {patientDoctorDto.DoctorId} not found.");
        }
        var exists = await _appDbContext.PatientDoctors
       .AnyAsync(pd => pd.PatientId == patientDoctorDto.PatientId && pd.DoctorId == patientDoctorDto.DoctorId);

        if (exists)
        {
            throw new InvalidOperationException($"The relationship between Patient ID {patientDoctorDto.PatientId} and Doctor ID {patientDoctorDto.DoctorId} already exists.");
        }
        var patientDoctor = new PatientDoctor
        {
            PatientId = patientDoctorDto.PatientId,
            DoctorId = patientDoctorDto.DoctorId
        };

        await _appDbContext.PatientDoctors.AddAsync(patientDoctor);
        await _appDbContext.SaveChangesAsync();
    }


    public async Task RemovePatientDoctorAsync(PatientDoctorDto patientDoctorDto)
    {
        var patientDoctor = await _appDbContext.PatientDoctors
            .FirstOrDefaultAsync(pd => pd.PatientId == patientDoctorDto.PatientId && pd.DoctorId == patientDoctorDto.DoctorId);

        if (patientDoctor == null)
        {
            throw new NotFoundException($"No association found between Patient ID {patientDoctorDto.PatientId} and Doctor ID {patientDoctorDto.DoctorId}.");
        }

        _appDbContext.PatientDoctors.Remove(patientDoctor);
        await _appDbContext.SaveChangesAsync();
    }


    public async Task<IEnumerable<PatientDoctor>> GetAllPatientsByDoctorIdAsync(int doctorId)
    {
        return await _appDbContext.PatientDoctors
            .Where(pd => pd.DoctorId == doctorId)
            .ToListAsync();
    }

}
