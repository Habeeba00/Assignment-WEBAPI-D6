using System.ComponentModel.DataAnnotations;

namespace Assignment_WEBAPI_D6.DTOs.Employee
{
    public class AddEmployeeDTO
    {

        [Required(ErrorMessage = "This field is required")]
        //[StringLength(30,MinimumLength=20)]
        [MinLength(10)]
        public string Username { get; set; }

        public string Name { get; set; }
        public DateOnly Hiredate { get; set; }


        [Range(1200, 20000)]
        public decimal Salary { get; set; }
        public string Password { get; set; }

        [Compare("Password")]
        public string Confirm_Password { get; set; }
        [RegularExpression("^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$")]
        public string Email { get; set; }
        public int DepartmentId { get; set; }
    }
}
