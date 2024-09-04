using EHospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EHospital.Configurations;

public class PatientDoctorMapping : IEntityTypeConfiguration<PatientDoctor>
{
    public void Configure(EntityTypeBuilder<PatientDoctor> builder)
    {
        builder.HasKey(pd => new { pd.PatientId, pd.DoctorId });

        #region Relationships

        builder.HasOne(pd => pd.Patient)
               .WithMany(p => p.PatientDoctors)
               .HasForeignKey(pd => pd.PatientId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(pd => pd.Doctor)
               .WithMany(d => d.PatientDoctors)
               .HasForeignKey(pd => pd.DoctorId)
               .OnDelete(DeleteBehavior.Restrict);
        #endregion

    }
}


