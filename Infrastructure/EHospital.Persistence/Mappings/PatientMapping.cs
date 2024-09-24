﻿using EHospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EHospital.Configurations;

public class PatientMapping : BaseEntityMapping<Patient>
{
    public override void Configure(EntityTypeBuilder<Patient> builder)
    {
        base.Configure(builder);

        // Özelliklerin yapılandırılması
        builder.Property(p => p.FirstName)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(p => p.LastName)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(p => p.DateOfBirth)
               .HasDefaultValue(DateTime.UtcNow);

        // İlişkilerin yapılandırılması
        builder.HasOne(p => p.ContactInfo)
               .WithOne(c => c.Patient).HasForeignKey<Patient>(p => p.ContactInfoId)
               //.HasForeignKey(c => c.ContactInfoId)
               .OnDelete(DeleteBehavior.Restrict); // İletişim bilgisi silindiğinde hasta etkilenmez

        builder.HasOne(p => p.EmergencyContact)
            .WithOne(ec => ec.Patient) // Təcili əlaqə bir xəstəyə aid
            .HasForeignKey<Patient>(p => p.EmergencyContactId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.InsuranceDetails)
               .WithOne(id => id.Patient) // Sığorta məlumatı bir xəstəyə aid
               .HasForeignKey<Patient>(p => p.InsuranceDetailsId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(p => p.MedicalHistories)
               .WithOne(mh => mh.Patient)
               .HasForeignKey(mh => mh.PatientId)
               .OnDelete(DeleteBehavior.Restrict); // Tıbbi geçmiş silindiğinde hasta etkilenir

        builder.HasMany(p => p.Allergies)
               .WithOne(a => a.Patient)
               .HasForeignKey(a => a.PatientId)
               .OnDelete(DeleteBehavior.Restrict); // Alerji silindiğinde hasta etkilenir

        builder.HasMany(p => p.PatientDoctors)
               .WithOne(pd => pd.Patient)
               .HasForeignKey(pd => pd.PatientId)
               .OnDelete(DeleteBehavior.Restrict); // Doktor ilişiği silindiğinde hasta etkilenir

        builder.HasMany(p => p.Appointments)
               .WithOne(a => a.Patient)
               .HasForeignKey(a => a.PatientId)
               .OnDelete(DeleteBehavior.Restrict); // Randevu silindiğinde hasta etkilenir

        builder.HasOne(p => p.Hospital)
               .WithMany(h => h.Patients)
               .HasForeignKey(p => p.HospitalId)
               .OnDelete(DeleteBehavior.Restrict); // Xəstəxana silindiğinde hasta etkilenmez, HospitalId null olarak ayarlanır
    }
}
//public class PatientMapping : BaseEntityMapping<Patient>
//{
//    public override void Configure(EntityTypeBuilder<Patient> builder)
//    {
//        base.Configure(builder);

//        // Özelliklerin yapılandırılması
//        builder.Property(p => p.FirstName)
//               .HasMaxLength(50)
//               .IsRequired();

//        builder.Property(p => p.LastName)
//               .HasMaxLength(50)
//               .IsRequired();

//        builder.Property(p => p.DateOfBirth)
//               .HasDefaultValue(DateTime.UtcNow);

//        // İlişkilerin yapılandırılması
//        builder.HasOne(p => p.ContactInfo)
//               .WithMany()
//               .HasForeignKey(p => p.ContactInfoId)
//               .OnDelete(DeleteBehavior.Restrict); // İletişim bilgisi silindiğinde hasta etkilenmez

//        builder.HasOne(p => p.EmergencyContact)
//               .WithMany()
//               .HasForeignKey(p => p.EmergencyContactId)
//               .OnDelete(DeleteBehavior.Restrict); // Təcili əlaqə silindiğinde hasta etkilenmez

//        builder.HasOne(p => p.InsuranceDetails)
//               .WithMany()
//               .HasForeignKey(p => p.InsuranceDetailsId)
//               .OnDelete(DeleteBehavior.Restrict); // Sığorta məlumatları silindiğinde hasta etkilenmez

//        builder.HasMany(p => p.MedicalHistories)
//               .WithOne(mh => mh.Patient)
//               .HasForeignKey(mh => mh.PatientId)
//               .OnDelete(DeleteBehavior.Restrict); // Tıbbi geçmiş silindiğinde hasta etkilenir

//        builder.HasMany(p => p.Allergies)
//               .WithOne(a => a.Patient)
//               .HasForeignKey(a => a.PatientId)
//               .OnDelete(DeleteBehavior.Restrict); // Alerji silindiğinde hasta etkilenir

//        builder.HasMany(p => p.PatientDoctors)
//               .WithOne(pd => pd.Patient)
//               .HasForeignKey(pd => pd.PatientId)
//               .OnDelete(DeleteBehavior.Restrict); // Doktor ilişiği silindiğinde hasta etkilenir

//        builder.HasMany(p => p.Appointments)
//               .WithOne(a => a.Patient)
//               .HasForeignKey(a => a.PatientId)
//               .OnDelete(DeleteBehavior.Restrict); // Randevu silindiğinde hasta etkilenir

//        builder.HasOne(p => p.Hospital)
//               .WithMany(h => h.Patients)
//               .HasForeignKey(p => p.HospitalId)
//               .OnDelete(DeleteBehavior.SetNull); // Xəstəxana silindiğinde hasta etkilenmez, HospitalId null olarak ayarlanır
//    }
// }