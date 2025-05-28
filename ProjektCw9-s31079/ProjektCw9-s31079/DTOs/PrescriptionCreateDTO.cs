using System.ComponentModel.DataAnnotations;
using ProjektCw9_s31079.Models;

namespace ProjektCw9_s31079.DTOs;

public class PrescriptionCreateDTO
{
    [Required]
    public PatientGetDTO Patient { get; set; }
    [Required]
    public List<Prescription_MedicamentCreateDTO> Medicaments { get; set; }
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public DateTime DueDate { get; set; }
    [Required]
    public int IdDoctor { get; set; }
}