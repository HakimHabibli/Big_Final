using EHospital.Domain.Common;

namespace EHospital.Domain.Entities;

public class InsuranceDetails : BaseEntity
{

    public string InsuranceProvider { get; set; }


    public DateTime? CoverageStartDate { get; set; }


    public DateTime? CoverageEndDate { get; set; }//Sigortanın başlama və bitmə tarixləri


    public string PlanType { get; set; }

    public string AdditionalInfo { get; set; }//Sığorta ilə bağlı əlavə məlumatları saxlayır.
    public int PatientId { get; set; }
    public Patient Patient { get; set; }
}