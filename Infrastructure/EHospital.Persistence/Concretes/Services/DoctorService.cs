using AutoMapper;
using EHospital.Application.Abstractions;
using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.Doctor;
using EHospital.Application.Dtos.Entites.Patient;
using EHospital.Application.Exceptions;
using EHospital.Domain.Entities;

namespace EHospital.Application.Concretes.Services;

public class DoctorService : IDoctorService
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly HttpClient _httpClient;

    public DoctorService(IUnitOfWork unitOfWork, IMapper mapper, HttpClient httpClient)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _httpClient = httpClient;
    }




    public async Task<DoctorReadDto>? GetDoctorByIdAsync(int id)
    {
        var doctor = await _unitOfWork.DoctorReadRepository.GetByIdAsync(id, "Hospital");
        return _mapper.Map<DoctorReadDto>(doctor);
    }

    #region Try

    //public async Task<DoctorReadDto> GetDoctorByIdAsync(int id)
    //{
    //    var doctor = await _unitOfWork.DoctorReadRepository.GetByIdAsync(id, "Hospital");
    //    var doctorDto = _mapper.Map<DoctorReadDto>(doctor);

    //    if (!string.IsNullOrEmpty(doctor.ImageUrl))
    //    {
    //        var httpClient = httpClientFactory.CreateClient();
    //        var response = await httpClient.GetAsync($"http://localhost:5217/images/{doctor.ImageUrl}");

    //        if (response.IsSuccessStatusCode)
    //        {
    //            var fileBytes = await response.Content.ReadAsByteArrayAsync();

    //        }
    //    }

    //    return doctorDto;
    //}
    //[HttpGet("{id}")]
    //public async Task<DoctorReadDto>? GetDoctorByIdAsync(int id)
    //{
    //    var doctor = await _unitOfWork.DoctorReadRepository.GetByIdAsync(id);

    //    if (doctor == null)
    //    {
    //        throw new Exception("Doctor not found.");
    //    }

    //    var doctorReadDto = new DoctorReadDto
    //    {
    //        FirstName = doctor.FirstName,
    //        LastName = doctor.LastName,
    //        Title = doctor.Title,
    //        Specialization = doctor.Specialization,
    //        ContactNumber = doctor.ContactNumber,
    //        Email = doctor.Email,
    //        Address = doctor.Address,
    //        Bio = doctor.Bio,
    //        ImageUrl = doctor.ImageUrl,
    //        HospitalName = doctor.Hospital.Name
    //    };

    //    return doctorReadDto;
    //}
    #endregion

    public async Task<IEnumerable<DoctorReadDto>> GetAllDoctorsAsync()
    {
        var doctors = await _unitOfWork.DoctorReadRepository.GetAllAsync(false, "Hospital");
        return doctors.Select(d => _mapper.Map<DoctorReadDto>(d));
    }

    public async Task CreateDoctorAsync(DoctorCreateDto doctorCreateDTO)
    {

        var hospital = await _unitOfWork.HospitalReadRepository.GetByIdAsync(doctorCreateDTO.HospitalId);

        if (hospital == null)
        {
            throw new NotFoundException($"Hospital with Id {doctorCreateDTO.Id} not found");
        }

        var doctor = _mapper.Map<Doctor>(doctorCreateDTO);
        if (doctorCreateDTO.ImageFile != null) 
        {
            var content = new MultipartFormDataContent();
            string newFileName = null;
            using (var ms = new MemoryStream())
            { 
                await doctorCreateDTO.ImageFile.CopyToAsync(ms);
                var fileBytes = ms.ToArray();
                newFileName = Guid.NewGuid().ToString() + Path.GetExtension(doctorCreateDTO.ImageFile.FileName);
                content.Add(new ByteArrayContent(fileBytes), "file", newFileName);

            }
            var response = await _httpClient.PostAsync("http://localhost:5217/images/upload", content);
            if (!response.IsSuccessStatusCode) 
            {
                throw new Exception("Sekil yukelemk olmadi");
            }
            doctor.ImageUrl = newFileName;
        }

        doctor.Hospital = hospital;

        await _unitOfWork.DoctorWriteRepository.CreateAsync(doctor);
    }

    public async Task DeleteDoctorAsync(DoctorDeleteDto doctorDeleteDto)
    {
        var doctor = await _unitOfWork.DoctorReadRepository.GetByIdAsync(doctorDeleteDto.Id);
        if (doctor == null)
        {
            throw new KeyNotFoundException("Doctor not found.");
        }

        var fileName = doctor.ImageUrl;
        var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
        var rootPath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
        if (!string.IsNullOrEmpty(fileName)) 
        {
            if (File.Exists(imagePath)) { File.Delete(imagePath); }
            if (File.Exists(rootPath)) { File.Delete(rootPath); }
        }
        await _unitOfWork.DoctorWriteRepository.DeleteAsync(doctor);
    }

    public async Task UpdateDoctorAsync(DoctorUpdateDto doctorUpdateDto)
    {
        string newFileName = null;
        var doctor = await _unitOfWork.DoctorReadRepository.GetByIdAsync(doctorUpdateDto.Id);
        if (doctor == null)
        {
            throw new NotFoundException("Doctor not found");
        }

        if (doctorUpdateDto.HospitalId == null)
        {
            throw new ArgumentException("HospitalId cannot be null");
        }

        var hospital = await _unitOfWork.HospitalReadRepository.GetByIdAsync(doctorUpdateDto.HospitalId);

        if (hospital == null)
        {
            throw new NotFoundException("Hospital not found");
        }

        if (!string.IsNullOrEmpty(doctor.ImageUrl))
        {
            var oldFileName = Path.GetFileName(doctor.ImageUrl);
            var deleteResponse = await _httpClient.DeleteAsync($"http://localhost:5217/images/delete/{oldFileName}");

            if (!deleteResponse.IsSuccessStatusCode)
            {
                throw new Exception("Köhnə şəkili silmək mümkün olmadı.");
            }
        }
        if (doctorUpdateDto.ImageFile != null) 
        {
            var content = new MultipartFormDataContent();
            using (var ms = new MemoryStream())
            {
                await doctorUpdateDto.ImageFile.CopyToAsync(ms);
                var fileBytes = ms.ToArray();
                newFileName = Guid.NewGuid().ToString() + Path.GetExtension(doctorUpdateDto.ImageFile.FileName);
                content.Add(new ByteArrayContent(fileBytes), "file", doctorUpdateDto.ImageFile.FileName);
            }

            var uploadResponse = await _httpClient.PostAsync("http://localhost:5217/images/upload", content);

            if (!uploadResponse.IsSuccessStatusCode)
            {
                throw new Exception("Yeni şəkili yükləmək mümkün olmadı.");
            }
        }

        _mapper.Map(doctorUpdateDto, doctor);

        doctor.Hospital = hospital;
        doctor.ImageUrl = newFileName;

        await _unitOfWork.DoctorWriteRepository.UpdateAsync(doctor);
    }
    public async Task<List<PatientDto>> GetAllPatientsAsync(int doctorId)
    {
        var patients = await _unitOfWork.DoctorReadRepository.GetPatientsByDoctorIdAsync(doctorId);
        return _mapper.Map<List<PatientDto>>(patients);
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


}