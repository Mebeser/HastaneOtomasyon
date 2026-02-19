using Microsoft.AspNetCore.Mvc;
using HastaneOtomasyon.Models.Dtos.Appointments;
using HastaneOtomasyon.Service;

namespace HastaneOtomasyon.Controllers
{
    [ApiController]
    [Route("api/appointments")]
    public class AppointmentsController : ControllerBase
    {
        private readonly AppointmentService _appointmentService;

        public AppointmentsController(AppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost("create")]
        public IActionResult Add(AppointmentAddRequestDto dto)
        {
            var result = _appointmentService.Add(dto);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_appointmentService.GetAll());
    }
}