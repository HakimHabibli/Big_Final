using EHospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EHospital.Configurations;

public class DoctorSchedulesMapping : BaseAuditableEntityMapping<DoctorSchedules>
{
    public override void Configure(EntityTypeBuilder<DoctorSchedules> builder)
    {
        base.Configure(builder);

        #region Properties

        // Tarix sahəsi
        builder.Property(ds => ds.Date)
              .HasColumnType("date")
              .IsRequired();

        // Başlama vaxtı sahəsi
        builder.Property(ds => ds.StartTime)
              .HasColumnType("time")
              .IsRequired();

        // Bitiş vaxtı sahəsi
        builder.Property(ds => ds.EndTime)
              .HasColumnType("time")
              .IsRequired();

        #endregion

        #region Relation
        // Xarici açar əlaqəsi
        builder.HasOne(ds => ds.Doctor)
              .WithMany(d => d.DoctorSchedules)
              .HasForeignKey(ds => ds.DoctorId)
              .OnDelete(DeleteBehavior.SetNull);
        #endregion



    }
}

