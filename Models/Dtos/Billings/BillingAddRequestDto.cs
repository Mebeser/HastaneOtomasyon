namespace HastaneOtomasyon.Models.Dtos.Billings;

public class BillingAddRequestDto
{
    public int PatientId { get; set; }
    public int AppointmentId { get; set; }
    public int TotalAmount { get; set; } 
    public string PaymentStatus { get; set; }
}