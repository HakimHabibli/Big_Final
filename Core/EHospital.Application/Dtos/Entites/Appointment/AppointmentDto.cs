using EHospital.Application.Dtos.Common;
using EHospital.Application.Dtos.Entites.Doctor;
using EHospital.Application.Dtos.Entites.Patient;

namespace EHospital.Application.Dtos.Entites.Appointment;

public class AppointmentDto : BaseEntityDto
{

    public int DoctorId { get; set; }
    public DoctorDto Doctor { get; set; }

    public int PatientId { get; set; }
    public PatientDto Patient { get; set; }

    public DateTime AppointmentDate { get; set; }

    public string Notes { get; set; }
    public bool IsConfirmed { get; set; }
}
public class AppointmentCreateDto : BaseAuditableEntityDto
{

    public int DoctorId { get; set; }
    public DoctorDto Doctor { get; set; }

    public int PatientId { get; set; }
    public PatientDto Patient { get; set; }

    public DateTime AppointmentDate { get; set; }

    public string Notes { get; set; }
    public bool IsConfirmed { get; set; }
}
public class AppointmentReadDto : BaseEntityDto
{
    public int DoctorId { get; set; }

    public int PatientId { get; set; }
    public PatientDto Patient { get; set; }

    public DateTime AppointmentDate { get; set; }

    public string Notes { get; set; }
    public bool IsConfirmed { get; set; }
}
public class AppointmentUpdateDto : BaseEntityDto
{
    public int DoctorId { get; set; }
    public DoctorDto Doctor { get; set; }

    public int PatientId { get; set; }
    public PatientDto Patient { get; set; }

    public DateTime AppointmentDate { get; set; }

    public string Notes { get; set; }
    public bool IsConfirmed { get; set; }
}
public class AppointmentDeleteDto : BaseEntityDto
{

}
