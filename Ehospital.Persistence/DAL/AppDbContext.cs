using EHospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EHospital.Persistence.DAL;

public class AppDbContext : DbContext
{
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



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseSqlServer(@"Server=.,1433;Database=MyDatabase;User Id=sa;Password=Your_Strong_Password123!;TrustServerCertificate=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}

