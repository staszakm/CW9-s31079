using Microsoft.EntityFrameworkCore;
using ProjektCw9_s31079.Models;

namespace ProjektCw9_s31079.Data;

public class AppDbContext : DbContext
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    
    
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
    modelBuilder.Entity<Doctor>().HasData(
        new Doctor { IdDoctor = 1, FirstName = "Andrzej", LastName = "Nowak", Email = "andrzej@gmail.com" },
        new Doctor { IdDoctor = 2, FirstName = "Maria", LastName = "Kowalska", Email = "maria.kowalska@clinic.pl" },
        new Doctor { IdDoctor = 3, FirstName = "Tomasz", LastName = "Wiśniewski", Email = "tomasz.wisniewski@clinic.pl" }
    );

    
    modelBuilder.Entity<Patient>().HasData(
        new Patient { IdPatient = 1, FirstName = "Jan", LastName = "Kowalski", Birthdate = new DateTime(1985, 5, 12) },
        new Patient { IdPatient = 2, FirstName = "Anna", LastName = "Nowicka", Birthdate = new DateTime(1990, 8, 23) },
        new Patient { IdPatient = 3, FirstName = "Piotr", LastName = "Zieliński", Birthdate = new DateTime(1978, 2, 3) }
    );

    
    modelBuilder.Entity<Medicament>().HasData(
        new Medicament { IdMedicament = 1, Name = "Ibuprofen", Description = "Lek przeciwbólowy", Type = "Tabletka" },
        new Medicament { IdMedicament = 2, Name = "Paracetamol", Description = "Lek przeciwgorączkowy", Type = "Tabletka" },
        new Medicament { IdMedicament = 3, Name = "Amoksycylina", Description = "Antybiotyk", Type = "Kapsułka" }
    );

    
    modelBuilder.Entity<Prescription>().HasData(
        new Prescription { IdPrescription = 1, Date = new DateTime(2025, 5, 20), DueDate = new DateTime(2025, 6, 20), IdPatient = 1, IdDoctor = 1 },
        new Prescription { IdPrescription = 2, Date = new DateTime(2025, 5, 21), DueDate = new DateTime(2025, 6, 21), IdPatient = 2, IdDoctor = 2 },
        new Prescription { IdPrescription = 3, Date = new DateTime(2025, 5, 22), DueDate = new DateTime(2025, 6, 22), IdPatient = 3, IdDoctor = 3 },
        new Prescription { IdPrescription = 4, Date = new DateTime(2025, 5, 27), DueDate = new DateTime(2025, 6, 27), IdPatient = 3, IdDoctor = 1 }
    );

    
    modelBuilder.Entity<Prescription_Medicament>().HasData(
        new { IdMedicament = 1, IdPrescription = 1, Dose = 200, Details = "Stosować 2x dziennie" },
        new { IdMedicament = 2, IdPrescription = 1, Dose = 500, Details = "Stosować 1x dziennie" },
        new { IdMedicament = 3, IdPrescription = 2, Dose = 250, Details = "Stosować 3x dziennie" },
        new { IdMedicament = 1, IdPrescription = 2, Dose = 400, Details = "Stosować 1x dziennie po posiłku" },
        new { IdMedicament = 2, IdPrescription = 3, Dose = 1000, Details = "Stosować co 8 godzin" },
        new { IdMedicament = 3, IdPrescription = 3, Dose = 100, Details = "W razie potrzeby" },
        new { IdMedicament = 2, IdPrescription = 4, Dose = 100, Details = "2x dziennie" },
        new { IdMedicament = 1, IdPrescription = 4, Dose = 100, Details = "przed posiłkami" }
    );
    }
}