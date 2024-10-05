using EHospital.Application.Dtos.Common;
using EHospital.Application.Dtos.Entites.Doctor;
using EHospital.Application.Dtos.Entites.Patient;

namespace EHospital.Application.Dtos.Entites.Appointment;
public class AppointmentReadDto : BaseEntityDto
{
    public int DoctorId { get; set; }
    public string DoctorName { get; set; }
    public int PatientId { get; set; }
    public string PatientName { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string Notes { get; set; }
    public bool IsConfirmed { get; set; }
}
public class AppointmentDto : BaseEntityDto
{

    public int DoctorId { get; set; }
    public DoctorReadDto Doctor { get; set; }

    public int PatientId { get; set; }
    public PatientDto Patient { get; set; }

    public DateTime AppointmentDate { get; set; }

    public string Notes { get; set; }
    public bool IsConfirmed { get; set; }
}


public class AppointmentCreateDto : BaseAuditableEntityDto
{
    public int DoctorId { get; set; }
    public int PatientId { get; set; }
    public DateTime AppointmentDate { get; set; } // Rezerv ediləcək vaxt
    public string Notes { get; set; }
    public bool IsConfirmed { get; set; } // Təsdiqlənmə vəziyyəti
}
public class AppointmentUpdateDto : BaseEntityDto
{
    public int DoctorId { get; set; }

    public int PatientId { get; set; }

    public DateTime AppointmentDate { get; set; }

    public string Notes { get; set; }
    public bool IsConfirmed { get; set; }
}
public class AppointmentDeleteDto : BaseEntityDto
{

}
