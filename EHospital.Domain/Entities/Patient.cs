using EHospital.Domain.Common;
using EHospital.Domain.Enums;

namespace EHospital.Domain.Entities;

public class Patient : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int ContactInfoId { get; set; }
    public ContactInfo ContactInfo { get; set; }
    public Gender Gender { get; set; }
    public string Address { get; set; }
    public EmergencyContact EmergencyContact { get; set; }//Təcili əlaqə
    public int EmergencyContactId { get; set; }
    public InsuranceDetails InsuranceDetails { get; set; }//Sığorta təfərrüatları
    public int InsuranceDetailsId { get; set; }
    public ICollection<MedicalHistory> MedicalHistories { get; set; }
    public ICollection<Allergy> Allergies { get; set; }
    public ICollection<PatientDoctor> PatientDoctors { get; set; } // Əlaqə cədvəli
    public ICollection<Appointment> Appointments { get; set; }
    public int? HospitalId { get; set; } // Xəstəxana ID (nullable)
    public Hospital Hospital { get; set; }
}