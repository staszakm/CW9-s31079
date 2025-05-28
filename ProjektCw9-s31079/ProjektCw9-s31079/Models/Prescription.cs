using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektCw9_s31079.Models;

[Table("Prescriptions")]
public class Prescription
{
    [Key]
    public int IdPrescription { get; set; }
    
    public DateTime Date { get; set; }
    
    public DateTime DueDate { get; set; }
    
    public int IdPatient { get; set; }
    
    public int IdDoctor { get; set; }

    [ForeignKey("IdPatient")] 
    public virtual Patient Patient { get; set; } = null!;

    [ForeignKey("IdDoctor")] 
    public virtual Doctor Doctor { get; set; } = null!;

    public virtual ICollection<Prescription_Medicament> PrescriptionMedicaments { get; set; } = null!;
    
}