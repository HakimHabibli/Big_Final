namespace EHospital.Domain.Entities;

public class UserDeactivatedSchedule:BaseEntity
{
    public int UserId { get; set; }
    public int DoctorScheduleId { get; set; }
    public DateTime DeactivatedAt { get; set; }

    public DoctorSchedules DoctorSchedule { get; set; }
}