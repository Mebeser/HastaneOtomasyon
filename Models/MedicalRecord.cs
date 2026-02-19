using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneOtomasyon.Models;

public class MedicalRecord :Entity
{
    public int AppointmentId { get; set; } // Foreign Key
    public string Diagnosis { get; set; }
    public string TreatmentPlan { get; set; }
    public DateTime? CheckUpDate { get; set; }
    
    [ForeignKey("AppointmentId")]
    public Appointment Appointment { get; set; }
    public Prescription Prescription { get; set; } // One-to-One
}