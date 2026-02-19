using System.Net;
using HastaneOtomasyon.Core.ReturnTypes;
using HastaneOtomasyon.DataAccess;
using HastaneOtomasyon.Models;
using HastaneOtomasyon.Models.Dtos.Medicines;

namespace HastaneOtomasyon.Service

{

    public class MedicineService
    {
        private AppDbContext _context;

        public MedicineService(AppDbContext context)
        {
            _context = context;
        }
        public ResponseModel.ResponseDataModel<Medicine> Add(MedicineAddRequestDto dto)
        {
            var medicine = new Medicine
            {
                Name = dto.Name,
                Type = dto.Type,
                
            };

            _context.Medicines.Add(medicine);
            _context.SaveChanges();

            return new ResponseModel.ResponseDataModel<Medicine> { 
                Data = medicine, 
                Success = true, 
                Message = "İlaç sisteme eklendi." 
            };
        }

        public ResponseModel.ResponseDataModel<List<Medicine>>? GetAll()
        {
            var medicines = _context.Medicines.ToList();
            return new ResponseModel.ResponseDataModel<List<Medicine>>
            {
                Data = medicines,
                Success = true,
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}