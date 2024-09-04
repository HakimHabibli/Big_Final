using EHospital.Application.Dtos.Common;
using EHospital.Application.Dtos.Entites.Patient;

namespace EHospital.Application.Dtos.Entites.MedicalHistory;

public class MedicalHistoryDto : BaseEntityDto
{
    public string Condition { get; set; }//Mövcud vəziyyət

    public DateTime DiagnosisDate { get; set; }

    public string Treatment { get; set; }//Hansı müalicədən keçib 

    public string Notes { get; set; }


    public int PatientId { get; set; }
    public PatientDto Patient { get; set; }
}
public class MedicalHistoryReadDto : BaseEntityDto
{
    public string Condition { get; set; }//Mövcud vəziyyət

    public DateTime DiagnosisDate { get; set; }

    public string Treatment { get; set; }//Hansı müalicədən keçib 

    public string Notes { get; set; }


    public int PatientId { get; set; }
    public PatientDto Patient { get; set; }
}
public class MedicalHistoryUpdateDto : BaseEntityDto
{
    public string Condition { get; set; }//Mövcud vəziyyət

    public DateTime DiagnosisDate { get; set; }

    public string Treatment { get; set; }//Hansı müalicədən keçib 

    public string Notes { get; set; }


    public int PatientId { get; set; }
    public PatientDto Patient { get; set; }
}
public class MedicalHistoryCreateDto : BaseAuditableEntityDto
{
    public string Condition { get; set; }//Mövcud vəziyyət

    public DateTime DiagnosisDate { get; set; }

    public string Treatment { get; set; }//Hansı müalicədən keçib 

    public string Notes { get; set; }


    public int PatientId { get; set; }
    public PatientDto Patient { get; set; }
}
public class MedicalHistoryDeleteDto : BaseEntityDto { }
