using System.ComponentModel.DataAnnotations;

namespace ProjektCw9_s31079.DTOs;

public class Prescription_MedicamentCreateDTO
{
    [Required]
    public int IdMedicament { get; set; }
    public int? Dose { get; set; }
    [Required]
    public string Details { get; set; }
}