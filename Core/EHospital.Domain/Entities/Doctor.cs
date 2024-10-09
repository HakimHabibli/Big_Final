using EHospital.Domain.Common;

namespace EHospital.Domain.Entities;
public class Doctor : BaseAuditableEntity
{
    public string FirstName { get; set; } // Doktorun adı
    public string LastName { get; set; } // Doktorun soyadı
    public string Title { get; set; } // Doktorun rütbəsi
    public string Specialization { get; set; } // Doktorun ixtisası
    public string ContactNumber { get; set; } // Doktorun əlaqə nömrəsi
    public string Email { get; set; } // Doktorun elektron poçt ünvanı
    public string Address { get; set; } // Doktorun ünvanı
    public string Bio { get; set; } // Doktor haqqında əlavə məlumat

    public int? HospitalId { get; set; }  // Xəstəxana ID (nullable)
    public Hospital Hospital { get; set; } // Xəstəxana obyekti

    public ICollection<DoctorSchedules>? DoctorSchedules { get; set; }//Doktorun məsləhətləri vaxtlari
    public ICollection<Appointment>? Appointments { get; set; }     // Doktorun məsləhət vaxtları
    public ICollection<PatientDoctor>? PatientDoctors { get; set; } // Əlaqə cədvəli

    //public string ImageUrl { get; set; }

    //[NotMapped]
    //public IFormFile ImageFile { get; set; }

}