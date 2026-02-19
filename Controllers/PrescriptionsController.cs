using HastaneOtomasyon.Models.Dtos.Prescriptions;
using HastaneOtomasyon.Service;
using Microsoft.AspNetCore.Mvc;

namespace HastaneOtomasyon.Controllers;

[ApiController]
[Route("api/prescriptions")]
public class PrescriptionsController : ControllerBase
{
    private PrescriptionService _prescriptionService;

    public PrescriptionsController(PrescriptionService prescriptionService)
    {
        _prescriptionService = prescriptionService;
    }

    [HttpPost("create")]
    public IActionResult Add(PrescriptionAddRequestDto dto)
    {
        var result = _prescriptionService.Add(dto);
        if (!result.Success) return BadRequest(result);
        return Ok(result);
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_prescriptionService.GetAll());
}