namespace HastaneOtomasyon.Models;

public class PrescriptionItem : Entity
{
    public int PrescriptionId { get; set; } // Foreign Key
    public int MedicineId { get; set; } // Foreign Key
    public string Dosage { get; set; }
    public int? Count { get; set; }

    public Prescription Prescription { get; set; }
    public Medicine Medicine { get; set; }
}