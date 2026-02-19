namespace HastaneOtomasyon.Models;

public class Medicine : Entity
{
    public string Name { get; set; }
    public string Type { get; set; }
    public decimal? Price { get; set; }

    public ICollection<PrescriptionItem> PrescriptionItems { get; set; }
}