using EHospital.Application.Abstractions.Repositories;
using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.Doctor;
using EHospital.Application.Dtos.Entites.Patient;

namespace EHospital.Application.Concretes.Services;

public class DoctorService : IDoctorService
{
    private readonly IDoctorReadRepository _readRepo;
    private readonly IDoctorWriteRepository _writeRepo;

    public DoctorService(IDoctorReadRepository readRepo, IDoctorWriteRepository writeRepo)
    {
        _readRepo = readRepo;
        _writeRepo = writeRepo;
    }

    public async Task<List<PatientDto>> GetAllPatientsAsync(int doctorId)
    {
        return default;
        //return await _readRepo.GetAll()
        //    .Include(p => p.PatientDoctors).ThenInclude(pd => pd.Patient).Where(x => x.Id == doctorId).SelectMany(x => x.PatientDoctors.Select(pd => pd.Patient)).ToListAsync();
    }

    public Task<DoctorDto>? GetDoctorByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    //public async Task<List<Patient>> GetAllPatientsAsync(int doctorId)
    //{
    //    return await _readRepo.GetAll()
    //           .Include(x => x.PatientDoctors)
    //           .ThenInclude(x => x.Patient)
    //           .Where(x => x.Id == doctorId)
    //           .SelectMany(x => x.PatientDoctors.Select(pd => pd.Patient))
    //           .ToListAsync();
    //}

    //public Task<Doctor> GetDoctorByIdAsync(int id)
    //{
    //    var doctor = _readRepo.GetByIdAsync(id, false, "Patient", "Hospital");
    //    if (doctor == null)
    //    {
    //        throw new Exception("Doctor is not found");
    //    }
    //    return doctor;
    //}
}
