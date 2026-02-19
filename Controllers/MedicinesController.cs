using Microsoft.AspNetCore.Mvc;
using HastaneOtomasyon.Models.Dtos.Medicines;
using HastaneOtomasyon.Service;

namespace HastaneOtomasyon.Controllers;

[ApiController]
[Route("api/medicines")]
public class MedicinesController : ControllerBase
{
    private readonly MedicineService _medicineService;

    public MedicinesController(MedicineService medicineService)
    {
        _medicineService = medicineService;
    }

    [HttpPost("create")]
    public IActionResult Add(MedicineAddRequestDto dto)
    {
        var result = _medicineService.Add(dto);
        if (!result.Success) return BadRequest(result);
        return Ok(result);
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_medicineService.GetAll());
}