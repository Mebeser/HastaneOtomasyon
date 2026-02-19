namespace HastaneOtomasyon.Models;

public class Billing : Entity
{
    public int PatientId { get; set; } // Foreign Key
    public int AppointmentId { get; set; } // Foreign Key
    public int TotalAmount { get; set; }
    public string PaymentStatus { get; set; }
    public DateTime? InvoiceDate { get; set; }

    public Patient Patient { get; set; }
    public Appointment Appointment { get; set; }
}