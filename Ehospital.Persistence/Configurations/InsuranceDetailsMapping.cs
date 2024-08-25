using EHospital.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EHospital.Configurations;

public class InsuranceDetailsMapping : BaseEntityMapping<InsuranceDetails> 
{
    public override void Configure(EntityTypeBuilder<InsuranceDetails> builder)
    {
        base.Configure(builder);

        #region Properties
        builder.Property(i=>i.InsuranceProvider).HasMaxLength(75).IsRequired();
        builder.Property(i=>i.PlanType).HasMaxLength(50).IsRequired();
        builder.Property(i=>i.AdditionalInfo).HasMaxLength(100).IsRequired();
        #endregion

        #region Relationships
        builder.HasOne(i => i.Patient).WithOne(p => p.InsuranceDetails).HasForeignKey<Patient>(p=>p.InsuranceDetailsId);
        #endregion

        #region Prop
        /*
        public string InsuranceProvider { get; set; }+
        public DateTime? CoverageStartDate { get; set; }+
        public DateTime? CoverageEndDate { get; set; }//Sigortanın başlama və bitmə tarixləri+
        public string PlanType { get; set; }+
        public string AdditionalInfo { get; set; }//Sığorta ilə bağlı əlavə məlumatları saxlayır. +
        public int PatientId { get; set; }+
        public Patient Patient { get; set; }+
        */
        #endregion
    }
}
