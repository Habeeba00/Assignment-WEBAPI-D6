using Assignment_WEBAPI_D6.Models;
using Assignment_WEBAPI_D6.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_WEBAPI_D6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDepartmentController : ControllerBase
    {
        UnitOfWork unit;

        public EmployeeDepartmentController(UnitOfWork unit)
        {
            this.unit = unit;
        }
        [HttpGet]
        public IActionResult GetAll() 
        {
            List<Employee> employees = unit.Employeerepo.selectall();
            List<Department> departments = unit.Departmentrepo.selectall();
            var ob = new {e=employees,de=departments};
            return Ok(ob);
        }

        [HttpPost]
        public IActionResult Add(Employee emp)
        {
            unit.Departmentrepo.Add(emp.department);
            unit.Employeerepo.Add(emp);
            unit.save();
            return Ok();
        }





    }
}
