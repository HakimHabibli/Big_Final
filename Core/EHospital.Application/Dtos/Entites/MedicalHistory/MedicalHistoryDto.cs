using EHospital.Application.Dtos.Common;
using EHospital.Application.Dtos.Entites.Patient;

namespace EHospital.Application.Dtos.Entites.MedicalHistory;

public class MedicalHistoryCreateDto : BaseEntityDto//Bir MH yaradib Patiente vermek ucun nezerde tutulub(HemCreate ucun hemde read ucun ola bilerdi)
{
    public string Condition { get; set; }//Mövcud vəziyyət

    public DateTime DiagnosisDate { get; set; }

    public string Treatment { get; set; }//Hansı müalicədən keçib 

    public string Notes { get; set; }

    public string PatientSerialNumber { get; set; }
}

public class MedicalHistoryReadDto : BaseEntityDto//Medicakl historyl'rini getirmek ucun 
{
    public string Condition { get; set; }//Mövcud vəziyyət

    public DateTime DiagnosisDate { get; set; }

    public string Treatment { get; set; }//Hansı müalicədən keçib 

    public string Notes { get; set; }
    public PatientDto Patient { get; set; }
}
public class MedicalHistoryUpdateDto : BaseEntityDto
{
    public string Condition { get; set; }//Mövcud vəziyyət

    public DateTime DiagnosisDate { get; set; }

    public string Treatment { get; set; }//Hansı müalicədən keçib 

    public string Notes { get; set; }
    public string PatientSerialNumber { get; set; }

}
public class MedicalHistoryDto : BaseAuditableEntityDto
{
    public string Condition { get; set; }//Mövcud vəziyyət

    public DateTime DiagnosisDate { get; set; }

    public string Treatment { get; set; }//Hansı müalicədən keçib 

    public string Notes { get; set; }


    public int PatientId { get; set; }
    public PatientDto Patient { get; set; }
}
public class MedicalHistoryDeleteDto : BaseEntityDto { }
