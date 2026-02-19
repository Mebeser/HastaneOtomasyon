namespace HastaneOtomasyon.Models;

public class Room : Entity
{
    public int DepartmentId { get; set; } // Foreign Key
    public string RoomNumber { get; set; }
    public int? Capacity { get; set; }

    public Department Department { get; set; }
}