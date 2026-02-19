namespace HastaneOtomasyon.Controllers;
using Microsoft.AspNetCore.Mvc;
using HastaneOtomasyon.Models.Dtos.Departments;
using HastaneOtomasyon.Service;


    [ApiController]
    [Route("api/departments")]
    public class DepartmentsController : ControllerBase
    {
        private readonly DepartmentService _departmentService;

        public DepartmentsController(DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpPost("create")]
        public IActionResult Add(DepartmentAddRequestDto departmentDto)
        {
            try
            {
                var result = _departmentService.Add(departmentDto);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var departments = _departmentService.GetAll();
            return Ok(departments);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById([FromQuery] int id)
        {
            try
            {
                var department = _departmentService.GetById(id);
                return Ok(department);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] int id)
        {
            try
            {
                var result = _departmentService.Delete(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
