using EHospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EHospital.Configurations;

public class AllergyMapping : BaseEntityMapping<Allergy>
{
    public override void Configure(EntityTypeBuilder<Allergy> builder)
    {
        base.Configure(builder);

        builder.Property(a => a.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(a => a.Details)
               .HasMaxLength(500);

        builder.Property(a => a.Severity)
               .IsRequired();

        builder.HasOne(a => a.Patient)
               .WithMany(p => p.Allergies)
               .HasForeignKey(a => a.PatientId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}

