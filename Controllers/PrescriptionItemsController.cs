using HastaneOtomasyon.Models.Dtos.PrescriptionItem;
using HastaneOtomasyon.Service;
using Microsoft.AspNetCore.Mvc;

namespace HastaneOtomasyon.Controllers;

[ApiController]
[Route("api/prescription-items")]
public class PrescriptionItemsController : ControllerBase
{
    private PrescriptionItemService _prescriptionItemService;

    public PrescriptionItemsController(PrescriptionItemService prescriptionItemService)
    {
        _prescriptionItemService = prescriptionItemService;
    }

    [HttpPost("add-medicine-to-prescription")]
    public IActionResult Add(PrescriptionItemAddRequestDto dto)
    {
        var result = _prescriptionItemService.Add(dto);
        if (!result.Success) return BadRequest(result);
        return Ok(result);
    }
}