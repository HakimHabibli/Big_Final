using EHospital.Application.Dtos.Common;
using EHospital.Application.Dtos.Entites.Appointment;
using EHospital.Application.Dtos.Entites.DoctorSchedules;
using EHospital.Application.Dtos.Entites.Hospital;
using EHospital.Application.Dtos.Entites.PatientDoctor;

namespace EHospital.Application.Dtos.Entites.Doctor;

public class DoctorDto : BaseEntityDto
{
    public string FirstName { get; set; } // Doktorun adı
    public string LastName { get; set; } // Doktorun soyadı
    public string Title { get; set; } // Doktorun rütbəsi
    public string Specialization { get; set; } // Doktorun ixtisası
    public string ContactNumber { get; set; } // Doktorun əlaqə nömrəsi
    public string Email { get; set; } // Doktorun elektron poçt ünvanı
    public string Address { get; set; } // Doktorun ünvanı
    public string Bio { get; set; } // Doktor haqqında əlavə məlumat
}
public class DoctorReadDto : BaseEntityDto
{
    public string FirstName { get; set; } // Doktorun adı
    public string LastName { get; set; } // Doktorun soyadı
    public string Title { get; set; } // Doktorun rütbəsi
    public string Specialization { get; set; } // Doktorun ixtisası
    public string ContactNumber { get; set; } // Doktorun əlaqə nömrəsi
    public string Email { get; set; } // Doktorun elektron poçt ünvanı
    public string Address { get; set; } // Doktorun ünvanı
    public string Bio { get; set; } // Doktor haqqında əlavə məlumat
}
public class DoctorCreateDto : BaseAuditableEntityDto
{
    public string FirstName { get; set; } // Doktorun adı
    public string LastName { get; set; } // Doktorun soyadı
    public string Title { get; set; } // Doktorun rütbəsi
    public string Specialization { get; set; } // Doktorun ixtisası
    public string ContactNumber { get; set; } // Doktorun əlaqə nömrəsi
    public string Email { get; set; } // Doktorun elektron poçt ünvanı
    public string Address { get; set; } // Doktorun ünvanı
    public string Bio { get; set; } // Doktor haqqında əlavə məlumat
    public int HospitalId { get; set; }  // Xəstəxana ID (nullable)
    public HospitalDto Hospital { get; set; } // Xəstəxana obyekti

    public ICollection<DoctorSchedulesDto> DoctorSchedules { get; set; }//Doktorun məsləhətləri vaxtlari
    public ICollection<AppointmentDto> Appointments { get; set; } // Doktorun məsləhət vaxtları
    public ICollection<PatientDoctorDto> PatientDoctors { get; set; } // Əlaqə cədvəli


}
public class DoctorUpdateDto : BaseEntityDto
{
    public string FirstName { get; set; } // Doktorun adı
    public string LastName { get; set; } // Doktorun soyadı
    public string Title { get; set; } // Doktorun rütbəsi
    public string Specialization { get; set; } // Doktorun ixtisası
    public string ContactNumber { get; set; } // Doktorun əlaqə nömrəsi
    public string Email { get; set; } // Doktorun elektron poçt ünvanı
    public string Address { get; set; } // Doktorun ünvanı
    public string Bio { get; set; } // Doktor haqqında əlavə 
}
public class DoctorDeleteDto : BaseEntityDto
{
}
