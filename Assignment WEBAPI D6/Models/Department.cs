using System.ComponentModel.DataAnnotations;

namespace Assignment_WEBAPI_D6.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Employee> Employees { get; set; }=new List<Employee>();
    }
}
