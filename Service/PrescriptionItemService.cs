using HastaneOtomasyon.Core.ReturnTypes;
using HastaneOtomasyon.DataAccess;
using HastaneOtomasyon.Models;
using HastaneOtomasyon.Models.Dtos.PrescriptionItem;

namespace HastaneOtomasyon.Service;

public class PrescriptionItemService
{
    private AppDbContext _context;
    
    public PrescriptionItemService(AppDbContext context)
    {
        _context = context;
    }
    public ResponseModel.ResponseDataModel<PrescriptionItem> Add(PrescriptionItemAddRequestDto dto)
    {
        var isPrescriptionPresent = _context.Prescriptions.Any(p => p.Id == dto.PrescriptionId);
        var isMedicinePresent = _context.Medicines.Any(m => m.Id == dto.MedicineId);

        if (!isPrescriptionPresent || !isMedicinePresent)
        {
            return new ResponseModel.ResponseDataModel<PrescriptionItem> 
            { Success = false,
                Message = "Reçete veya İlaç bulunamadı!" };
        }

        var item = new PrescriptionItem
        {
            PrescriptionId = dto.PrescriptionId,
            MedicineId = dto.MedicineId,
            Dosage = dto.Dosage
        };

        _context.PrescriptionItems.Add(item);
        _context.SaveChanges();

        return new ResponseModel.ResponseDataModel<PrescriptionItem> 
            { Data = item, Success = true,
              Message = "İlaç reçeteye eklendi." };
    }
}