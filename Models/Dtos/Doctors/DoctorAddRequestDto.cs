namespace HastaneOtomasyon.Models.Dtos.Doctors;

public class DoctorAddRequestDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Title { get; set; } 
    public int DepartmentId { get; set; }
}