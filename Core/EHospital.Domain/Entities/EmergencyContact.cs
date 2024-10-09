using EHospital.Domain.Common;

namespace EHospital.Domain.Entities;

public class EmergencyContact : BaseEntity
{

    public string Name { get; set; }

    public string Number { get; set; }

    public string Relationship { get; set; }
    public int? PatientId { get; set; }
    public Patient Patient { get; set; }
}