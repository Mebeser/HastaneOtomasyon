using HastaneOtomasyon.DataAccess;
using HastaneOtomasyon.Models;
using HastaneOtomasyon.Models.Dtos.Appointments;
using HastaneOtomasyon.Core.ReturnTypes;
using System.Net;

namespace HastaneOtomasyon.Service
{
    public class AppointmentService
    {
        private readonly AppDbContext _context;

        public AppointmentService(AppDbContext context)
        {
            _context = context;
        }

        public ResponseModel.ResponseDataModel<Appointment> Add(AppointmentAddRequestDto dto)
        {
            
            var isPresent = _context.Patients.Any(c => c.Id == dto.PatientId);
            if (!isPresent)
            {
                return new ResponseModel.ResponseDataModel<Appointment> 
                    { Success = false, 
                      Message = "Hasta bulunamadı!", 
                      StatusCode = HttpStatusCode.NotFound };
            }

            
            var isDoctorPresent = _context.Doctors.Any(d => d.Id == dto.DoctorId);
            if (!isDoctorPresent)
            {
                return new ResponseModel.ResponseDataModel<Appointment> 
                    { Success = false, 
                      Message = "Doktor bulunamadı!", 
                      StatusCode = HttpStatusCode.NotFound };
            }

            var appointment = new Appointment
            {
                PatientId = dto.PatientId,
                DoctorId = dto.DoctorId,
                AppointmentDate = dto.AppointmentDate,
                
            };

            _context.Appointments.Add(appointment);
            _context.SaveChanges();

            return new ResponseModel.ResponseDataModel<Appointment>
            {
                Data = appointment,
                Success = true,
                Message = "Randevu başarıyla oluşturuldu.",
                StatusCode = HttpStatusCode.Created
            };
        }

        public ResponseModel.ResponseDataModel<List<Appointment>> GetAll()
        {
            return new ResponseModel.ResponseDataModel<List<Appointment>>
            {
                Data = _context.Appointments.ToList(),
                Success = true
            };
        }
    }
}