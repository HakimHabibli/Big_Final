using EHospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EHospital.Configurations;
public class DoctorMapping : BaseAuditableEntityMapping<Doctor>
{
    public override void Configure(EntityTypeBuilder<Doctor> builder)
    {
        base.Configure(builder);

        builder.HasKey(d => d.Id);

        builder.Property(d => d.FirstName)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(d => d.LastName)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(d => d.Title)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(d => d.Specialization)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(d => d.ContactNumber)
               .IsRequired()
               .HasMaxLength(30);


        builder.Property(d => d.Email)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(d => d.Address)
               .IsRequired()
               .HasMaxLength(250);

        builder.Property(d => d.ImageUrl)
               .IsRequired(false);

        builder.Property(d => d.Bio)
               .HasMaxLength(500);

        builder.HasOne(d => d.Hospital)
                 .WithMany(h => h.Doctors)
                 .HasForeignKey(d => d.HospitalId)
                 .OnDelete(DeleteBehavior.Restrict); // Xəstəxana silindiyində, doktorun xəstəxanasını null olaraq təyin edər

        builder.HasMany(d => d.Appointments)
               .WithOne(a => a.Doctor)
               .HasForeignKey(a => a.DoctorId)
               .OnDelete(DeleteBehavior.Restrict); // Randevu silindiyində, doktorun randevusunu da silər

        builder.HasMany(d => d.PatientDoctors)
               .WithOne(pd => pd.Doctor)
               .HasForeignKey(pd => pd.DoctorId)
               .OnDelete(DeleteBehavior.Restrict); // `PatientDoctor` silindiyində, doktorun `PatientDoctor` qeydini də silər

        #region Prop
        //public string FirstName { get; set; } // Doktorun adı
        //public string LastName { get; set; } // Doktorun soyadı
        //public string Title { get; set; } // Doktorun rütbəsi
        //public string Specialization { get; set; } // Doktorun ixtisası
        //public string ContactNumber { get; set; } // Doktorun əlaqə nömrəsi
        //public string Email { get; set; } // Doktorun elektron poçt ünvanı
        //public string Address { get; set; } // Doktorun ünvanı                                                    
        //public string Bio { get; set; } // Doktor haqqında əlavə məlumat      

        //public int HospitalId { get; set; }  // Xəstəxana ID (nullable)
        //public Hospital Hospital { get; set; } // Xəstəxana obyekti

        //public ICollection<Appointment> Appointments { get; set; } // Doktorun məsləhət vaxtları
        //public ICollection<PatientDoctor> PatientDoctors { get; set; } // Əlaqə cədvəli
        #endregion
    }
}

