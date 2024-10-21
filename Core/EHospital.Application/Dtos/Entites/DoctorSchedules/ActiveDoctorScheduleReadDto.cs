namespace EHospital.Application.Dtos.Entites.DoctorSchedules;

public class ActiveDoctorScheduleReadDto
{
    public int ScheduleId { get; set; }  // Cədvəl ID-si
    public int DoctorId { get; set; }  // Həkim ID-si
    public string DoctorName { get; set; }  // Həkimin adı
    public DateTime ScheduleDate { get; set; }  // Cədvəl tarixi
    public bool IsActive { get; set; }  // Aktiv olub olmadığını göstərir
}

public class UserScheduleDeactivateDto
{
    public int ScheduleId { get; set; }
    public int UserId { get; set; }
}
public class UserScheduleReactivateDto
{
    public int ScheduleId { get; set; }
    public int UserId { get; set; }
}


public class UserDeactivatedScheduleReadDto
{
    public int ScheduleId { get; set; }
    public int DoctorId { get; set; }
    public string DoctorName { get; set; }
    public DateOnly ScheduleDate { get; set; }
    public bool IsActive { get; set; }
    public int? DeactivatedByUserId { get; set; }
    public DateTime? DeactivatedAt { get; set; }
}