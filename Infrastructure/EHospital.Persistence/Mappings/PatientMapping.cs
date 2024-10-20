using EHospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EHospital.Configurations;

public class PatientMapping : BaseEntityMapping<Patient>
{
    public override void Configure(EntityTypeBuilder<Patient> builder)
    {
        base.Configure(builder);

        builder.Property(p => p.FirstName)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(p => p.LastName)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(p => p.DateOfBirth)
               .HasDefaultValue(DateTime.UtcNow);

        builder.Property(p => p.SerialNumber)
               .HasMaxLength(10)
               .IsRequired();

        builder.HasOne(p => p.ContactInfo)
               .WithOne(c => c.Patient)
               .HasForeignKey<Patient>(p => p.ContactInfoId)
               //.HasForeignKey(c => c.ContactInfoId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.EmergencyContact)
            .WithOne(ec => ec.Patient)
            .HasForeignKey<Patient>(p => p.EmergencyContactId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.InsuranceDetails)
               .WithOne(id => id.Patient)
               .HasForeignKey<Patient>(p => p.InsuranceDetailsId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(p => p.MedicalHistories)
               .WithOne(mh => mh.Patient)
               .HasForeignKey(mh => mh.PatientId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(p => p.Allergies)
               .WithOne(a => a.Patient)
               .HasForeignKey(a => a.PatientId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(p => p.PatientDoctors)
               .WithOne(pd => pd.Patient)
               .HasForeignKey(pd => pd.PatientId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(p => p.Appointments)
               .WithOne(a => a.Patient)
               .HasForeignKey(a => a.PatientId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Hospital)
               .WithMany(h => h.Patients)
               .HasForeignKey(p => p.HospitalId).IsRequired(false)
               .OnDelete(DeleteBehavior.Restrict);
    }
}

