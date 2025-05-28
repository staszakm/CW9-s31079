using System.ComponentModel.DataAnnotations;
using ProjektCw9_s31079.Models;

namespace ProjektCw9_s31079.DTOs;

public class PatientGetDTO
{
    public int IdPatient { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public DateTime Birthdate { get; set; }
    
    public IEnumerable<PrescriptionGetDTO>? Prescriptions { get; set; }
}