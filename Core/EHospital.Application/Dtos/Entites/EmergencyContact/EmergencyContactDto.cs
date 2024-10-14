using EHospital.Application.Dtos.Common;
using EHospital.Application.Dtos.Entites.Patient;

namespace EHospital.Application.Dtos.Entites.EmergencyContact;

public class EmergencyContactDto 
{
    public string Name { get; set; }

    public string Number { get; set; }

    public string Relationship { get; set; }


}
public class EmergencyContactReadDto : BaseEntityDto
{
    public string Name { get; set; }

    public string Number { get; set; }

    public string Relationship { get; set; }
    public int PatientId { get; set; }
    public PatientDto Patient { get; set; }
}
public class EmergencyContactUpdateDto : BaseEntityDto
{
    public string Name { get; set; }

    public string Number { get; set; }

    public string Relationship { get; set; }
    public int PatientId { get; set; }
    public PatientDto Patient { get; set; }
}
public class EmergencyContactCreateDto : BaseAuditableEntityDto
{
    public string Name { get; set; }

    public string Number { get; set; }

    public string Relationship { get; set; }
    public string PatientName { get; set; }

}
public class EmergencyContactDeleteDto : BaseEntityDto
{
}