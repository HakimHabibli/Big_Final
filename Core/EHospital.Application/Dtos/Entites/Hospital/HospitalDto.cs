using EHospital.Application.Dtos.Common;
using EHospital.Application.Dtos.Entites.Doctor;
using EHospital.Application.Dtos.Entites.Patient;
using Microsoft.AspNetCore.Http;

namespace EHospital.Application.Dtos.Entites.Hospital;

public class HospitalDto : BaseEntityDto//Admin panel ucun get methodu
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string ContactNumber { get; set; }
    public string Email { get; set; }
    public string Description { get; set; }  // Xəstəxana haqqında əlavə məlumat
    public string ImageUrl { get; set; }

    public ICollection<DoctorReadDto> Doctors { get; set; } // Xəstəxanada çalışan həkimlərin kolleksiyası
    public ICollection<PatientReadDto> Patients { get; set; }
}

public class HospitalCreateDto :BaseAuditableEntityDto
{
 
    public string Name { get; set; }
    public string Address { get; set; }
    public string ContactNumber { get; set; }
    public string Email { get; set; }
    public string Description { get; set; }  // Xəstəxana haqqında əlavə məlumat
    public string? ImageUrl { get; set; }
    public IFormFile ImageFile { get; set; }
}
public class HospitalUpdateDto : BaseEntityDto
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string ContactNumber { get; set; }
    public string Email { get; set; }
    public string Description { get; set; }  // Xəstəxana haqqında əlavə məlumat

    public string? ImageUrl { get; set; }
    public IFormFile ImageFile { get; set; }
}
public class HospitalDeleteDto : BaseEntityDto
{
}
public class HospitalReadDto : BaseEntityDto
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string ContactNumber { get; set; }
    public string Email { get; set; }
    public string Description { get; set; }  // Xəstəxana haqqında əlavə məlumat
    public string ImageUrl { get; set; }
}