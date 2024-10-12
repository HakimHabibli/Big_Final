using EHospital.Application.Dtos.Common;
using EHospital.Application.Dtos.Entites.Patient;

namespace EHospital.Application.Dtos.Entites.InsuranceDetails;

public class InsuranceDetailsDto : BaseEntityDto
{
    public string InsuranceProvider { get; set; }


    public DateTime CoverageStartDate { get; set; }


    public DateTime CoverageEndDate { get; set; }//Sigortanın başlama və bitmə tarixləri


    public string PlanType { get; set; }

    public string AdditionalInfo { get; set; }//Sığorta ilə bağlı əlavə məlumatları saxlayır.

}

public class InsuranceDetailsCreateDto : BaseAuditableEntityDto
{
    public string InsuranceProvider { get; set; }


    public DateTime? CoverageStartDate { get; set; }


    public DateTime? CoverageEndDate { get; set; }//Sigortanın başlama və bitmə tarixləri


    public string PlanType { get; set; }

    public string AdditionalInfo { get; set; }//Sığorta ilə bağlı əlavə məlumatları saxlayır.
    public int PatientId { get; set; }
    public PatientDto Patient { get; set; }
}

public class InsuranceDetailsReadDto : BaseEntityDto
{
    public string InsuranceProvider { get; set; }


    public DateTime? CoverageStartDate { get; set; }


    public DateTime? CoverageEndDate { get; set; }//Sigortanın başlama və bitmə tarixləri


    public string PlanType { get; set; }

    public string AdditionalInfo { get; set; }//Sığorta ilə bağlı əlavə məlumatları saxlayır.
    public int PatientId { get; set; }
    public PatientDto Patient { get; set; }
}

public class InsuranceDetailsUpdateDto : BaseEntityDto
{
    public string InsuranceProvider { get; set; }


    public DateTime? CoverageStartDate { get; set; }


    public DateTime? CoverageEndDate { get; set; }//Sigortanın başlama və bitmə tarixləri


    public string PlanType { get; set; }

    public string AdditionalInfo { get; set; }//Sığorta ilə bağlı əlavə məlumatları saxlayır.
    public int PatientId { get; set; }
    public PatientDto Patient { get; set; }
}


public class InsuranceDetailsDeleteDto : BaseEntityDto
{

}
