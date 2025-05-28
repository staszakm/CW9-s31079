using System.ComponentModel.DataAnnotations;
using ProjektCw9_s31079.Models;

namespace ProjektCw9_s31079.DTOs;

public class PrescriptionGetDTO
{
    public int IdPrescription { get; set; }
    
    public DateTime Date { get; set; }
    
    public DateTime DueDate { get; set; }
    
    public IEnumerable<MedicamentsGetDTO> Medicaments { get; set; }
    
    public DoctorGetDTO Doctor { get; set; }
    
}