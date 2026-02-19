namespace HastaneOtomasyon.Models;

public class Department : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Doctor> Doctors { get; set; }
    public ICollection<Room> Rooms { get; set; }

    
    
}