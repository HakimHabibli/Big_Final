namespace EHospital.Domain.Entities;

public class PatientDoctor
{
    public int PatientId { get; set; }
    public Patient Patient { get; set; }

    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }
}