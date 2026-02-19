namespace HastaneOtomasyon.Service;
using HastaneOtomasyon.DataAccess;
using HastaneOtomasyon.Models;
using HastaneOtomasyon.Models.Dtos.Departments;

public class DepartmentService
{
    private AppDbContext _context;

    public DepartmentService(AppDbContext context)
    {
        _context = context;
    }

    
    public Department Add(DepartmentAddRequestDto dto)
    {
        
        var department = new Department
        {
            Name = dto.Name,
            Description = dto.Description
        };

        _context.Departments.Add(department);
        _context.SaveChanges();

        return department;
    }

   
    public List<Department> GetAll()
    {
        return _context.Departments.ToList();
    }

    
    public Department GetById(int id)
    {
        var department = _context.Departments.FirstOrDefault(x => x.Id == id);
        if (department == null)
        {
            throw new Exception("Bu İd ile ilgili bir poliklinik yoktur");
        }
        return department;
    }

    
    public string Delete(int id)
    {
        var department = GetById(id); // Önce bul (bulamazsa üstteki hata fırlar)
        _context.Departments.Remove(department);
        _context.SaveChanges();
            
        return "poliklinik başarıyla silindi";
    }
}
