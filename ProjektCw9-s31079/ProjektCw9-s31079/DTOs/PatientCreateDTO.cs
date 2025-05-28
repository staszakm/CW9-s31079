using System.ComponentModel.DataAnnotations;

namespace ProjektCw9_s31079.DTOs;

public class PatientCreateDTO
{
    public int? IdPatient { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }
    
    [Required]
    public DateTime Birthdate { get; set; }
}