using EHospital.Domain.Common;

namespace EHospital.Domain.Entities;

public class Hospital : BaseAuditableEntity
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string ContactNumber { get; set; }
    public string Email { get; set; }
    public string Description { get; set; }  // Xəstəxana haqqında əlavə məlumat
    //public string ImageUrl { get; set; }

    public ICollection<Doctor> Doctors { get; set; } // Xəstəxanada çalışan həkimlərin kolleksiyası
    public ICollection<Patient> Patients { get; set; }


    //[NotMapped]
    //public IFormFile Image { get; set; }
}
