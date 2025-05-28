using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjektCw9_s31079.Models;

[Table("Prescription_Medicaments")]
[PrimaryKey("IdMedicament","IdPrescription")]
public class Prescription_Medicament
{
    
    public int IdMedicament { get; set; }
    
    public int IdPrescription { get; set; }
    
    public int? Dose { get; set; }
    
    [MaxLength(100)]
    public string Details { get; set; } = null!;
    
    [ForeignKey("IdMedicament")]
    public virtual Medicament Medicament { get; set; } = null!;
    
    [ForeignKey("IdPrescription")]
    public virtual Prescription Prescription { get; set; } = null!;
    
}