
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
    public class EmployeeController : ControllerBase
    {
        UnitOfWork unit;

        public EmployeeController(UnitOfWork unit)
        {
            this.unit = unit;
        }

        //public GenericRepository<Employee>  repo { get; }

        [HttpGet]
        public IActionResult GetAll() 
        {
            List<Employee> employees = unit.Employeerepo.selectall();
            List<DisplayEmployeeDTO> employeeDTOs = new List<DisplayEmployeeDTO>();
            foreach (Employee e in employees) 
            {
                DisplayEmployeeDTO employeeDTO= new DisplayEmployeeDTO() 
                {
                    EmployeeID=e.Id,
                    Name=e.Name,
                    Username=e.username,
                    Salary=e.Salary,
                    Email=e.Email,
                    Hiredate=e.Hiredate,
                    DepartmentId=e.department.Id,
                };
                employeeDTOs.Add(employeeDTO);
            }
            return Ok(employeeDTOs);
        }


        [HttpPost("{id:int}")]
        public IActionResult GetById(int id) 
        {
            Employee e = unit.Employeerepo.GetByid(id);
            if (e == null) 
            {
                return NotFound();
            }
            else
            {
                DisplayEmployeeDTO employeeDTO = new DisplayEmployeeDTO()
                {
                    EmployeeID = e.Id,
                    Name = e.Name,
                    Username = e.username,
                    Salary = e.Salary,
                    Email = e.Email,
                    Hiredate = e.Hiredate,
                    DepartmentId = e.department.Id,
                };
                return Ok(employeeDTO);
            }
        }


        [HttpPost]
        public IActionResult Add(AddEmployeeDTO employeeDTO) 
        {
            if (ModelState.IsValid) 
            {
                Employee e = new Employee() 
                {
                    Name = employeeDTO.Name,
                    username = employeeDTO.Username,
                    Salary = employeeDTO.Salary,
                    Email = employeeDTO.Email,
                    Hiredate = employeeDTO.Hiredate,
                    Password = employeeDTO.Password,
                    Confirm_Password = employeeDTO.Confirm_Password,
                    DepartmentId = employeeDTO.DepartmentId,
                };
                unit.Employeerepo.Add(e);
                return Ok(e);
            }
            else 
            {
                return BadRequest(ModelState); 
            }


        }


    }
}
