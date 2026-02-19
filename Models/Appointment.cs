namespace HastaneOtomasyon.Models;

public class Appointment : Entity
{
    public int PatientId { get; set; } 
    public int DoctorId { get; set; } 
    public DateTime AppointmentDate { get; set; }
    public string Complaint { get; set; }
    public bool? IsCancelled { get; set; } = false;

    public Patient Patient { get; set; }
    public Doctor Doctor { get; set; }
    public MedicalRecord MedicalRecord { get; set; } 
}