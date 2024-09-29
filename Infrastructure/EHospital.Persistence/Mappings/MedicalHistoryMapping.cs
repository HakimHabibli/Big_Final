using EHospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EHospital.Configurations;

public class MedicalHistoryMapping : BaseEntityMapping<MedicalHistory>
{
    public override void Configure(EntityTypeBuilder<MedicalHistory> builder)
    {
        base.Configure(builder);

        // Özəlliklərin konfiqurasiyası
        builder.Property(mh => mh.Condition)
            .HasMaxLength(100) // Şərtin uzunluğuna görə təyin edin
            .IsRequired();

        builder.Property(mh => mh.DiagnosisDate)
            .IsRequired();

        builder.Property(mh => mh.Treatment)
            .HasMaxLength(500); // Müalicənin uzunluğuna görə təyin edin

        builder.Property(mh => mh.Notes)
            .HasMaxLength(1000); // Qeydlərin uzunluğuna görə təyin edin

        // Əlaqələrin konfiqurasiyası
        builder.HasOne(mh => mh.Patient)
            .WithMany(p => p.MedicalHistories)
            .HasForeignKey(mh => mh.PatientId)
            .OnDelete(DeleteBehavior.SetNull); // MedicalHistory silindikdə müvafiq Patient təsirlənir
    }
}
/*
  dotnet ef migrations add InitialCreate --project EHospital.Persistence --startup-project EHospital.MVC
 Update-Database -Project EHospital.Persistence -StartupProject EHospital.MVC
 */