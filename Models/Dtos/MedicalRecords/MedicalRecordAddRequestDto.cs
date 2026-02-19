namespace HastaneOtomasyon.Models.Dtos.MedicalRecords
{
    public class MedicalRecordAddRequestDto
    {
        public int AppointmentId { get; set; }
        public string Diagnosis { get; set; }
        public string TreatmentPlan { get; set; }
        public DateTime? CheckUpDate { get; set; }
    }
}