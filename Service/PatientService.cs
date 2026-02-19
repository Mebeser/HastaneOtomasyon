using HastaneOtomasyon.DataAccess;
using HastaneOtomasyon.Models;
using HastaneOtomasyon.Models.Dtos.Patients;
using HastaneOtomasyon.Core.ReturnTypes; // Yeni ekledik
using System.Net;

namespace HastaneOtomasyon.Service
{
    public class PatientService
    {
        private AppDbContext _context;

        public PatientService(AppDbContext context)
        {
            _context = context;
        }

        public ResponseModel.ResponseDataModel<Patient> Add(PatientAddRequestDto dto)
        {
            
            var isPresent = _context.Patients.Any(c => c.TCNo == dto.TCNo);

            if (isPresent)
            {
                return new ResponseModel.ResponseDataModel<Patient>
                {
                    Success = false,
                    Message = "Bu TC kimlik numarası ile kayıtlı bir hasta bulunuyor",
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                };
            }

            var patient = new Patient
            {
                TCNo = dto.TCNo,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                BirthDate = dto.BirthDate,
                Gender = dto.Gender,
                Phone = dto.Phone,
                Address = dto.Address
            };

            _context.Patients.Add(patient);
            _context.SaveChanges();

            return new ResponseModel.ResponseDataModel<Patient>
            {
                Data = patient,
                Success = true,
                Message = "Hasta başarıyla kaydedildi.",
                StatusCode = HttpStatusCode.Created
            };
        }

        public ResponseModel.ResponseDataModel<List<Patient>> GetAll()
        {
            var patients = _context.Patients.ToList();
            return new ResponseModel.ResponseDataModel<List<Patient>>
            {
                Data = patients,
                Success = true,
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}