namespace EHospital.Domain.Entities;

public class MedicalHistory : BaseEntity
{
    public string Condition { get; set; }//Mövcud vəziyyət

    public DateTime DiagnosisDate { get; set; }

    public string Treatment { get; set; }//Hansı müalicədən keçib 

    public string Notes { get; set; }


    public int? PatientId { get; set; }
    public Patient? Patient { get; set; }
}