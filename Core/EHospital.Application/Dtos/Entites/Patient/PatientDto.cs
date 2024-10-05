using EHospital.Application.Dtos.Common;
using EHospital.Application.Dtos.Entites.Allergy;
using EHospital.Application.Dtos.Entites.ContactInfo;
using EHospital.Application.Dtos.Entites.EmergencyContact;
using EHospital.Application.Dtos.Entites.InsuranceDetails;
using EHospital.Application.Dtos.Entites.MedicalHistory;
using EHospital.Domain.Enums;

namespace EHospital.Application.Dtos.Entites.Patient;

public class PatientReadDto : BaseEntityDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public string Address { get; set; }
    public string HospitalName { get; set; }
    public string SerialNumber { get; set; }

    public ICollection<MedicalHistoryDto> MedicalHistories { get; set; }
    public ICollection<AllergyDto> Allergies { get; set; }
    //public ICollection<PatientDoctorDto> PatientDoctors { get; set; }
    //public ICollection<AppointmentDto> Appointments { get; set; }

    public ContactInfoDto ContactInfo { get; set; }
    public int ContactInfoId { get; set; }

    public EmergencyContactDto EmergencyContact { get; set; }
    public int EmergencyContactId { get; set; }

    public InsuranceDetailsDto InsuranceDetails { get; set; }
    public int InsuranceDetailsId { get; set; }
}

public class PatientDto : BaseEntityDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public string Address { get; set; }
    public string SerialNumber { get; set; }
    public string HospitalName { get; set; }


    public ContactInfoDto ContactInfo { get; set; }
    public int ContactInfoId { get; set; }

    public EmergencyContactDto EmergencyContact { get; set; }
    public int EmergencyContactId { get; set; }

    public InsuranceDetailsDto InsuranceDetails { get; set; }
    public int InsuranceDetailsId { get; set; }
}
