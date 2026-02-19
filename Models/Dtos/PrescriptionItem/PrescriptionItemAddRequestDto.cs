namespace HastaneOtomasyon.Models.Dtos.PrescriptionItem;

public class PrescriptionItemAddRequestDto
{
    public int PrescriptionId { get; set; }
    public int MedicineId { get; set; }
    public string Dosage { get; set; }
}