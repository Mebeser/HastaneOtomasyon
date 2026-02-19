using HastaneOtomasyon.DataAccess;
using HastaneOtomasyon.Models;
using HastaneOtomasyon.Models.Dtos.Doctors;
using HastaneOtomasyon.Core.ReturnTypes;
using System.Net;

namespace HastaneOtomasyon.Service
{
    public class DoctorService
    {
        private AppDbContext _context;

        public DoctorService(AppDbContext context)
        {
            _context = context;
        }

        public ResponseModel.ResponseDataModel<Doctor> Add(DoctorAddRequestDto dto)
        {
           
            var isPresent = _context.Departments.Any(d => d.Id == dto.DepartmentId);
    
            if (!isPresent) // Eğer bölüm mevcut DEĞİLSE
            {
                return new ResponseModel.ResponseDataModel<Doctor>
                {
                    Success = false,
                    Message = "Belirtilen poliklinik bulunamadı!",
                    StatusCode = HttpStatusCode.NotFound
                };
            }

            var doctor = new Doctor
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Title = dto.Title,
                DepartmentId = dto.DepartmentId
            };

            _context.Doctors.Add(doctor);
            _context.SaveChanges();

            return new ResponseModel.ResponseDataModel<Doctor>
            {
                Data = doctor,
                Success = true,
                Message = "Doktor başarıyla kaydedildi.",
                StatusCode = HttpStatusCode.Created
            };
        }

        public ResponseModel.ResponseDataModel<List<Doctor>> GetAll()
        {
            return new ResponseModel.ResponseDataModel<List<Doctor>>
            {
                Data = _context.Doctors.ToList(),
                Success = true
            };
        }
    }
}