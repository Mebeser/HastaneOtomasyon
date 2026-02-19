using HastaneOtomasyon.Models.Dtos.MedicalRecords;
using HastaneOtomasyon.Service;
using Microsoft.AspNetCore.Mvc;

namespace HastaneOtomasyon.Controllers;

[ApiController]
[Route("api/medical-records")]
public class MedicalRecordsController : ControllerBase
{
    private MedicalRecordService _medicalRecordService;

    public MedicalRecordsController(MedicalRecordService medicalRecordService)
    {
        _medicalRecordService = medicalRecordService;
    }

    [HttpPost("create")]
    public IActionResult Add(MedicalRecordAddRequestDto dto)
    {
        var result = _medicalRecordService.Add(dto);
        if (!result.Success) return BadRequest(result);
        return Ok(result);
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_medicalRecordService.GetAll());
}