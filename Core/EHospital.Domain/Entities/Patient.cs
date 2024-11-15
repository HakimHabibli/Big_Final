﻿namespace EHospital.Domain.Entities;

public class Patient : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public string Address { get; set; }
    //SerialNumber əlavə olunmalıdır
    public string SerialNumber { get; set; }

    public int? ContactInfoId { get; set; }
    public ContactInfo ContactInfo { get; set; }

    public int?   HospitalId { get; set; } 
    public string? HospitalName { get; set; }

    public Hospital? Hospital { get; set; }

    public EmergencyContact EmergencyContact { get; set; }
    public int? EmergencyContactId { get; set; }

    public InsuranceDetails InsuranceDetails { get; set; }//Sığorta təfərrüatları
    public int? InsuranceDetailsId { get; set; }

    public ICollection<MedicalHistory>? MedicalHistories { get; set; }
    public ICollection<Allergy>? Allergies { get; set; }
    public ICollection<PatientDoctor>? PatientDoctors { get; set; } // Əlaqə cədvəli
    public ICollection<Appointment>? Appointments { get; set; }


}