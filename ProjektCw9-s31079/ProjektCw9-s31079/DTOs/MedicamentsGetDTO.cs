namespace ProjektCw9_s31079.DTOs;

public class MedicamentsGetDTO
{
    public int IdMedicament { get; set; }
    
    public string Name { get; set; } = null!;
    
    public int? Dose { get; set; }
    public string Description { get; set; } = null!;
    
}