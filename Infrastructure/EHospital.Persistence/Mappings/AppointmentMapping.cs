using EHospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EHospital.Configurations;

public class AppointmentMapping : BaseEntityMapping<Appointment>
{
    public override void Configure(EntityTypeBuilder<Appointment> builder)
    {
        base.Configure(builder);

        // Primary key
        builder.HasKey(a => a.Id);

        #region Properties
        builder.Property(a => a.DoctorId)
          .IsRequired(false);

        builder.Property(a => a.PatientId)
            .IsRequired(false);

        builder.Property(a => a.AppointmentDate)
            .IsRequired();

        builder.Property(a => a.Notes)
            .HasMaxLength(500); // Uzunluğu lazım olan ölçüyə görə təyin edin

        builder.Property(a => a.IsConfirmed)
            .IsRequired();
        #endregion

        #region Relationships

        builder.HasOne(a => a.Doctor)
       .WithMany(d => d.Appointments)
       .HasForeignKey(a => a.DoctorId)
       .OnDelete(DeleteBehavior.SetNull); // Doktor silindikdə appointment təsirlənməz

        builder.HasOne(a => a.Patient)
            .WithMany(p => p.Appointments)
            .HasForeignKey(a => a.PatientId)
            .OnDelete(DeleteBehavior.Restrict); // Xəstə silindikdə appointment təsirlənməz
        #endregion

        #region Prop
        /*
          public int DoctorId { get; set; }+
        public Doctor Doctor { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public DateTime AppointmentDate { get; set; }
        // Randevu vaxt slotu (misal üçün: "09:00 - 10:00")
        public string TimeSlot { get; set; }

        public string Notes { get; set; }
        public bool IsConfirmed { get; set; } // Randevu təsdiqlənib-təsdiqlənmədiyini göstərir
        
         */
        #endregion
    }
}