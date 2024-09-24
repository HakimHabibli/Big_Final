using EHospital.Application.Dtos.Common;
using EHospital.Application.Dtos.Entites.Doctor;

namespace EHospital.Application.Dtos.Entites.DoctorSchedules;
public class DoctorSchedulesReadDto : BaseEntityDto
{
    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }

}
public class DoctorSchedulesDto : BaseEntityDto
{
    public int DoctorId { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public bool IsActive { get; set; } = true; // Varsayılan dəyər
}





public class DoctorSchedulesCreateDto : BaseAuditableEntityDto
{
    public int DoctorId { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }

    public string Doctor { get; set; }
}

public class DoctorSchedulesUpdateDto : BaseEntityDto
{
    public int DoctorId { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public DoctorDto Doctor { get; set; }
}
public class DoctorSchedulesDeleteDto : BaseEntityDto
{
}
