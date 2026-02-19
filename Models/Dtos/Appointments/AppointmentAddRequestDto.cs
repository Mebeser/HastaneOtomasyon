namespace HastaneOtomasyon.Models.Dtos.Appointments
{
    public class AppointmentAddRequestDto
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        
    }
}