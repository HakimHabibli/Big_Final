using EHospital.Application.Dtos.Common;
using EHospital.Application.Dtos.Entites.Doctor;
using EHospital.Application.Dtos.Entites.Patient;

namespace EHospital.Application.Dtos.Entites.PatientDoctor;

public class PatientDoctorDto : BaseEntityDto
{
    public int PatientId { get; set; }
    public PatientDto Patient { get; set; }

    public int DoctorId { get; set; }
    public DoctorDto Doctor { get; set; }
}
public class PatientDoctorReadDto : BaseEntityDto
{
    public int PatientId { get; set; }
    public PatientDto Patient { get; set; }

    public int DoctorId { get; set; }
    public DoctorDto Doctor { get; set; }
}

public class PatientDoctorDeleteDto : BaseEntityDto { }

public class PatientDoctorCreateDto : BaseAuditableEntityDto
{
    public int PatientId { get; set; }
    public PatientDto Patient { get; set; }

    public int DoctorId { get; set; }
    public DoctorDto Doctor { get; set; }
}

public class PatientDoctorUpdateDto : BaseEntityDto
{
    public int PatientId { get; set; }
    public PatientDto Patient { get; set; }

    public int DoctorId { get; set; }
    public DoctorDto Doctor { get; set; }
}
