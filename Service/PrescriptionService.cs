using System.Net;
using HastaneOtomasyon.Core.ReturnTypes;
using HastaneOtomasyon.DataAccess;
using HastaneOtomasyon.Models;
using HastaneOtomasyon.Models.Dtos.Prescriptions;

namespace HastaneOtomasyon.Service;

public class PrescriptionService
{
    private AppDbContext _context;
    
    public  PrescriptionService(AppDbContext context)
    {
        _context = context;
    }
    public ResponseModel.ResponseDataModel<Prescription> Add(PrescriptionAddRequestDto dto)
    {
        var isPresent = _context.MedicalRecords.Any(m => m.Id == dto.RecordId);
        if (!isPresent)
        {
            return new ResponseModel.ResponseDataModel<Prescription> { Success = false, Message = "Muayene kaydı bulunamadı!", StatusCode = HttpStatusCode.NotFound };
        }

        var prescription = new Prescription
        {
            RecordId = dto.RecordId,
            PrescriptionCode = "RX-" + Guid.NewGuid().ToString().Substring(0, 5).ToUpper(),
            Notes = dto.Notes
        };

        _context.Prescriptions.Add(prescription);
        _context.SaveChanges();

        return new ResponseModel.ResponseDataModel<Prescription> 
            { Data = prescription, 
                Success = true, 
                Message = "Reçete oluşturuldu." };
        
    }

    public ResponseModel.ResponseDataModel<List<Prescription>> GetAll()
    {
        var prescriptions = _context.Prescriptions.ToList();
        return new ResponseModel.ResponseDataModel<List<Prescription>>
        {
            Data = prescriptions,
            Success = true,
            StatusCode = HttpStatusCode.OK
        };
    }
}