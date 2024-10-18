
using EHospital.Application.Dtos.Common;
using EHospital.Application.Dtos.Entites.Patient;
using EHospital.Domain.Enums;

namespace EHospital.Application.Dtos.Entites.Allergy;
//Əgər sırf allergyə aid Proplar olsa artirmaq 
public class AllergyDto : BaseEntityDto
{
    public string Name { get; set; }
    public string Details { get; set; }
    public AllergySeverity Severity { get; set; }//Enum yazilacaq
    public int PatientId { get; set; } // Foreign key
    public PatientDto? Patient { get; set; } // Navigation property
}
public class AllergyCreateDto : BaseAuditableEntityDto
{
    public string Name { get; set; }

    public string Details { get; set; }
    public AllergySeverity Severity { get; set; }//Enum yazilacaq

    public int PatientId { get; set; } // Foreign key

}
public class AllergyReadDto : BaseEntityDto
{
    public string Name { get; set; }

    public string Details { get; set; }
    public AllergySeverity Severity { get; set; }//Enum yazilacaq

}
public class AllergyUpdateDto : BaseEntityDto
{
    public string Name { get; set; }
    public string Details { get; set; }
    public AllergySeverity Severity { get; set; }//Enum yazilacaq
}
public class AllergyDeleteDto : BaseEntityDto
{
}

