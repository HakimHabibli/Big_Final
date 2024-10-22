using EHospital.Application.Dtos.Common;
using EHospital.Application.Dtos.Entites.Doctor;

namespace EHospital.Application.Dtos.Entites.DoctorSchedules;
public class DoctorSchedulesReadDto : BaseEntityDto//Doctor daxilinde istifade etmek ucun 
{
    public DateTime Date { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }

}
public class DoctorSchedulesDto : BaseEntityDto//Ana sehife ucun 
{
    public int DoctorId { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public bool IsActive { get; set; } = true;
}





public class DoctorSchedulesCreateDto : BaseAuditableEntityDto
{
    public DateTime Date { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public int DoctorId { get; set; }
}

public class DoctorSchedulesUpdateDto : BaseEntityDto
{
    public DateTime Date { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }

    public int DoctorId { get; set; }
    public DoctorDto Doctor { get; set; }
}
public class DoctorSchedulesDeleteDto : BaseEntityDto
{
}


