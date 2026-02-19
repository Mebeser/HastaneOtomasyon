namespace HastaneOtomasyon.Models.Dtos.Patients;

public class PatientAddRequestDto
{
    
        public string TCNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    
}