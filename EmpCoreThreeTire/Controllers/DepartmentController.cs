using AutoMapper;
using EmpBAL.Dtos;
using EmpBAL.Services;
using EmpDAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmpCoreThreeTire.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private IMapper _mapper;

        public DepartmentController(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }

        [HttpGet("GetAllDepartments")]
        public IActionResult GetAllDepartments()
        {
            var response = _departmentService.GetDepartments();
            if (!response.Success)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet("GetDepartmentById/{id}")]
        public IActionResult GetDepartmentById(int id)
        {
            var response = _departmentService.GetDepartmentById(id);
            if (!response.Success)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPost("Create")]
        public IActionResult AddDepartment(AddDepartmentDto departmentDto)
        {
            var department =  _mapper.Map<DepartmentDto>(departmentDto);
            var result = _departmentService.AddDepartment(department);
            return !result.Success ? BadRequest(result) : Ok(result);

        }

        [HttpPut("UpdateDepartment")]
        public IActionResult UpdateDepartment(UpdateDepartmentDto departmentDto)
        {
            var department = _mapper.Map<DepartmentDto>(departmentDto);
            var response = _departmentService.UpdateDepartment(department);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpDelete("DeleteDepartment/{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            if (id > 0)
            {
                var response = _departmentService.DeleteDepartment(id);

                if (!response.Success)
                {
                    return BadRequest(response);
                }
                else
                {
                    return Ok(response);
                }
            }
            else
            {
                return BadRequest("Please enter proper data.");
            }
        }
    }
}
