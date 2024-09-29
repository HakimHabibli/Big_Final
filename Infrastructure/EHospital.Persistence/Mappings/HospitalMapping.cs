using EHospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EHospital.Configurations;

public class HospitalMapping : BaseAuditableEntityMapping<Hospital>
{
    public override void Configure(EntityTypeBuilder<Hospital> builder)
    {
        base.Configure(builder);

        builder.HasKey(h => h.Id);
        builder.Property(h => h.Name).HasMaxLength(100).IsRequired();
        builder.Property(h => h.Description).HasMaxLength(255).IsRequired();
        builder.Property(h => h.Address).IsRequired();
        builder.Property(h => h.ContactNumber).HasMaxLength(25).IsRequired();
        builder.Property(h => h.Email).HasMaxLength(100);
        // Hospital konfiqurasiyası
        builder
            .HasMany(h => h.Doctors)
            .WithOne(d => d.Hospital)
            .HasForeignKey(d => d.HospitalId)
            .IsRequired()
            .OnDelete(DeleteBehavior.SetNull);

        builder
            .HasMany(h => h.Patients)
            .WithOne(p => p.Hospital)
            .HasForeignKey(p => p.HospitalId)
            .IsRequired()
            .OnDelete(DeleteBehavior.SetNull);

        #region Prop
        /*
              public int HospitalId { get; set; }+
              public string Name { get; set; } +
              public string Address { get; set; } +
              public string ContactNumber { get; set; } +
              public string Email { get; set; }+
              public string Description { get; set; } +
              public ICollection<Doctor> Doctors { get; set; } +
              public ICollection<Patient> Patients { get; set; }+
         */
        #endregion
    }
}
