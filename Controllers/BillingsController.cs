using HastaneOtomasyon.Models.Dtos.Billings;
using HastaneOtomasyon.Service;
using Microsoft.AspNetCore.Mvc;

namespace HastaneOtomasyon.Controllers;

[ApiController]
[Route("api/billings")]
public class BillingsController : ControllerBase
{
    private BillingService _billingService;

    public BillingsController(BillingService billingService)
    {
        _billingService = billingService;
    }

    [HttpPost("create")]
    public IActionResult Add(BillingAddRequestDto dto)
    {
        var result = _billingService.Add(dto);
        if (!result.Success) return BadRequest(result);
        return Ok(result);
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_billingService.GetAll());
}

