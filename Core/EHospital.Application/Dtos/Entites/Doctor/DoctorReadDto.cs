using EHospital.Application.Dtos.Common;
using EHospital.Application.Dtos.Entites.DoctorSchedules;
using Microsoft.AspNetCore.Http;

namespace EHospital.Application.Dtos.Entites.Doctor;

public class DoctorDto : BaseEntityDto
{
    public string FirstName { get; set; }      // Doktorun adı
    public string LastName { get; set; }       // Doktorun soyadı
    public string Title { get; set; }          // Doktorun rütbəsi
    public string Specialization { get; set; } // Doktorun ixtisası
    public string ContactNumber { get; set; }  // Doktorun əlaqə nömrəsi
    public string Email { get; set; }          // Doktorun elektron poçt ünvanı
    public string Address { get; set; }        // Doktorun ünvanı
    public string Bio { get; set; }            // Doktor haqqında əlavə məlumat
    public string ImageUrl { get; set; }
   
    public string HospitalName { get; set; }
    public ICollection<DoctorSchedulesDto> DoctorSchedules { get; set; } // Həkimin cədvəlləri yalniz Ozune xas proplar olmalidi

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
    public string ImageUrl { get; set; }
    public string HospitalName { get; set; } //Hansi xəstəxanaya aid oldugunu görmək üçün 
  

}

public class DoctorCreateDto : BaseAuditableEntityDto
{
    public string FirstName { get; set; } // Doktorun adı
    public string LastName { get; set; } // Doktorun soyadı
    public string Title { get; set; } // Doktorun rütbəsi
    public string Specialization { get; set; } // Doktorun ixtisası
    public string ContactNumber { get; set; } // Doktorun əlaqə nömrəsi
    public string Email { get; set; } // Doktorun elektron poçt ünvanı
    public string? Address { get; set; } // Doktorun ünvanı
    public string Bio { get; set; } // Doktor haqqında əlavə məlumat
    public string? ImageUrl { get; set; }
    public IFormFile ImageFile { get; set; }

    public int HospitalId { get; set; }    //Xəstəxana Adi

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
    public string? ImageUrl { get; set; }
    public IFormFile ImageFile { get; set; }
    public int HospitalId { get; set; }  // Xəstəxana ID (nullable)
}

//Cascade olmamalidir(++)
public class DoctorDeleteDto : BaseEntityDto
{
}
