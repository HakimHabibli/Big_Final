using EHospital.Domain.Entities;
using EHospital.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EHospital.Persistence.DAL;

public class AppDbContext : IdentityDbContext<AppUser,AppRole,string>
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
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
    /*
     *Add-Migration AddDoctorSchedule -Project EHospital.Persistence -StartupProject EHospital.API
 
     Update-Database -Project EHospital.Persistence -StartupProject EHospital.API

     */
}

