using System.Net;
using HastaneOtomasyon.Core.ReturnTypes;
using HastaneOtomasyon.DataAccess;
using HastaneOtomasyon.Models;
using HastaneOtomasyon.Models.Dtos.Billings;

namespace HastaneOtomasyon.Service;

public class BillingService
{
    private readonly AppDbContext _context;

    public BillingService(AppDbContext context)
    {
        _context = context;
    }

    public ResponseModel.ResponseDataModel<Billing> Add(BillingAddRequestDto dto)
    {
        
        var isPatientPresent = _context.Patients.Any(p => p.Id == dto.PatientId);
        var isAppointmentPresent = _context.Appointments.Any(a => a.Id == dto.AppointmentId);

        if (!isPatientPresent || !isAppointmentPresent)
        {
            return new ResponseModel.ResponseDataModel<Billing>
            {
                Success = false,
                Message = "Hasta veya Randevu kaydı bulunamadı!",
                StatusCode = HttpStatusCode.BadRequest
            };
        }

        var billing = new Billing
        {
            PatientId = dto.PatientId,
            AppointmentId = dto.AppointmentId,
            TotalAmount = dto.TotalAmount,
            PaymentStatus = dto.PaymentStatus,
            CreatedDate = DateTime.Now
        };

        _context.Billings.Add(billing);
        _context.SaveChanges();

        return new ResponseModel.ResponseDataModel<Billing>
        {
            Data = billing,
            Success = true,
            Message = "Fatura başarıyla oluşturuldu.",
            StatusCode = HttpStatusCode.Created
        };
    }

    public ResponseModel.ResponseDataModel<List<Billing>> GetAll()
    {
        return new ResponseModel.ResponseDataModel<List<Billing>>
        {
            Data = _context.Billings.ToList(),
            Success = true
        };
    }
}