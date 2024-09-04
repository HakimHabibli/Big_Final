using EHospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EHospital.Persistence.DAL;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
      : base(options)
    {
    }
    public DbSet<Allergy> Allergies { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<ContactInfo> ContactInfos { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<EmergencyContact> EmergencyContacts { get; set; }
    public DbSet<Hospital> Hospitals { get; set; }
    public DbSet<InsuranceDetails> InsuranceDetails { get; set; }
    public DbSet<MedicalHistory> MedicalHistories { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<PatientDoctor> PatientDoctors { get; set; }
    public DbSet<DoctorSchedules> DoctorSchedules { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}

