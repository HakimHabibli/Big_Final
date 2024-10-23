namespace EHospital.Domain.Entities;

public class DoctorSchedules : BaseAuditableEntity
{
    public int? DoctorId { get; set; }
    public Doctor Doctor { get; set; }

    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }

    public bool IsActive { get; set; }
}
