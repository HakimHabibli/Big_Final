using EHospital.Domain.Common;

namespace EHospital.Domain.Entities;

public class ContactInfo : BaseEntity
{
    public string Email { get; set; }
    public string Number { get; set; }
    public int? PatientId { get; set; }
    public Patient Patient { get; set; }
}