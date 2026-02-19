using Microsoft.AspNetCore.Mvc;
using HastaneOtomasyon.Models.Dtos.Doctors;
using HastaneOtomasyon.Service;

namespace HastaneOtomasyon.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorsController : ControllerBase
    {
        private readonly DoctorService _doctorService;

        public DoctorsController(DoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpPost("create")]
        public IActionResult Add(DoctorAddRequestDto dto)
        {
            var result = _doctorService.Add(dto);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_doctorService.GetAll());
    }
}