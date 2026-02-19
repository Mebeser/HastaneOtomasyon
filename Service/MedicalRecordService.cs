using System.Net;
using HastaneOtomasyon.Core.ReturnTypes;
using HastaneOtomasyon.DataAccess;
using HastaneOtomasyon.Models;
using HastaneOtomasyon.Models.Dtos.MedicalRecords;

namespace HastaneOtomasyon.Service
{
    public class MedicalRecordService
    {
        private AppDbContext _context;

        public MedicalRecordService(AppDbContext context)
        {
            _context = context;
        }
        
        public ResponseModel.ResponseDataModel<MedicalRecord> Add(MedicalRecordAddRequestDto dto)
        {
            var isPresent = _context.Appointments.Any(a => a.Id == dto.AppointmentId);
            if (!isPresent)
            {
                return new ResponseModel.ResponseDataModel<MedicalRecord> 
                    { Success = false,
                     Message = "Randevu bulunamadı!", 
                     StatusCode = HttpStatusCode.NotFound };
            }

            var record = new MedicalRecord {
                AppointmentId = dto.AppointmentId,
                Diagnosis = dto.Diagnosis,
                TreatmentPlan = dto.TreatmentPlan,
                CheckUpDate = dto.CheckUpDate
            };

            _context.MedicalRecords.Add(record);
            _context.SaveChanges();
            return new ResponseModel.ResponseDataModel<MedicalRecord> 
            { Data = record, 
                Success = true, 
                Message = "Muayene kaydı başarıyla eklendi." };

            
        }

        public ResponseModel.ResponseDataModel<List<MedicalRecord>> GetAll()
        {
            var records = _context.MedicalRecords.ToList();
            return new ResponseModel.ResponseDataModel<List<MedicalRecord>>
            {
                Data = records,
                Success = true,
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}
