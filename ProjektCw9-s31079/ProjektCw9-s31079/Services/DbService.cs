using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektCw9_s31079.Data;
using ProjektCw9_s31079.DTOs;
using ProjektCw9_s31079.Models;

namespace ProjektCw9_s31079.Services;

public interface IDbService
{
    public Task<ICollection<PatientGetDTO>> GetPatientsAsync();
    public Task<IActionResult> AddPrescriptionAsync(PrescriptionCreateDTO prescription);
}

public class DbService(AppDbContext data) : IDbService 
{
    public async Task<ICollection<PatientGetDTO>> GetPatientsAsync()
    {
        return await data.Patients.Select(pt => new PatientGetDTO
        {
            IdPatient = pt.IdPatient,
            FirstName = pt.FirstName,
            LastName = pt.LastName,
            Birthdate = pt.Birthdate,
            Prescriptions = pt.Prescriptions.OrderByDescending(pr => pr.DueDate).Select(pr => new PrescriptionGetDTO
            {
                IdPrescription = pr.IdPrescription,
                Date = pr.Date,
                DueDate = pr.DueDate,
                Medicaments = pr.PrescriptionMedicaments.Select(med => new MedicamentsGetDTO
                {
                    IdMedicament = med.Medicament.IdMedicament,
                    Name = med.Medicament.Name,
                    Dose = med.Dose,
                    Description = med.Medicament.Description,
                }).ToList(),
                Doctor = new DoctorGetDTO
                {
                    IdDoctor = pr.Doctor.IdDoctor,
                    FirstName = pr.Doctor.FirstName,
                }
            }).ToList(),

        }).ToListAsync();
    }

    public async Task<IActionResult> AddPrescriptionAsync(PrescriptionCreateDTO prescription)
    {
        if (prescription.DueDate < prescription.Date)
        {
            return new BadRequestObjectResult("Data przydatności nie może być przeszła");
        }

        if (prescription.Medicaments == null || prescription.Medicaments.Count() == 0 || prescription.Medicaments.Count() > 10)
        {
            return new BadRequestObjectResult("Brak lub zbyt wiele dodanych leków");
        }
        
        var allMedIds = prescription.Medicaments.Select(m => m.IdMedicament).ToList();
        var existingMeds = await data.Medicaments
            .Where(m => allMedIds.Contains(m.IdMedicament))
            .Select(m => m.IdMedicament)
            .ToListAsync();

        if (existingMeds.Count != allMedIds.Count)
            return new BadRequestObjectResult("Podano nie istniejący lek");
        
        Patient patient;
        if (prescription.Patient.IdPatient != 0)
        {
            patient = await data.Patients.FindAsync(prescription.Patient.IdPatient);
            if (patient == null)
            {
                patient = new Patient
                {
                    FirstName = prescription.Patient.FirstName,
                    LastName = prescription.Patient.LastName,
                    Birthdate = prescription.Patient.Birthdate
                };
                data.Patients.Add(patient);
                await data.SaveChangesAsync();
            }
        }
        else
        {
            patient = new Patient
            {
                FirstName = prescription.Patient.FirstName,
                LastName = prescription.Patient.LastName,
                Birthdate = prescription.Patient.Birthdate
            };
            data.Patients.Add(patient);
            await data.SaveChangesAsync();
        }
        
        var doctor = await data.Doctors.FindAsync(prescription.IdDoctor);
        if (doctor == null)
            return new BadRequestObjectResult("Lekarz nie istnieje.");
        
        var newPrescript = new Prescription
        {
            Date = prescription.Date,
            DueDate = prescription.DueDate,
            IdPatient = patient.IdPatient,
            IdDoctor = prescription.IdDoctor
        };
        data.Prescriptions.Add(newPrescript);
        await data.SaveChangesAsync();
        
        var prescriptionMedicaments = prescription.Medicaments.Select(m => new Prescription_Medicament
        {
            IdPrescription = newPrescript.IdPrescription,
            IdMedicament = m.IdMedicament,
            Dose = m.Dose,
            Details = m.Details
        }).ToList();

        data.Prescription_Medicaments.AddRange(prescriptionMedicaments);
        await data.SaveChangesAsync();

        return new OkObjectResult("Recepta została dodana");
    }
    
    
}