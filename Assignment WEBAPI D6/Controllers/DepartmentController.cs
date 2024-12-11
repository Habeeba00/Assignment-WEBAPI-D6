using Assignment_WEBAPI_D6.DTOs.Department;
using Assignment_WEBAPI_D6.DTOs.Employee;
using Assignment_WEBAPI_D6.Models;
using Assignment_WEBAPI_D6.Repository;
using Assignment_WEBAPI_D6.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_WEBAPI_D6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        UnitOfWork unit;

        public DepartmentController(UnitOfWork unit)
        {
            this.unit = unit;
        }

        [HttpGet]
        public IActionResult Get() 
        {
            List<Department> departments = unit.Departmentrepo.selectall();
            List<DisplayDepartmentDTO> departmentDTOs = new List<DisplayDepartmentDTO>();
            foreach(Department d in departments )
            {
                DisplayDepartmentDTO departmentDTO = new DisplayDepartmentDTO() 
                {
                   Id = d.Id,
                   Name=d.Name,
                   Description=d.Description,  
                };
                departmentDTOs.Add(departmentDTO);

            }
            return Ok(departmentDTOs);
        }


        [HttpPost]
        public IActionResult Add(AddDepartmentDTO departmentDTO) 
        {
            if (ModelState.IsValid) 
            {
                Department department = new Department() 
                {
                    Name = departmentDTO.Name,
                    Description= departmentDTO.Description,
                };
                unit.Departmentrepo.Add(department);
                return Ok(department);

            }
            return BadRequest(ModelState);
        }
    }
}
