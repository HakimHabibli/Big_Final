using EHospital.Application.Dtos.Common;
using EHospital.Application.Dtos.Entites.Patient;

namespace EHospital.Application.Dtos.Entites.ContactInfo;

public class ContactInfoDto : BaseEntityDto
{
    public string Email { get; set; }
    public string Number { get; set; }
    public int PatientId { get; set; }
    public PatientDto Patient { get; set; }
}
public class ContactInfoReadDto : BaseEntityDto
{
    public string Email { get; set; }
    public string Number { get; set; }
    public int PatientId { get; set; }
    public PatientDto Patient { get; set; }
}
public class ContactInfoCreateDto : BaseAuditableEntityDto
{
    public string Email { get; set; }
    public string Number { get; set; }
    public int PatientId { get; set; }
    public PatientDto Patient { get; set; }
}
public class ContactInfoUpdateDto : BaseEntityDto
{
    public string Email { get; set; }
    public string Number { get; set; }
    public int PatientId { get; set; }
    public PatientDto Patient { get; set; }
}
public class ContactInfoDeleteDto : BaseEntityDto
{
}
