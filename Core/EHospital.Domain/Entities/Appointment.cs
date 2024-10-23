namespace EHospital.Domain.Entities;

public class Appointment : BaseEntity
{

    public int? DoctorId { get; set; }
    public Doctor Doctor { get; set; }

    public int? PatientId { get; set; }
    public Patient Patient { get; set; }

    public DateTime AppointmentDate { get; set; }
    // Randevu vaxt slotu (misal üçün: "09:00 - 10:00")

    public string Notes { get; set; }
    public bool IsConfirmed { get; set; } // Randevu təsdiqlənib-təsdiqlənmədiyini göstərir
}