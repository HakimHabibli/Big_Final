using EHospital.Domain.Common;
using EHospital.Domain.Enums;

namespace EHospital.Domain.Entities;

public class Allergy:BaseEntity
{

    public string Name { get; set; }

    public string Details { get; set; }
    public AllergySeverity Severity { get; set; }//Enum yazilacaq

    public int? PatientId { get; set; } // Foreign key
    public Patient Patient { get; set; } // Navigation property
}



