using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneOtomasyon.Models;

public class Prescription : Entity
{
    public int RecordId { get; set; } 
    public string PrescriptionCode { get; set; }
    public string Notes { get; set; }
    
    [ForeignKey("RecordId")]
    public MedicalRecord MedicalRecord { get; set; }
    public ICollection<PrescriptionItem> PrescriptionItems { get; set; }
}